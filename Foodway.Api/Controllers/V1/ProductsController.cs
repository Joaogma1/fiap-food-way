using Foodway.Domain.QueryFilters;
using Foodway.Application.UseCases.Product.Commands.CreateProductCommand;
using Foodway.Application.UseCases.Product.Commands.DeleteProductCommand;
using Foodway.Application.UseCases.Product.Commands.UpdateProductCommand;
using Foodway.Application.UseCases.Product.Queries.GetProductByIdQuery;
using Foodway.Application.UseCases.Product.Queries.ListAllProductsPaginatedQuery;
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
    public ProductsController(IDomainNotification
        domainNotification, IMediator mediator) : base(
        domainNotification, mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] ProductFilter filter)
    {
        return CreateResponse(await Mediator.Send(new ListAllProductsPaginatedQuery(filter)));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await Mediator.Send(new GetProductByIdQuery(id));
        if (result is null) return NotFoundResponse();

        return CreateResponse(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProductCommand req)
    {
        return CreateResponse(await Mediator.Send(req, CancellationToken.None));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put([FromQuery] Guid id, [FromBody] UpsertProductCommand req)
    {
        req.Id = id;
        var result = await Mediator.Send(req);
        if (string.IsNullOrEmpty(result)) return CreatedResponse(result);
        return NoContentResponse();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await Mediator.Send(new DeleteProductCommand(id));
        if (result is false) return NotFoundResponse();

        return NoContent();
    }
}