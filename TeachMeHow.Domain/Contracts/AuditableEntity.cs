namespace TeachMeHow.Domain.Contracts
{
    public abstract class AuditableEntity : BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedAt { get; set; }

        protected AuditableEntity()
        {
            if (CreatedAt == default)
                CreatedAt = DateTime.UtcNow;

            LastModifiedAt = DateTime.UtcNow;
        }
    }
}
