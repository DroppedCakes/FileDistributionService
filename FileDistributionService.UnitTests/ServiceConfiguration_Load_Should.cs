using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;
using UsTec.FileDistributionService.Configurations;

namespace FileDistributionService.UnitTests
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class ServiceConfiguration_Load_Should
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void LoadConfiguration()
        {
            var xml = @"<?xml version=""1.0""?>
<distributor>
  <distribution path=""source0"" interval=""123456"" pattern=""*.ext"">
    <target path=""target00"" overwrite=""false"" />
    <target path=""target01"" overwrite=""true"" />
    <target path=""target02"" overwrite=""false"" />
  </distribution>
  <distribution path=""source1"">
    <target path=""target10"" />
    <target path=""target11"" />
    <target path=""target12"" />
  </distribution>
</distributor>";
            using (var buffer = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                var actual = ServiceConfiguration.Load(buffer);

                //  2 distributions
                Assert.AreEqual(2, actual.Distributions.Length);

                //  distribution[0]
                Assert.AreEqual(123456, actual.Distributions[0].Interval);
                Assert.AreEqual("source0", actual.Distributions[0].Path);
                Assert.AreEqual("*.ext", actual.Distributions[0].Pattern);
                Assert.AreEqual(3, actual.Distributions[0].Targets.Length);

                //  distribution[0].Targets[0]
                Assert.IsFalse(actual.Distributions[0].Targets[0].Overwrite);
                Assert.AreEqual("target00", actual.Distributions[0].Targets[0].Path);

                //  distribution[0].Targets[1]
                Assert.IsTrue(actual.Distributions[0].Targets[1].Overwrite);
                Assert.AreEqual("target01", actual.Distributions[0].Targets[1].Path);

                //  distribution[0].Targets[2]
                Assert.IsFalse(actual.Distributions[0].Targets[2].Overwrite);
                Assert.AreEqual("target02", actual.Distributions[0].Targets[2].Path);

                //  distribution[1]
                Assert.AreEqual(DistributionConfiguration.DefaultInterval, actual.Distributions[1].Interval);
                Assert.AreEqual("source1", actual.Distributions[1].Path);
                Assert.IsNull(actual.Distributions[1].Pattern);
                Assert.AreEqual(3, actual.Distributions[1].Targets.Length);

                //  distribution[1].Targets[0]
                Assert.IsFalse(actual.Distributions[1].Targets[0].Overwrite);
                Assert.AreEqual("target10", actual.Distributions[1].Targets[0].Path);

                //  distribution[1].Targets[1]
                Assert.IsFalse(actual.Distributions[1].Targets[1].Overwrite);
                Assert.AreEqual("target11", actual.Distributions[1].Targets[1].Path);

                //  distribution[1].Targets[2]
                Assert.IsFalse(actual.Distributions[1].Targets[2].Overwrite);
                Assert.AreEqual("target12", actual.Distributions[1].Targets[2].Path);
            }
        }
    }
}
