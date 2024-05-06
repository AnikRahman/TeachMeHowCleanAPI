
using TeachMeHow.Domain.Contracts;

namespace TeachMeHow.Domain
{
    public class CartItem : AuditableEntity
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }

        public Cart Cart { get; set; }
        public Product Product { get; set; }

  
    }
}
