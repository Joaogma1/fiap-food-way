using Foodway.Application.Contracts.Services;
using Foodway.Domain.QueryFilters;
using Foodway.Domain.Requests.Product;
using Foodway.Shared.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Foodway.Api.Controllers.V1;

[Produces("application/json")]
[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class ProductsController : BaseApiController
{
    private readonly IProductService _productService;

    public ProductsController(IDomainNotification domainNotification,IMediator mediator, IProductService productService) : base(
        domainNotification,mediator)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] ProductFilter filter)
    {
        return CreateResponse(await _productService.getPagedAsync(filter));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _productService.GetByIdAsync(id);
        if (result is null) return NotFoundResponse();

        return CreateResponse(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProductRequest req)
    {
        return CreatedResponse(await _productService.CreateAsync(req));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid? id, [FromBody] UpdateProductRequest req)
    {
        req.Id = id;
        var result = await _productService.UpdateAsync(req);
        if (id == null) return CreatedResponse(result);

        return NoContentResponse();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _productService.DeleteAsync(id);
        if (result is false) return NotFoundResponse();

        return NoContent();
    }
}