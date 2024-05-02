namespace TeachMeHow.Domain.Contracts
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; protected set; }
    }
}
