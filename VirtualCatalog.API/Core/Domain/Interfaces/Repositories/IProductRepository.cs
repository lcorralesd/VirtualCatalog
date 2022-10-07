using VirtualCatalog.API.Core.Domain.Entities;

namespace VirtualCatalog.API.Core.Domain.Interfaces.Repositories;

public interface IProductRepository
{
    void Add(Product product);
    void Update(Product product);
    void Delete(int id);
    //
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
}
