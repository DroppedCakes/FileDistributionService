using log4net;
using System;
using System.Diagnostics;
using System.Reflection;
using System.ServiceProcess;

namespace UsTec.FileDistributionService
{
    /// <summary>
    ///
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        public static void Main()
        {
            var version = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
            logger.Info($"starting program version {version.FileVersion}");

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new ServiceMain()
            };
            ServiceBase.Run(ServicesToRun);

            logger.Info("terminating program");
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            logger.Fatal(e.ExceptionObject);
        }
    }
}
