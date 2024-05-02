
using TeachMeHow.Domain.Contracts;

namespace TeachMeHow.Domain
{
    public class Cart : AuditableEntity
    {
        public ICollection<CartItem> CartItems { get; set; }
    }
}
