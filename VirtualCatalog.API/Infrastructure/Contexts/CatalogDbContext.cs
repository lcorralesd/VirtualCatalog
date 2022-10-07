using Microsoft.EntityFrameworkCore;
using VirtualCatalog.API.Core.Domain.Entities;

namespace VirtualCatalog.API.Infrastructure.Contexts;

public class CatalogDbContext : DbContext
{
	public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
	{
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
        var DB_HOST = "LEGION5";
        var DB_NAME = "VirtualCatalog";
        var DB_SA_PASSWORD = "lcd.654321";
        var connectionString = $"Data Source={DB_HOST};Initial Catalog={DB_NAME};user=sa;Password={DB_SA_PASSWORD}";
        optionsBuilder.UseSqlServer(connectionString);
	}

	public DbSet<Product> Products => Set<Product>();
}
