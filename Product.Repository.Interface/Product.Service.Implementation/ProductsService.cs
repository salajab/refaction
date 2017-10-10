using Product.Service.Interfaces;
using System;
using Product.Service.Interfaces.Requests;
using Product.Service.Interfaces.Responses;
using System.Collections.Generic;
using log4net;
using Product.Repository.Interfaces;

namespace Product.Service.Implementation
{
    public class ProductService : IProductService
    {
        protected static ILog Logger = LogManager.GetLogger(typeof(ProductService));

        protected IProductRepository Repository;

        public ProductService(IProductRepository repository)
        {
            Repository = repository;
        }

        public AddProductResponse AddProduct(AddProductRequest request)
        {
            var response = new AddProductResponse { Errors = new List<Error>() };

            try
            {
                Repository.AddProduct(request.ProductEntity);
                response.Message = "Product added successfully!";
            }
            catch (Exception ex)
            {
                response.Errors.Add(
                    new Error
                    {
                        CustomisedMessage = "Unable to add  product",
                        StackTrace = ex.StackTrace,
                        SystemMessage = ex.Message,
                    });

                Logger.Fatal(request);
                Logger.Fatal(response, ex);
            }

            return response;
        }

        public AddProductOptionResponse AddProductOption(AddProductOptionRequest request)
        {
            var response = new AddProductOptionResponse { Errors = new List<Error>() };
            try
            {
                Repository.AddProductOption(request.ProductOptionEntity);
                response.Message = "Product option added successfully!";
            }
            catch (Exception ex)
            {
                response.Errors.Add(
                    new Error
                    {
                        CustomisedMessage = "Unable to add  product option",
                        StackTrace = ex.StackTrace,
                        SystemMessage = ex.Message,
                    });

                Logger.Fatal(request);
                Logger.Fatal(response, ex);
            }
            return response;
        }

        public DeleteProductResponse DeleteProduct(DeleteProductRequest request)
        {
            var response = new DeleteProductResponse { Errors = new List<Error>() };
            try
            {
                Repository.DeleteProduct(request.Id);
                response.Message = "Product deleted successfully!";
            }
            catch (Exception ex)
            {
                response.Errors.Add(
                    new Error
                    {
                        CustomisedMessage = "Unable to delete  product",
                        StackTrace = ex.StackTrace,
                        SystemMessage = ex.Message,
                    });

                Logger.Fatal(request);
                Logger.Fatal(response, ex);
            }
            return response;
        }

        public DeleteProductOptionResponse DeleteProductOption(DeleteProductOptionRequest request)
        {
            var response = new DeleteProductOptionResponse { Errors = new List<Error>() };
            try
            {
                Repository.DeleteProductOption(request.Id);
                response.Message = "Product option deleted successfully!";
            }
            catch (Exception ex)
            {
                response.Errors.Add(
                    new Error
                    {
                        CustomisedMessage = "Unable to delete  product option",
                        StackTrace = ex.StackTrace,
                        SystemMessage = ex.Message,
                    });

                Logger.Fatal(request);
                Logger.Fatal(response, ex);
            }
            return response;
        }

        public GetProductsResponse GetAllProducts()
        {
            var response = new GetProductsResponse { Errors = new List<Error>() };
            try
            {
                response.Products = Repository.GetAllProducts();
            }
            catch (Exception ex)
            {
                response.Errors.Add(
                    new Error
                    {
                        CustomisedMessage = "Unable to get all products",
                        StackTrace = ex.StackTrace,
                        SystemMessage = ex.Message,
                    });

                Logger.Fatal(response, ex);
            }
            return response;
        }

        public GetProductByIdResponse GetProductById(GetProductByIdRequest request)
        {
            var response = new GetProductByIdResponse { Errors = new List<Error>() };
            try
            {
                response.Product = Repository.GetProductById(request.Id);
            }
            catch (Exception ex)
            {
                response.Errors.Add(
                    new Error
                    {
                        CustomisedMessage = "Unable to get product by id",
                        StackTrace = ex.StackTrace,
                        SystemMessage = ex.Message,
                    });

                Logger.Fatal(request);
                Logger.Fatal(response, ex);
            }
            return response;
        }

        public GetProductByNameResponse GetProductByName(GetProductByNameRequest request)
        {
            var response = new GetProductByNameResponse { Errors = new List<Error>() };
            try
            {
                response.Product = Repository.GetProductByName(request.Name);
            }
            catch (Exception ex)
            {
                response.Errors.Add(
                    new Error
                    {
                        CustomisedMessage = "Unable to get product by name",
                        StackTrace = ex.StackTrace,
                        SystemMessage = ex.Message,
                    });

                Logger.Fatal(request);
                Logger.Fatal(response, ex);
            }
            return response;
        }

        public GetProductOptionResponse GetProductOption(GetProductOptionRequest request)
        {
            var response = new GetProductOptionResponse { Errors = new List<Error>() };
            try
            {
                response.ProductOption = Repository.GetProductOption(request.Id);
            }
            catch (Exception ex)
            {
                response.Errors.Add(
                    new Error
                    {
                        CustomisedMessage = "Unable to get product option",
                        StackTrace = ex.StackTrace,
                        SystemMessage = ex.Message,
                    });

                Logger.Fatal(request);
                Logger.Fatal(response, ex);
            }
            return response;
        }

        public GetProductOptionsResponse GetProductOptions(GetProductOptionsRequest request)
        {
            var response = new GetProductOptionsResponse { Errors = new List<Error>() };
            try
            {
                response.ProductOptions = Repository.GetProductOptions(request.ProductId);
            }
            catch (Exception ex)
            {
                response.Errors.Add(
                    new Error
                    {
                        CustomisedMessage = "Unable to get product options",
                        StackTrace = ex.StackTrace,
                        SystemMessage = ex.Message,
                    });

                Logger.Fatal(request);
                Logger.Fatal(response, ex);
            }
            return response;
        }

        public UpdateProductResponse UpdateProduct(UpdateProductRequest request)
        {
            var response = new UpdateProductResponse { Errors = new List<Error>() };
            try
            {
                Repository.UpdateProduct(request.ProductEntity);
                response.Message = "Product updated successfully!";
            }
            catch (Exception ex)
            {
                response.Errors.Add(
                    new Error
                    {
                        CustomisedMessage = "Unable to update product",
                        StackTrace = ex.StackTrace,
                        SystemMessage = ex.Message,
                    });

                Logger.Fatal(request);
                Logger.Fatal(response, ex);
            }
            return response;
        }

        public UpdateProductOptionResponse UpdateProductOption(UpdateProductOptionRequest request)
        {
            var response = new UpdateProductOptionResponse { Errors = new List<Error>() };
            try
            {
                Repository.UpdateProductOption(request.ProductOptionEntity);
                response.Message = "Product option updated successfully!";
            }
            catch (Exception ex)
            {
                response.Errors.Add(
                    new Error
                    {
                        CustomisedMessage = "Unable to update product option",
                        StackTrace = ex.StackTrace,
                        SystemMessage = ex.Message,
                    });

                Logger.Fatal(request);
                Logger.Fatal(response, ex);
            }
            return response;
        }
    }
}
