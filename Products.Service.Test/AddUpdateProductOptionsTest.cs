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
    public class AddUpdateProductOptionTest
    {
        IProductRepository _repository;
        IProductService _service;
        ProductOptionEntity productOption;

        [TestInitialize]
        public void Setup()
        {
            productOption = new ProductOptionEntity { Id = Guid.Parse("8F2E9176-35EE-4F0A-AE55-333333333333"), ProductId = Guid.Parse("8F2E9176-35EE-4F0A-AE55-83023D2DB133"), Name = "Samsung Galaxy S7", Description = "Newest mobile product from Samsung." };

            _repository = new SQLProductRepository();
            _service = new ProductService(_repository);
        }

        [TestMethod]
        public void Service_AddUpdateProductOption_OnExecute_AddsUpdatesProductOption()
        {
            var response = _service.GetProductOption(new GetProductOptionRequest { Id = Guid.Parse("8F2E9176-35EE-4F0A-AE55-333333333333") });

            if (response.ProductOption != null)
            {
                var addResponse = _service.UpdateProductOption(new UpdateProductOptionRequest { ProductOptionEntity = productOption });
                Assert.IsNotNull(addResponse.Message);
                Assert.AreEqual("Product option updated successfully!", addResponse.Message);
            }
            else
            {
                var updateResponse = _service.AddProductOption(new AddProductOptionRequest { ProductOptionEntity = productOption });
                Assert.IsNotNull(updateResponse.Message);
                Assert.AreEqual("Product option added successfully!", updateResponse.Message);
            }
        }
    }
}
