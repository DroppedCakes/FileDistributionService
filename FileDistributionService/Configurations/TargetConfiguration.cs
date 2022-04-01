using System.Xml.Serialization;

namespace UsTec.FileDistributionService.Configurations
{
    /// <summary>
    /// 配布先設定
    /// </summary>
    public class TargetConfiguration
    {
        /// <summary>
        ///
        /// </summary>
        [XmlAttribute("overwrite")]
        public bool Overwrite { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute("path")]
        public string Path { get; set; }
    }
}
