using System;
using System.Data;
using System.Data.SqlClient;
using Product.Entities;

namespace Product.Repository.SQL
{
    public static class ProductExtension
    {
        public static ProductEntity ToProduct(this SqlDataReader value)
        {
            if (!value.HasRows)
                return null;

            ProductEntity entity;
            try
            {
                entity = new ProductEntity
                {
                    Id = (Guid)value["Id"],
                    Name = (value["Name"] != DBNull.Value)
                                    ? value["Name"].ToString()
                                    : null,
                    Description = (value["Description"] != DBNull.Value)
                                    ? value["Description"].ToString()
                                    : null,
                    Price = (decimal)value["Price"],
                    DeliveryPrice = (decimal)value["DeliveryPrice"]
                };
            }
            catch (Exception ex)
            {
                throw new ProviderException("Unexpected exception in ToProduct", ex);
            }

            return entity;
        }

        public static SqlCommand ToReadProductSqlCommand(this SqlConnection sqlConnection, Guid? id, string name)
        {
            var sqlCommand = new SqlCommand
            {
                CommandText = "[dbo].[psp_GetProduct]",
                CommandType = CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlCommand.Parameters.Add(
                new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
                {
                    Value = (id != null) ? id as object : DBNull.Value as object
                });

            sqlCommand.Parameters.Add(
               new SqlParameter("@Name", SqlDbType.VarChar)
               {
                   Value = (!string.IsNullOrEmpty(name)) ? name as object : DBNull.Value as object
               });

            return sqlCommand;
        }

        public static SqlCommand ToInsertProductSqlCommand(this SqlConnection sqlConnection, ProductEntity productEntity)
        {
            var sqlCommand = new SqlCommand
            {
                CommandText = "[dbo].[psp_InsertProduct]",
                CommandType = CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlCommand.Parameters.Add(
                new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
                {
                    Value = (productEntity.Id != null || productEntity.Id != Guid.Empty) ? productEntity.Id as object : DBNull.Value as object
                });

            sqlCommand.Parameters.Add(
               new SqlParameter("@Name", SqlDbType.VarChar)
               {
                   Value = (!string.IsNullOrEmpty(productEntity.Name)) ? productEntity.Name as object : DBNull.Value as object
               });

            sqlCommand.Parameters.Add(
               new SqlParameter("@Description", SqlDbType.VarChar)
               {
                   Value = (!string.IsNullOrEmpty(productEntity.Description)) ? productEntity.Description as object : DBNull.Value as object
               });

            sqlCommand.Parameters.Add(
               new SqlParameter("@Price", SqlDbType.Decimal)
               {
                   Value = productEntity.Price
               });

            sqlCommand.Parameters.Add(
               new SqlParameter("@DeliveryPrice", SqlDbType.Decimal)
               {
                   Value = productEntity.DeliveryPrice
               });

            return sqlCommand;
        }

        public static SqlCommand ToUpdateProductSqlCommand(this SqlConnection sqlConnection, ProductEntity productEntity)
        {
            var sqlCommand = new SqlCommand
            {
                CommandText = "[dbo].[psp_UpdateProduct]",
                CommandType = CommandType.StoredProcedure,
                Connection = sqlConnection
            };

            sqlCommand.Parameters.Add(
               new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
               {
                   Value = (productEntity.Id != null || productEntity.Id != Guid.Empty) ? productEntity.Id as object : DBNull.Value as object
               });

            sqlCommand.Parameters.Add(
               new SqlParameter("@Name", SqlDbType.VarChar)
               {
                   Value = (!string.IsNullOrEmpty(productEntity.Name)) ? productEntity.Name as object : DBNull.Value as object
               });

            sqlCommand.Parameters.Add(
               new SqlParameter("@Description", SqlDbType.VarChar)
               {
                   Value = (!string.IsNullOrEmpty(productEntity.Description)) ? productEntity.Description as object : DBNull.Value as object
               });

            sqlCommand.Parameters.Add(
               new SqlParameter("@Price", SqlDbType.Decimal)
               {
                   Value = productEntity.Price
               });

            sqlCommand.Parameters.Add(
               new SqlParameter("@DeliveryPrice", SqlDbType.Decimal)
               {
                   Value = productEntity.DeliveryPrice
               });

            return sqlCommand;
        }

        public static SqlCommand ToDeleteProductSqlCommand(this SqlConnection sqlConnection, Guid id)
        {
            var sqlCommand = new SqlCommand
            {
                CommandText = "[dbo].[psp_DeleteProduct]",
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
