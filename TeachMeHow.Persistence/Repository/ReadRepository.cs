
using TeachMeHow.Application.Persistence.Repository;
using TeachMeHow.Persistence.Context;

namespace TeachMeHow.Persistence.Repository
{
    public class ReadRepository<TEntity> : RepositoryBase<TEntity>, IReadRepository<TEntity> where TEntity : class
    {
        public ReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
