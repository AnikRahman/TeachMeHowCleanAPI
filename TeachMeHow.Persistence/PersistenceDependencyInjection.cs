using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeachMeHow.Application.Persistence.Repository;
using TeachMeHow.Application.Persistence;
using TeachMeHow.Persistence.Context;
using TeachMeHow.Persistence.Repository;
using TeachMeHow.Persistence.Services;

namespace TeachMeHow.Persistence
{
    public static class PersistenceDependencyInjection
    {
        public static void RegisterPersistenceServices(IServiceCollection services, IConfiguration configuration)
        {
           
         
            // Register repositories
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            // Register unit of work
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Register application services
            services.AddScoped<DummyService>();

        }
    }
}
