﻿

namespace TeachMeHow.Application.Persistence.Repository
{
    public interface IReadRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        // Add read-specific methods here
    }
}
