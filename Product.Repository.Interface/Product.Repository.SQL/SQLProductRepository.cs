using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using Product.Entities;
using Product.Repository.Interfaces;

namespace Product.Repository.SQL
{
    /// <summary>
    /// Database operations for product
    /// </summary>
    public class SQLProductRepository : IProductRepository
    {
        public ProductEntity GetProductById(Guid id)
        {
            if (id == Guid.Empty || id == null)
                throw new ArgumentException("Cannot be 00000000-0000-0000-0000-000000000000", "id");

            ProductEntity entity;

            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString))
            {
                sqlConnection.Open();
                try
                {
                    using (var sqlCommand = sqlConnection.ToReadProductSqlCommand(id, null))
                    {
                        using (var sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            sqlDataReader.Read();
                            entity = sqlDataReader.ToProduct();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ProviderException("Unexpected exception in GetProduct", ex);
                }
            }

            return entity;
        }

        public ProductEntity GetProductByName(string name)
        {
            if (name == string.Empty)
                throw new ArgumentException("Cannot be empty", "name");

            ProductEntity entity;

            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString))
            {
                sqlConnection.Open();
                try
                {
                    using (var sqlCommand = sqlConnection.ToReadProductSqlCommand(null, name))
                    {
                        using (var sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            sqlDataReader.Read();
                            entity = sqlDataReader.ToProduct();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ProviderException("Unexpected exception in GetProductByName", ex);
                }
            }

            return entity;
        }

        public IList<ProductEntity> GetAllProducts()
        {
            var entities = new List<ProductEntity>();

            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString))
            {
                sqlConnection.Open();
                try
                {
                    using (var sqlCommand = sqlConnection.ToReadProductSqlCommand(null, null))
                    {
                        using (var sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                entities.Add(sqlDataReader.ToProduct());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ProviderException("Unexpected exception in GetAllProducts", ex);
                }
            }

            return entities;
        }

        public ProductOptionEntity GetProductOption(Guid id)
        {
            if (id == Guid.Empty || id == null)
                throw new ArgumentException("Cannot be 00000000-0000-0000-0000-000000000000", "id");

            ProductOptionEntity entity;

            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString))
            {
                sqlConnection.Open();
                try
                {
                    using (var sqlCommand = sqlConnection.ToReadProductOptionSqlCommand(id, null))
                    {
                        using (var sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            sqlDataReader.Read();
                            entity = sqlDataReader.ToProductOption();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ProviderException("Unexpected exception in GetProductOption", ex);
                }

                return entity;
            }
        }

        public IList<ProductOptionEntity> GetProductOptions(Guid productId)
        {
            if (productId == new Guid())
                throw new ArgumentException("productId cannot be null or 00000000-0000-0000-0000-000000000000", "productId");

            var entities = new List<ProductOptionEntity>();

            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString))
            {
                sqlConnection.Open();
                try
                {
                    using (var sqlCommand = sqlConnection.ToReadProductOptionSqlCommand(null, productId))
                    {
                        using (var sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                entities.Add(sqlDataReader.ToProductOption());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ProviderException("Unexpected exception in GetProductOptions", ex);
                }
            }

            return entities;
        }

        public void AddProduct(ProductEntity productEntity)
        {
            if (productEntity == null || productEntity.Id == null)
                throw new ArgumentException("Cannot be empty", "productEntity");

            try
            {
                using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString))
                {
                    sqlConnection.Open();
                    try
                    {
                        using (var sqlCommand = sqlConnection.ToInsertProductSqlCommand(productEntity))
                        {
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new ProviderException("Unexpected exception in SaveProduct", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ProviderException("Unexpected exception in SaveProduct", ex);
            }
        }

        public void AddProductOption(ProductOptionEntity productOptionEntity)
        {
            if (productOptionEntity == null || productOptionEntity.Id == null)
                throw new ArgumentException("Cannot be empty", "productOptionEntity");

            try
            {
                using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString))
                {
                    sqlConnection.Open();
                    try
                    {
                        using (var sqlCommand = sqlConnection.ToInsertProductOptionSqlCommand(productOptionEntity))
                        {
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new ProviderException("Unexpected exception in AddProductOption", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ProviderException("Unexpected exception in SaveProductOption", ex);
            }
        }

        public void UpdateProduct(ProductEntity productEntity)
        {
            if (productEntity == null || productEntity.Id == null)
                throw new ArgumentException("Cannot be empty", "productEntity");

            try
            {
                using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString))
                {
                    sqlConnection.Open();
                    try
                    {
                        using (var sqlCommand = sqlConnection.ToUpdateProductSqlCommand(productEntity))
                        {
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new ProviderException("Unexpected exception in UpdateProduct", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ProviderException("Unexpected exception in UpdateProduct", ex);
            }
        }

        public void UpdateProductOption(ProductOptionEntity productOptionEntity)
        {
            if (productOptionEntity == null || productOptionEntity.Id == null)
                throw new ArgumentException("Cannot be empty", "productOptionEntity");

            try
            {
                using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString))
                {
                    sqlConnection.Open();
                    try
                    {
                        using (var sqlCommand = sqlConnection.ToUpdateProductOptionSqlCommand(productOptionEntity))
                        {
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new ProviderException("Unexpected exception in UpdateProductOption", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ProviderException("Unexpected exception in UpdateProductOption", ex);
            }

        }

        public void DeleteProduct(Guid id)
        {
            if (id == Guid.Empty || id == null)
                throw new ArgumentException("Cannot be 00000000-0000-0000-0000-000000000000", "id");

            try
            {
                using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString))
                {
                    sqlConnection.Open();
                    try
                    {
                        using (var sqlCommand = sqlConnection.ToDeleteProductSqlCommand(id))
                        {
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new ProviderException("Unexpected exception in DeleteProduct", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ProviderException("Unexpected exception in DeleteProduct", ex);
            }
        }

        public void DeleteProductOption(Guid id)
        {
            if (id == Guid.Empty || id == null)
                throw new ArgumentException("Cannot be 00000000-0000-0000-0000-000000000000", "id");

            try
            {
                using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString))
                {
                    sqlConnection.Open();
                    try
                    {
                        using (var sqlCommand = sqlConnection.ToDeleteProductOptionSqlCommand(id))
                        {
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new ProviderException("Unexpected exception in DeleteProductOption", ex);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ProviderException("Unexpected exception in DeleteProductOption", ex);
            }
        }
    }
}
