using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using UsTec.FileDistributionService.Configurations;

namespace UsTec.FileDistributionService
{
    /// <summary>
    /// 配布設定に従ってファイルを配布する
    /// </summary>
    public class FileDistributionWorker
    {
        /// <summary>
        ///
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        ///
        /// </summary>
        private readonly DistributionConfiguration distributionConfiguration;

        /// <summary>
        ///
        /// </summary>
        /// <param name="distributionConfiguration"></param>
        public FileDistributionWorker(DistributionConfiguration distributionConfiguration)
        {
            this.distributionConfiguration = distributionConfiguration;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        public async Task ExecuteAsync(CancellationToken cancellation)
        {
            var delay = this.distributionConfiguration.Interval;
            while (!cancellation.IsCancellationRequested)
            {
                try
                {
                    this.DistributeFiles();
                }
                catch (OperationCanceledException)
                {
                    break;
                    //  NOTREACHED
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }

                await Task.Delay(delay, cancellation).ConfigureAwait(false);
            }
        }

        /// <summary>
        ///
        /// </summary>
        private void DistributeFiles()
        {
            foreach (var source_file_path in this.GetFiles())
            {
                logger.Info(source_file_path);
                foreach (var target in this.distributionConfiguration.Targets)
                {
                    var filename = Path.GetFileName(source_file_path);

                    var overwrite = target.Overwrite;

                    var target_directory_path = target.Path;
                    var target_file_path = Path.Combine(target_directory_path, filename);

                    logger.InfoFormat(Properties.Resources.FileCopying_Info, source_file_path, target_file_path, overwrite);
                    Directory.CreateDirectory(target_directory_path);
                    File.Copy(source_file_path, target_file_path, overwrite);
                    logger.InfoFormat(Properties.Resources.FileCopied_Info, source_file_path, target_file_path, overwrite);
                }

                logger.InfoFormat(Properties.Resources.SourceFileDeleting_Info, source_file_path);
                File.Delete(source_file_path);
                logger.InfoFormat(Properties.Resources.SourceFileDeleted_Info, source_file_path);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        private IEnumerable<string> GetFiles()
        {
            var source_directory_path = this.distributionConfiguration.Path;
            string GetSafePattern(string pattern) => string.IsNullOrWhiteSpace(pattern) ? "*" : pattern;

            return Directory.Exists(source_directory_path)
                ? Directory.GetFiles(source_directory_path, GetSafePattern(this.distributionConfiguration.Pattern))
                : new string[0];
        }
    }
}
