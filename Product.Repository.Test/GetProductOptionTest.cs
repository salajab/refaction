using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Product.Repository.Interfaces;
using Product.Repository.SQL;

namespace Product.Repository.Test
{
    [TestClass]
    public class GetProductOptionsTest
    {
        IProductRepository productsRepository;

        [TestInitialize]
        public void Setup()
        {
            productsRepository = new SQLProductRepository();
        }

        [TestMethod]
        public void GetProductOption_OnExecute_ReturnsProductOption()
        {
            //Act
            var productOption = productsRepository.GetProductOption(Guid.Parse("0643CCF0-AB00-4862-B3C5-40E2731ABCC9"));

            //Assert
            productOption.Name.ShouldBeEquivalentTo("White");

        }

        [TestMethod]
        public void GetProductOption_OnExecuteWithInValidValue_ReturnsNull()
        {
            //Act
            var productOption = productsRepository.GetProductOption(Guid.Parse("0643CCF0-AB00-4862-B3C5-40E2731ABC99"));

            //Assert
            productOption.ShouldBeEquivalentTo(null);

        }

        [TestMethod]
        public void GetProductOptions_OnExecute_ReturnsProductList()
        {
            //Act
            var productOptions = productsRepository.GetProductOptions(Guid.Parse("8F2E9176-35EE-4F0A-AE55-83023D2DB1A3"));

            //Assert
            productOptions.Count.Should().BePositive();

        }
  
    }
}
