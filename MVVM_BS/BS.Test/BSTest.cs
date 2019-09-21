using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BS;
namespace BS.Test
{
    [TestClass]
    public class BSTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            BS bS = new BS();

            double resCall=bS.computeCall(50, 55, 1, 0.2, 0.09);
            Assert.IsTrue(Math.Abs(resCall-3.8617)<0.0001);

            double resPut=bS.computePut(50, 55, 1, 0.2, 0.09);
            Assert.IsTrue(Math.Abs(resPut - 4.1279) < 0.0001);
        }

        [TestMethod]
        public void TestMethodAtTheMoney()
        {
            BS bS = new BS();

            double resCall = bS.computeCall(55, 55, 1, 0.2, 0.09);
            Assert.IsTrue(Math.Abs(resCall - 6.9751554364952) < 0.0001);

            double resPut = bS.computePut(55, 55, 1, 0.2, 0.09);
            Assert.IsTrue(Math.Abs(resPut - 2.2413706264127526) < 0.0001);
        }

        [TestMethod]
        public void TestMethodAtTheMoneyNegativeRate()
        {
            BS bS = new BS();

            double resCall = bS.computeCall(55, 55, 0.5, 0.25, -0.01);
            Assert.IsTrue(Math.Abs(resCall - 3.7471) < 0.001);

            double resPut = bS.computePut(55, 55, 0.5, 0.25, -0.01);
            Assert.IsTrue(Math.Abs(resPut - 4.02286) < 0.0001);
        }

        [TestMethod]
        public void TestMethod2()
        {
            BS bS = new BS();

            double resCall = bS.computeCall(64, 60, 180.0/365.0, 0.27, 0.045);
            Assert.IsTrue(Math.Abs(resCall - 7.7661) < 0.0001);

            double resPut = bS.computePut(64, 60, 180.0 / 365.0, 0.27, 0.045);
            Assert.IsTrue(Math.Abs(resPut - 2.4493) < 0.0001);
        }

        [TestMethod]
        public void TestMethod3()
        {
            BS bS = new BS();

            double resCall = bS.computeCall(50, 55, 1, 0.65, 0.09);

            Assert.IsTrue(Math.Abs(resCall - 12.64216) < 0.0001);
        }

        [TestMethod]
        public void TestMethodPutAtZero()
        {
            BS bS = new BS();

            double resCall = bS.computeCall(102, 1, 1, 0.2, 0.01);
            Assert.IsTrue(Math.Abs(resCall - 101.00995) < 0.0001);

            double resPut = bS.computePut(102, 1, 1, 0.2, 0.01);
            Assert.IsTrue(Math.Abs(resPut - 0.0) < 0.0001);//should theroically be 102- 101.00995 but numerical precision problems
        }
    }
}
