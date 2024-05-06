
using TeachMeHow.Domain.Contracts;

namespace TeachMeHow.Domain
{
    public class Dummy : AuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
    }
}
