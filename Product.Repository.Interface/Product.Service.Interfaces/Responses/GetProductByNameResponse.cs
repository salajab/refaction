using Product.Entities;

namespace Product.Service.Interfaces.Responses
{
    public class GetProductByNameResponse : BaseResponse
    {
        public ProductEntity Product { get; set; }
    }
}
