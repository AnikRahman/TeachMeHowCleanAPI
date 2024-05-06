
using TeachMeHow.Domain.Contracts;

namespace TeachMeHow.Domain
{
    public class Cart : AuditableEntity
    {
        public bool IsActive { get; set; }
      
        public ICollection<CartItem> CartItems { get; set; }
    }
}
