using System;
using System.Collections.Generic;
using Product.Entities;

namespace Product.Repository.Interfaces
{
    /// <summary>
    /// Database operations for Products and Product Options
    /// </summary>
    public interface IProductRepository
    {
        ProductEntity GetProductById(Guid id);

        ProductEntity GetProductByName(string name);

        IList<ProductEntity> GetAllProducts();

        IList<ProductOptionEntity> GetProductOptions(Guid productId);

        ProductOptionEntity GetProductOption(Guid Id);

        void AddProduct(ProductEntity product);

        void AddProductOption(ProductOptionEntity productOption);

        void UpdateProduct(ProductEntity product);

        void UpdateProductOption(ProductOptionEntity productOption);

        void DeleteProduct(Guid id);       

        void DeleteProductOption(Guid id);
    }
}
