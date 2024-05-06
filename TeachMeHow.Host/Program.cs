using Microsoft.EntityFrameworkCore;
using TeachMeHow.Application.Persistence.Repository;
using TeachMeHow.Application.Persistence;
using TeachMeHow.Persistence.Context;
using TeachMeHow.Persistence.DatabaseSettings;
using TeachMeHow.Persistence;
using TeachMeHow.Persistence.Services;
using TeachMeHow.Persistence.Repository;
using TeachMeHow.Infrastructure.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Read MSSQLSettings from appsettings.json
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("Configurations/mssql.json")
    .Build();

var mssqlSettings = configuration.GetSection("MSSQLSettings").Get<MSSQLSettings>();

// Register MSSQLSettings as a singleton
builder.Services.AddSingleton(mssqlSettings);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        mssqlSettings.ConnectionString,
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.MigrationsAssembly("Migrators.MSSQL");
            // Add other configuration options if needed
        });
});

// Register repositories in DI container
builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
builder.Services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));

// Register services
builder.Services.AddScoped<DummyService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); // Register UnitOfWork


MapsterSettings.ConfigureMappings();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
