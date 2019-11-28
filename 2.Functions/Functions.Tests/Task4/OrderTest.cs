using System.Collections.Generic;
using System.Linq;
using Functions.Task4.ThirdParty;
using Functions.Task4.Stubs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Functions.Task4
{
    [TestClass]
    public class OrderTest
    {
        private const double Delta = 0.0001;

        private readonly Order order = new Order();

        [TestMethod]
        public void Should_Calculate_Zero_IfOrderContains_NoProduct()
        {
            order.Products = new List<IProduct>();
            Assert.AreEqual(0.0, order.GetPriceOfAvailableProducts(), Delta);
        }

        [TestMethod]
        public void ShouldCalculate_Zero_IfOrderContains_OnlyUnavailableProducts()
        {
            order.Products = GetList(new UnavailableProductStub(), new UnavailableProductStub());
            Assert.AreEqual(0.0, order.GetPriceOfAvailableProducts(), Delta);
        }

        [TestMethod]
        public void ShouldCalculate_Twenty_IfOrderContains_TwoAvailable10PriceProducts()
        {
            order.Products = GetList(new AvailableProductStub(), new AvailableProductStub());
            Assert.AreEqual(20.0, order.GetPriceOfAvailableProducts(), Delta);
        }

        [TestMethod]
        public void ShouldCalculate_Twenty_IfOrderContains_TwoAvailable10PriceProducts_WithOtherUnavailableProducts()
        {
            order.Products = GetList(new UnavailableProductStub(), new AvailableProductStub(),
                new AvailableProductStub(), new UnavailableProductStub());
            Assert.AreEqual(20.0, order.GetPriceOfAvailableProducts(), Delta);
        }

        private static List<IProduct> GetList(params IProduct[] products)
        {
            return products.ToList();
        }
    }
}
