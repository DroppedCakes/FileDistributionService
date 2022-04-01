using System.Xml.Serialization;

namespace UsTec.FileDistributionService.Configurations
{
    /// <summary>
    /// 配布設定
    /// </summary>
    public class DistributionConfiguration
    {
        /// <summary>
        /// 既定の処理インターバル
        /// 60秒
        /// </summary>
        public const int DefaultInterval = 60 * 1000;

        /// <summary>
        /// 処理間隔ミリ秒数
        /// </summary>
        [XmlAttribute("interval")]
        public int Interval { get; set; } = DefaultInterval;

        /// <summary>
        /// 配布元ディレクトリへのパス
        /// </summary>
        [XmlAttribute("path")]
        public string Path { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute("pattern")]
        public string Pattern { get; set; }

        /// <summary>
        /// 配布先ディレクトリへのパス群
        /// </summary>
        [XmlElement("target")]
        public TargetConfiguration[] Targets { get; set; }
    }
}
