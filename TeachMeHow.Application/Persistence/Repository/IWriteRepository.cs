
namespace TeachMeHow.Application.Persistence
{
    public interface IWriteRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        // Add write-specific methods here
    }
}
