using MediatR;
using VirtualCatalog.API.Core.Domain.Interfaces.Repositories;

namespace VirtualCatalog.API.Application.Products.GetAll;

public class GetAllProductsQuery : IRequest<List<GetAllProductDTO>>
{

    internal class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<GetAllProductDTO>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository) => _productRepository = productRepository;

        public async Task<List<GetAllProductDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();
            var productsDto = products.Select(p => new GetAllProductDTO
            {
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
            }).ToList();

            return productsDto;
        }
    }
}
