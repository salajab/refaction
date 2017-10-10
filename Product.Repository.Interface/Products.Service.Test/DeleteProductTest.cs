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
    public class DeleteProductTest
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
        public void Service_DeleteProduct_OnExecute_DeletesProduct()
        {
            var response = _service.GetProductById(new GetProductByIdRequest { Id = Guid.Parse("8F2E9176-35EE-4F0A-AE55-83023D2DB133") });

            if (response.Product != null)
            {
                var deleteResponse = _service.DeleteProduct(new DeleteProductRequest { Id = Guid.Parse("8F2E9176-35EE-4F0A-AE55-83023D2DB133") });


                var responseOption = _service.GetProductOption(new GetProductOptionRequest { Id = Guid.Parse("8F2E9176-35EE-4F0A-AE55-333333333333") });

                if (responseOption.ProductOption != null)
                {
                    Assert.IsNotNull(deleteResponse.Errors[0].SystemMessage);
                    Assert.AreEqual("Unexpected exception in DeleteProduct", deleteResponse.Errors[0].SystemMessage);
                }else
                {
                    Assert.IsNotNull(deleteResponse.Message);
                    Assert.AreEqual("Product deleted successfully!", deleteResponse.Message);
                }
               
               
            }

            //Unexpected exception in DeleteProduct
        }
    }
}
