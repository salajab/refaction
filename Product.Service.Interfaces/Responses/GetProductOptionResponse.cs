using Product.Entities;

namespace Product.Service.Interfaces.Responses
{
    public class GetProductOptionResponse : BaseResponse
    {
        public ProductOptionEntity ProductOption { get; set; }
    }
}
