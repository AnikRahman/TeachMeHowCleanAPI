﻿

using TeachMeHow.Domain.Contracts;

namespace TeachMeHow.Domain
{
    public class Category : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
