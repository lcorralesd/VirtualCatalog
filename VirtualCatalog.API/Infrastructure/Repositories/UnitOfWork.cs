using VirtualCatalog.API.Core.Domain.Interfaces.Repositories;
using VirtualCatalog.API.Infrastructure.Contexts;

namespace VirtualCatalog.API.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly CatalogDbContext _catalogDbContext;

    public UnitOfWork(CatalogDbContext catalogDbContext) => _catalogDbContext = catalogDbContext;

    public async Task SaveChangesAsync(CancellationToken cancellationToken) => 
        await _catalogDbContext.SaveChangesAsync(cancellationToken);
}
