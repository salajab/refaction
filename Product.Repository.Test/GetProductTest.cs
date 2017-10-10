using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Product.Repository.SQL;
using Product.Repository.Interfaces;

namespace Product.Repository.Test
{
    [TestClass]
    public class GetProductTest
    {
        IProductRepository productRepository;

        [TestInitialize]
        public void Setup()
        {
            productRepository = new SQLProductRepository();
        }

        [TestMethod]
        public void GetProductById_OnExecute_ReturnsProduct()
        {
            //Act
            var product = productRepository.GetProductById(Guid.Parse("8F2E9176-35EE-4F0A-AE55-83023D2DB1A3"));

            //Assert
            product.Price.ShouldBeEquivalentTo((decimal)1024.99);

        }

        [TestMethod]
        public void GetProductById_OnExecuteWithInValidValue_ReturnsNull()
        {
            //Act
            var output = productRepository.GetProductById(Guid.Parse("8F2E9176-35EE-4F0A-AE55-83023D2DDDDD"));

            //Assert
            output.ShouldBeEquivalentTo(null);

        }

        [TestMethod]
        public void GetProductByName_OnExecute_ReturnsProduct()
        {
            //Act
            var product = productRepository.GetProductByName("Samsung Galaxy S7");

            //Assert
            product.Price.ShouldBeEquivalentTo((decimal)1024.99);

        }

        [TestMethod]
        public void GetProductByName_OnExecuteWithInValidValue_ReturnsNull()
        {
            //Act
            var output = productRepository.GetProductByName("Invalid Product");

            //Assert
            output.ShouldBeEquivalentTo(null);

        }

        [TestMethod]
        public void GetAllProducts_OnExecute_ReturnsProductList()
        {
            //Act
            var output = productRepository.GetAllProducts();

            //Assert
            output.Count.Should().BePositive();

        }
    }
}
