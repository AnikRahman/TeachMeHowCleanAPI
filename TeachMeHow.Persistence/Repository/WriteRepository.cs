
using TeachMeHow.Application.Persistence;
using TeachMeHow.Persistence.Context;

namespace TeachMeHow.Persistence.Repository
{
    public class WriteRepository<TEntity> : RepositoryBase<TEntity>, IWriteRepository<TEntity> where TEntity : class
    {
        public WriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
