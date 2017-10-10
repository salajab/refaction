using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Product.Repository.Interfaces;
using System.Collections.Generic;
using Product.Entities;
using Moq;
using Product.Service.Interfaces;
using Product.Service.Interfaces.Requests;
using Product.Service.Implementation;

namespace Product.Service.Test
{
    [TestClass]
    public class GetProductMockTest
    {
        IProductRepository _repository;
        IProductService _service;

        [TestInitialize]
        public void Setup()
        {
            var products = new List<ProductEntity>()
            {
                new ProductEntity {Id = Guid.Parse("8F2E9176-35EE-4F0A-AE55-83023D2DB1A3"), Name = "Samsung Galaxy S7", Description = "Newest mobile product from Samsung.", Price = (decimal) 1024.99, DeliveryPrice = (decimal) 16.99 },
                new ProductEntity {Id = Guid.Parse("DE1287C0-4B15-4A7B-9D8A-DD21B3CAFEC3"), Name = "Apple iPhone 6S", Description = "Newest mobile product from Apple.", Price = (decimal) 1299.99, DeliveryPrice = (decimal) 15.99 },
            };

            var serviceMock = new Mock<IProductRepository>();
            serviceMock.Setup(r => r.GetAllProducts()).Returns(products);
            serviceMock.Setup(r => r.GetProductByName(It.IsAny<string>())).Returns((string n) => products.FirstOrDefault(p => p.Name == n));
            serviceMock.Setup(r => r.GetProductById(It.IsAny<Guid>())).Returns((Guid id) => products.FirstOrDefault(p => p.Id == id));

            _repository = serviceMock.Object;
            _service = new ProductService(_repository);
        }

        [TestMethod]
        public void ServiceMock_GetAllProducts_OnExecute_ReturnsProducts()
        {
            var response = _service.GetAllProducts();

            Assert.IsNotNull(response.Products);
            Assert.AreEqual(2, response.Products.Count);
        }

        [TestMethod]
        public void ServiceMock_GetProductByName_OnExecute_ReturnsProduct()
        {
            var response = _service.GetProductByName(new GetProductByNameRequest { Name = "Samsung Galaxy S7" });

            Assert.IsNotNull(response.Product);
            Assert.AreEqual("Samsung Galaxy S7", response.Product.Name);
        }

        [TestMethod]
        public void ServiceMock_GetProductByName_OnExecute_ReturnsNull()
        {
            var response = _service.GetProductByName(new GetProductByNameRequest { Name = "InvalidName" });

            Assert.IsNull(response.Product);           
        }

        [TestMethod]
        public void ServiceMock_GetProductById_OnExecute_ReturnsProduct()
        {
            var response = _service.GetProductById(new GetProductByIdRequest { Id = Guid.Parse("DE1287C0-4B15-4A7B-9D8A-DD21B3CAFEC3") });

            Assert.IsNotNull(response.Product);
            Assert.AreEqual("Apple iPhone 6S", response.Product.Name);
        }

        [TestMethod]
        public void ServiceMock_GetProductById_OnExecuteWithInvalidId_ReturnsNull()
        {
            var response = _service.GetProductById(new GetProductByIdRequest { Id = Guid.Parse("DE1287C0-4B15-4A7B-9D8A-DD21B3CAFEEE") });
            Assert.IsNull(response.Product);
        }
    }
}
