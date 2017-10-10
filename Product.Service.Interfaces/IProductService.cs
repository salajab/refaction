using Product.Service.Interfaces.Responses;
using Product.Service.Interfaces.Requests;

namespace Product.Service.Interfaces
{
    public interface IProductService
    {
        GetProductByIdResponse GetProductById(GetProductByIdRequest request);

        GetProductByNameResponse GetProductByName(GetProductByNameRequest request);

        GetProductsResponse GetAllProducts();

        GetProductOptionResponse GetProductOption(GetProductOptionRequest request);

        GetProductOptionsResponse GetProductOptions(GetProductOptionsRequest request);

        AddProductResponse AddProduct(AddProductRequest request);

        AddProductOptionResponse AddProductOption(AddProductOptionRequest request);

        UpdateProductResponse UpdateProduct(UpdateProductRequest request);

        UpdateProductOptionResponse UpdateProductOption(UpdateProductOptionRequest request);

        DeleteProductResponse DeleteProduct(DeleteProductRequest request);

        DeleteProductOptionResponse DeleteProductOption(DeleteProductOptionRequest request);
    }
}
