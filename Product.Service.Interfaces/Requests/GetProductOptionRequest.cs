using System;

namespace Product.Service.Interfaces.Requests
{
    public class GetProductOptionRequest
    {
        public Guid ProductId { get; set; }

        public Guid Id { get; set; }        
    }
}
