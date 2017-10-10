using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Product.Repository.Interfaces;
using System.Collections.Generic;
using Product.Entities;
using Moq;
using Product.Service.Interfaces;
using System.Collections;
using Product.Service.Interfaces.Requests;
using Product.Service.Implementation;

namespace Product.Service.Test
{
    [TestClass]
    public class GetProductOptionMockTest
    {
        IProductRepository _repository;
        IProductService _service;

        [TestInitialize]
        public void Setup()
        {
            var productOptions = new List<ProductOptionEntity>()
            {
                new ProductOptionEntity {Id = Guid.Parse("0643CCF0-AB00-4862-B3C5-40E2731ABCC9"), ProductId = Guid.Parse("8F2E9176-35EE-4F0A-AE55-83023D2DB1A3"), Name = "White", Description = "White Samsung Galaxy S7"},
                new ProductOptionEntity {Id = Guid.Parse("A21D5777-A655-4020-B431-624BB331E9A2"), ProductId = Guid.Parse("8F2E9176-35EE-4F0A-AE55-83023D2DB1A3"), Name = "Black", Description = "Black Samsung Galaxy S7"},
                new ProductOptionEntity {Id = Guid.Parse("8F2E9176-35EE-4F0A-AE55-83023D2DB144"), ProductId = Guid.Parse("8F2E9176-35EE-4F0A-AE55-83023D2DB1A3"), Name = "Test", Description = "Test Samsung Galaxy S7"}
            };

            var serviceMock = new Mock<IProductRepository>();
            serviceMock.Setup(r => r.GetProductOptions(It.IsAny<Guid>())).Returns((Guid id) => productOptions.FindAll(p => p.ProductId == id));
            serviceMock.Setup(r => r.GetProductOption(It.IsAny<Guid>())).Returns((Guid id) => productOptions.FirstOrDefault(p => p.Id == id));

            _repository = serviceMock.Object;
            _service = new ProductService(_repository);
        }

        [TestMethod]
        public void Service_GetProductOptionsMock_OnExecute_ReturnsProducts()
        {
            var response = _service.GetProductOptions(new GetProductOptionsRequest { ProductId = Guid.Parse("8F2E9176-35EE-4F0A-AE55-83023D2DB1A3") });

            Assert.IsNotNull(response.ProductOptions);
            Assert.AreEqual(3, response.ProductOptions.Count);
        }
        
        [TestMethod]
        public void Service_GetProductOptionMock_OnExecute_ReturnsProduct()
        {
            var response = _service.GetProductOption(new GetProductOptionRequest { Id = Guid.Parse("0643CCF0-AB00-4862-B3C5-40E2731ABCC9") });

            Assert.IsNotNull(response.ProductOption);
            Assert.AreEqual("White", response.ProductOption.Name);
        }

        [TestMethod]
        public void Service_GetProductOptionMock_OnExecuteWithInvalidId_ReturnsNull()
        {
            var response = _service.GetProductById(new GetProductByIdRequest { Id = Guid.Parse("DE1287C0-4B15-4A7B-9D8A-DD21B3CAFEEE") });

            Assert.IsNull(response.Product);
        }
    }
}
