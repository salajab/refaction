using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Product.Repository.Interfaces;
using Product.Entities;
using Product.Service.Interfaces;
using Product.Service.Interfaces.Requests;
using Product.Service.Implementation;
using Product.Repository.SQL;

namespace Product.Service.Test
{
    [TestClass]
    public class AddUpdateProductTest
    {
        IProductRepository _repository;
        IProductService _service;
        ProductEntity product;

        [TestInitialize]
        public void Setup()
        {
            product = new ProductEntity { Id = Guid.Parse("8F2E9176-35EE-4F0A-AE55-83023D2DB133"), Name = "Samsung Galaxy S7", Description = "Newest mobile product from Samsung.", Price = (decimal)1024.99, DeliveryPrice = (decimal)16.99 };

            _repository = new SQLProductRepository();
            _service = new ProductService(_repository);
        }

        [TestMethod]
        public void Service_AddUpdateProduct_OnExecute_AddsUpdatesProduct()
        {
            var response = _service.GetProductById(new GetProductByIdRequest { Id = Guid.Parse("8F2E9176-35EE-4F0A-AE55-83023D2DB133") });

            if (response.Product != null)
            {
                var addResponse = _service.UpdateProduct(new UpdateProductRequest { ProductEntity = product });
                Assert.IsNotNull(addResponse.Message);
                Assert.AreEqual("Product updated successfully!", addResponse.Message);
            }
            else
            {
                var updateResponse = _service.AddProduct(new AddProductRequest { ProductEntity = product });
                Assert.IsNotNull(updateResponse.Message);
                Assert.AreEqual("Product added successfully!", updateResponse.Message);
            }
        }
    }
}
