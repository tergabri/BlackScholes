﻿using System;
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
        public void TestMethod2()
        {
            BS bS = new BS();

            double resCall = bS.computeCall(64, 60, 180.0/365.0, 0.27, 0.045);

            Assert.IsTrue(Math.Abs(resCall - 7.7661) < 0.0001);

            double resPut = bS.computePut(64, 60, 180.0 / 365.0, 0.27, 0.045);

            Assert.IsTrue(Math.Abs(resPut - 2.4493) < 0.0001);
        }
    }
}
