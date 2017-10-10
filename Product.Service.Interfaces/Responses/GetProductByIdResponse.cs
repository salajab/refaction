using Product.Entities;

namespace Product.Service.Interfaces.Responses
{
    public class GetProductByIdResponse : BaseResponse
    {
        public ProductEntity Product { get; set; }
    }
}
