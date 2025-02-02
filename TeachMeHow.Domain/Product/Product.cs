﻿
using TeachMeHow.Domain.Contracts;

namespace TeachMeHow.Domain
{
    public class Product : AuditableEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }

        public Category Category { get; set; }
    }

}
