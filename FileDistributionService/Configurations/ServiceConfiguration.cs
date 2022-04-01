using System.IO;
using System.Xml.Serialization;

namespace UsTec.FileDistributionService.Configurations
{
    /// <summary>
    /// サービス動作設定
    /// </summary>
    [XmlRoot("distributor")]
    public class ServiceConfiguration
    {
        /// <summary>
        ///
        /// </summary>
        private static readonly XmlSerializer serializer = new XmlSerializer(typeof(ServiceConfiguration));

        /// <summary>
        /// 配布設定群
        /// </summary>
        [XmlElement("distribution")]
        public DistributionConfiguration[] Distributions { get; set; }

        /// <summary>
        /// 指定されたストリームより設定を読み込んで返す
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static ServiceConfiguration Load(Stream stream)
        {
            return serializer.Deserialize(stream) as ServiceConfiguration;
        }
    }
}
