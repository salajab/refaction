using Product.Entities;
using System.Collections.Generic;

namespace Product.Service.Interfaces.Responses
{
    public class GetProductOptionsResponse : BaseResponse
    {
        public IList<ProductOptionEntity> ProductOptions { get; set; }
    }
}
