using System;
using System.Data;
using System.Data.SqlClient;
using Product.Entities;

namespace Product.Repository.SQL
{
    public static class ProductOptionExtension
    {
        public static ProductOptionEntity ToProductOption(this SqlDataReader value)
        {
            if (!value.HasRows)
                return null;

            ProductOptionEntity entity;
            try
            {
                entity = new ProductOptionEntity
                {
                    Id = (Guid)value["Id"],
                    ProductId = (Guid)value["ProductId"],
                    Name = (value["Name"] != DBNull.Value)
                                    ? value["Name"].ToString()
                                    : null,
                    Description = (value["Description"] != DBNull.Value)
                                    ? value["Description"].ToString()
                                    : null
                };
            }
            catch (Exception ex)
            {
                throw new ProviderException("Unexpected exception in ToProductOption", ex);
            }

            return entity;
        }

        public static SqlCommand ToReadProductOptionSqlCommand(this SqlConnection sqlConnection, Guid? id, Guid? productId)
        {
            var sqlCommand = new SqlCommand
            {
                CommandText = "[dbo].[psp_GetProductOption]",
                CommandType = CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlCommand.Parameters.Add(
                new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
                {
                    Value = (id != null) ? id as object : DBNull.Value as object
                });

            sqlCommand.Parameters.Add(
                new SqlParameter("@ProductId", SqlDbType.UniqueIdentifier)
                {
                    Value = (productId != null) ? productId as object : DBNull.Value as object
                });

            return sqlCommand;
        }

        public static SqlCommand ToInsertProductOptionSqlCommand(this SqlConnection sqlConnection, ProductOptionEntity productOptionEntity)
        {
            var sqlCommand = new SqlCommand
            {
                CommandText = "[dbo].[psp_InsertProductOption]",
                CommandType = CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlCommand.Parameters.Add(
                new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
                {
                    Value = (productOptionEntity.Id != null || productOptionEntity.Id != Guid.Empty) ? productOptionEntity.Id as object : DBNull.Value as object
                });

            sqlCommand.Parameters.Add(
                new SqlParameter("@ProductId", SqlDbType.UniqueIdentifier)
                {
                    Value = (productOptionEntity.ProductId != null || productOptionEntity.ProductId != Guid.Empty) ? productOptionEntity.ProductId as object : DBNull.Value as object
                });

            sqlCommand.Parameters.Add(
               new SqlParameter("@Name", SqlDbType.VarChar)
               {
                   Value = (!string.IsNullOrEmpty(productOptionEntity.Name)) ? productOptionEntity.Name as object : DBNull.Value as object
               });

            sqlCommand.Parameters.Add(
               new SqlParameter("@Description", SqlDbType.VarChar)
               {
                   Value = (!string.IsNullOrEmpty(productOptionEntity.Description)) ? productOptionEntity.Description as object : DBNull.Value as object
               });

            return sqlCommand;
        }

        public static SqlCommand ToUpdateProductOptionSqlCommand(this SqlConnection sqlConnection, ProductOptionEntity productOptionEntity)
        {
            var sqlCommand = new SqlCommand
            {
                CommandText = "[dbo].[psp_UpdateProductOption]",
                CommandType = CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlCommand.Parameters.Add(
               new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
               {
                   Value = (productOptionEntity.Id != null || productOptionEntity.Id != Guid.Empty) ? productOptionEntity.Id as object : DBNull.Value as object
               });

            sqlCommand.Parameters.Add(
               new SqlParameter("@ProductId", SqlDbType.UniqueIdentifier)
               {
                   Value = (productOptionEntity.ProductId != null || productOptionEntity.ProductId != Guid.Empty) ? productOptionEntity.ProductId as object : DBNull.Value as object
               });

            sqlCommand.Parameters.Add(
               new SqlParameter("@Name", SqlDbType.VarChar)
               {
                   Value = (!string.IsNullOrEmpty(productOptionEntity.Name)) ? productOptionEntity.Name as object : DBNull.Value as object
               });

            sqlCommand.Parameters.Add(
               new SqlParameter("@Description", SqlDbType.VarChar)
               {
                   Value = (!string.IsNullOrEmpty(productOptionEntity.Description)) ? productOptionEntity.Description as object : DBNull.Value as object
               });

            return sqlCommand;
        }

        public static SqlCommand ToDeleteProductOptionSqlCommand(this SqlConnection sqlConnection, Guid id)
        {
            var sqlCommand = new SqlCommand
            {
                CommandText = "[dbo].[psp_DeleteProductOption]",
                CommandType = CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlCommand.Parameters.Add(
                new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
                {
                    Value = (id != null || id != Guid.Empty) ? id as object : DBNull.Value as object
                });

            return sqlCommand;
        }
    }
}
