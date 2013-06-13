using System;
using System.Collections.Generic;
using CarMatrixData.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarMatrixServices.Tests
{
    [TestClass]
    public class OrderServiceTest
    {
        private IList<Order> orders;


        public OrderServiceTest()
        {
            orders = new List<Order>();

        }

        [TestMethod]
        public void GetOrdersYears()
        {

        }
    }
}
