using Product.Entities;
using System;

namespace Product.Service.Interfaces.Requests
{
    public class AddProductRequest
    {
        public ProductEntity ProductEntity { get; set; }       
    }
}
