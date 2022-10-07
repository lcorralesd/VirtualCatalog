using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VirtualCatalog.API.Core.Domain.Interfaces.Repositories;
using VirtualCatalog.API.Infrastructure.Contexts;
using VirtualCatalog.API.Infrastructure.Repositories;

namespace VirtualCatalog.API;

public static class DependencyContainer
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var DB_HOST = "LEGION5";
        var DB_NAME = "VirtualCatalog";
        var DB_SA_PASSWORD = "lcd.654321";
        var connectionString = $"Data Source={DB_HOST};Initial Catalog={DB_NAME};user=sa;Password={DB_SA_PASSWORD}";
        services.AddDbContext<CatalogDbContext>(options => options.UseSqlServer(connectionString));

        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
