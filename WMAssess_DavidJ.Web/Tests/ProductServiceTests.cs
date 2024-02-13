using System;
using System.Collections.Generic;
//using Moq;
using WMAssess_DavidJ.Models;
using WMAssess_DavidJ.Models.Interfaces;
using WMAssess_DavidJ.Services;
using NUnit;
using NUnit.Framework;

namespace WMAssess_DavidJ.Web.Tests
{
    [TestFixture]
    public class ProductServiceTests
    {
        [Test]
        public void Test_test()
        {
            Assert.Equals("1", "2");
        }

        //[Test]
        //public void GetProductBySku_ExistingSku_ShouldReturnProduct()
        //{
        //    // Arrange
        //    var sku = "SKU123";
        //    var expectedProduct = new Product { Id = 1, Name = "Product 1", SKU = sku };
        //    var mockDataService = new Mock<IDataService>();
        //    mockDataService.Setup(m => m.GetProducts()).Returns(new List<Product> { expectedProduct });
        //    var productService = new ProductService(mockDataService.Object, It.IsAny<INotify>());

        //    // Act
        //    var result = productService.GetProductBySku(sku);

        //    // Assert
        //    Assert.IsTrue(result.Success);
        //    Assert.AreEqual(expectedProduct, result.Data<Product>());
        //}

        //[Test]
        //public void CreateProduct_NewProduct_ShouldReturnSuccess()
        //{
        //    // Arrange
        //    var newProduct = new Product { Name = "New Product", SKU = "SKU123" };
        //    var mockDataService = new Mock<IDataService>();
        //    mockDataService.Setup(m => m.GetProducts()).Returns(new List<Product>());
        //    var productService = new ProductService(mockDataService.Object, It.IsAny<INotify>());

        //    // Act
        //    var result = productService.CreateProduct(newProduct);

        //    // Assert
        //    Assert.IsTrue(result.Success);
        //}

        //[Test]
        //public void UpdateProduct_ExistingProduct_ShouldReturnSuccess()
        //{
        //    // Arrange
        //    var existingProduct = new Product { Id = 1, Name = "Product 1", SKU = "SKU123" };
        //    var updatedProduct = new Product { Id = 1, Name = "Updated Product", SKU = "SKU123" };
        //    var mockDataService = new Mock<IDataService>();
        //    mockDataService.Setup(m => m.GetProducts()).Returns(new List<Product> { existingProduct });
        //    var productService = new ProductService(mockDataService.Object, It.IsAny<INotify>());

        //    // Act
        //    var result = productService.UpdateProduct(updatedProduct);

        //    // Assert
        //    Assert.IsTrue(result.Success);
        //}

        //[Test]
        //public void DeleteProductBySku_ExistingSku_ShouldReturnSuccess()
        //{
        //    // Arrange
        //    var sku = "SKU123";
        //    var existingProduct = new Product { Id = 1, Name = "Product 1", SKU = sku };
        //    var mockDataService = new Mock<IDataService>();
        //    mockDataService.Setup(m => m.GetProducts()).Returns(new List<Product> { existingProduct });
        //    var productService = new ProductService(mockDataService.Object, It.IsAny<INotify>());

        //    // Act
        //    var result = productService.DeleteProductBySku(sku);

        //    // Assert
        //    Assert.IsTrue(result.Success);
        //}
    }
}


