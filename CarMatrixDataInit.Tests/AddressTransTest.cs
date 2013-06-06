using System;
using CarMatrixDataReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarMatrixDataInit.Tests
{
    [TestClass]
    public class AddressTransTest
    {
        [TestMethod]
        public void TestBuildeUrl()
        {
            AddressTrans at = new AddressTrans();
            string url = at.BuildeUrl("百度大厦");
            //Assert.AreEqual("", url);
        }
    }
}
