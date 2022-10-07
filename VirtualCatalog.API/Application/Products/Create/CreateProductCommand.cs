using MediatR;
using VirtualCatalog.API.Core.Domain.Entities;
using VirtualCatalog.API.Core.Domain.Interfaces.Repositories;

namespace VirtualCatalog.API.Application.Products.Create;

public class CreateProductCommand : IRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }


    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product 
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
            };

            _productRepository.Add(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}
