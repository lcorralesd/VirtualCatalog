using Microsoft.EntityFrameworkCore;
using VirtualCatalog.API.Core.Domain.Entities;
using VirtualCatalog.API.Core.Domain.Interfaces.Repositories;
using VirtualCatalog.API.Infrastructure.Contexts;

namespace VirtualCatalog.API.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly CatalogDbContext _catalogDbContext;

    public ProductRepository(CatalogDbContext catalogDbContext) => _catalogDbContext = catalogDbContext;

    public void Add(Product product) =>
        _catalogDbContext.Products.Add(product);

    public void Delete(int id) => throw new NotImplementedException();

    public async Task<IEnumerable<Product>> GetAllAsync() =>
        await _catalogDbContext.Products.ToListAsync();

    public Task<Product> GetByIdAsync(int id) => throw new NotImplementedException();
    public void Update(Product product) => throw new NotImplementedException();
}
