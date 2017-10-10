using Product.Entities;
using System.Collections.Generic;

namespace Product.Service.Interfaces.Responses
{
    public class GetProductsResponse : BaseResponse
    {
       public IList<ProductEntity> Products { get; set; }
    }
}
