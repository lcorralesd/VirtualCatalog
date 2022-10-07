using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualCatalog.API.Application.Products.Create;
using VirtualCatalog.API.Application.Products.GetAll;

namespace VirtualCatalog.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ISender _sender;

	public ProductsController(ISender sender)
	{
		_sender = sender;
	}

	[HttpGet]
	public async Task<IResult> GetProducts() =>
		Results.Ok(await _sender.Send(new GetAllProductsQuery()));

	[HttpPost]
	public async Task<IResult> CreateProduct(CreateProductCommand command) =>
		Results.Ok(await _sender.Send(command));
}
