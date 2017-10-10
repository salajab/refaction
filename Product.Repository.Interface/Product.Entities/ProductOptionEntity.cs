using System;

namespace Product.Entities
{
    public class ProductOptionEntity
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
