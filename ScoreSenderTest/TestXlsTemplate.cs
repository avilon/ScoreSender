using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ScoreSender.Entity;

namespace ScoreSenderTest
{
    [TestClass]
    public class TestXlsTemplate
    {
        [TestMethod]
        public void TestCreate()
        {
            XlsTemplate xls = new XlsTemplate("", "");
            Assert.IsNotNull(xls);
        }

        [TestMethod]
        public void TestSetQuarter()
        {
            XlsTemplate xls = new XlsTemplate("", "");
            xls.Quarter = 4;
        }
    }
}
