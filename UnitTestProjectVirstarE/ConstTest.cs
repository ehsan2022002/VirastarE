using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VirastarE;
using static VirastarE.Util;

namespace UnitTestProjectVirstarE
{
    [TestClass]
    public class ConstTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("1", UtilSystemEnum.OnKey);
            Assert.AreEqual("chkIgnoreEnglish", Util.UtilSystemEnum.chkIgnoreEnglish);
        }

        [TestMethod]
        public void CalendarFarsi()
        {
            var util = new Util();

            Assert.AreEqual(true , util.GetShamsiDateNow().Contains("/"));

        }
    }
}
