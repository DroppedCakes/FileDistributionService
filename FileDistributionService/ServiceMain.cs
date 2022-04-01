using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using UsTec.FileDistributionService.Configurations;

namespace UsTec.FileDistributionService
{
    /// <summary>
    ///
    /// </summary>
    public partial class ServiceMain : ServiceBase
    {
        /// <summary>
        ///
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        ///
        /// </summary>
        private readonly CancellationTokenSource cancellation = new CancellationTokenSource();

        /// <summary>
        ///
        /// </summary>
        private readonly List<Task> tasks = new List<Task>();

        /// <summary>
        ///
        /// </summary>
        public ServiceMain()
        {
            InitializeComponent();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            //  ファイル名順に設定ファイル群を読み込み
            //  複製タスクを起動する
            var config_directory_path = Properties.Settings.Default.ConfigurationDirectoryPath;
            logger.Info(config_directory_path);
            foreach (var config_file_path in Directory.GetFiles(config_directory_path, "*.xml").OrderBy(path => path))
            {
                logger.Info(config_file_path);

                try
                {
                    using (var stream = File.OpenRead(config_file_path))
                    {
                        var service_config = ServiceConfiguration.Load(stream);
                        this.DumpServiceConfig(service_config);
                        foreach (var distribution_config in service_config.Distributions)
                        {
                            var cancellation = this.cancellation.Token;
                            this.tasks.Add(
                                Task.Run(
                                    () => new FileDistributionWorker(distribution_config).ExecuteAsync(cancellation),
                                    cancellation
                                )
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        protected override void OnStop()
        {
            this.cancellation.Cancel();

            try
            {
                Task.WaitAll(this.tasks.ToArray());
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            this.cancellation.Dispose();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="c"></param>
        private void DumpServiceConfig(ServiceConfiguration c)
        {
            foreach (var d in c.Distributions)
            {
                logger.Debug($"  distribution path={d.Path} interval={d.Interval} pattern={d.Pattern}");
                foreach (var t in d.Targets)
                {
                    logger.Debug($"    target path={t.Path} overwrite={t.Overwrite}");
                }
            }
        }

        /// <summary>
        /// 生存記録タイマ満了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeartBeatTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            logger.Info("---- HEARTBEAT ----");
        }
    }
}
