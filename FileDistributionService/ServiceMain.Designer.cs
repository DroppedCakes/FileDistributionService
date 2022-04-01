
namespace UsTec.FileDistributionService
{
    partial class ServiceMain
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.HeartBeatTimer = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.HeartBeatTimer)).BeginInit();
            // 
            // HeartBeatTimer
            // 
            this.HeartBeatTimer.Enabled = true;
            this.HeartBeatTimer.Interval = 60000D;
            this.HeartBeatTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.HeartBeatTimer_Elapsed);
            // 
            // ServiceMain
            // 
            this.ServiceName = "Service1";
            ((System.ComponentModel.ISupportInitialize)(this.HeartBeatTimer)).EndInit();

        }

        #endregion

        private System.Timers.Timer HeartBeatTimer;
    }
}
