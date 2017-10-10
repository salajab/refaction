using Product.Entities;
using System;

namespace Product.Service.Interfaces.Requests
{
    public class AddProductOptionRequest
    {
        public ProductOptionEntity ProductOptionEntity { get; set; }       
    }
}
