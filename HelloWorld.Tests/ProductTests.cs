using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld.Models;
using HelloWorld.Controllers;
using Moq;
using System.Linq;

namespace HelloWorld.Tests
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void TestMethodWithFakeClass()
        {
            // Arrange
            var controller = new HomeController(new FakeProductRepository());

            // Act
            var result = controller.Products();

            // Assert
            var products = (Product[])((System.Web.Mvc.ViewResultBase)(result)).Model;
            Assert.AreEqual(4, products.Length, "Length is invalid");
        }

        [TestMethod]
        public void TestMethodWithMoq()
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository
                .SetupGet(t => t.Products)
                .Returns(() =>
                {
                    return new Product[]
                    {
                        new Product{Name="Baseball", Price=11},
                        new Product{Name="Football", Price=8},
                        new Product{Name="Tennis Ball", Price=13},
                        new Product{Name="Golf ball", Price=3},
                        new Product{Name="Ping pong ball", Price=12}
                    };
                });

            // Arrange
            var controller = new HomeController(mockProductRepository.Object);

            // Act
            var result = controller.Products();

            // Assert
            var products = (Product[])((System.Web.Mvc.ViewResultBase)(result)).Model;
            Assert.AreEqual(5, products.Length, "Length is invalid");
            Assert.IsTrue(products.Where(t => t.Price > 10).Count() >= 3, "too few > $10");
            Assert.IsTrue(products.Where(t => t.Price < 10).Count() <= 2, "too many < $10");
        }
    }
}