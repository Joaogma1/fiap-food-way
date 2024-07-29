using Foodway.Application.Contracts.Services;
using Foodway.Domain.QueryFilters;
using Foodway.Domain.Requests.Order;
using Foodway.Application.UseCases.Order.Commands.CreateOrderCommand;
using Foodway.Application.UseCases.Order.Commands.UpdateOrderStatusCommand;
using Foodway.Application.UseCases.Order.Queries.GetOrderByIdQuery;
using Foodway.Application.UseCases.Order.Queries.ListAllOrdersFilteredPaginatedQuery;
using Foodway.Application.UseCases.Order.Queries.ListAllOrdersPaginatedQuery;
using Foodway.Shared.Notifications;
using Foodway.Shared.Pagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Foodway.Api.Controllers.V1;

[Produces("application/json")]
[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class OrdersController : BaseApiController
{
    public OrdersController(IDomainNotification domainNotification, IMediator mediator) : base(
        domainNotification, mediator)
    {
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] OrdersFilter filter)
    {
        return CreateResponse(await Mediator.Send(new ListAllOrdersPaginatedQuery(filter)));
    }

    [HttpGet("all-filtered")]
    public async Task<IActionResult> GetAllFiltered([FromQuery] Pagination pagination,
        [FromQuery] int? lastOrderId = null)
    {
        return CreateResponse(await Mediator.Send(new ListAllOrdersFilteredPaginatedQuery(pagination, lastOrderId)));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return CreateResponse(await Mediator.Send(new GetOrderByIdQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateOrderCommand req)
    {
        return CreateResponse(await Mediator.Send(req, CancellationToken.None));
    }

    [HttpPatch("status/{orderId}")]
    public async Task<IActionResult> Put(Guid orderId, [FromBody] UpdateOrderStatusCommand req)
    {
        req.OrderId = orderId;
        return await Mediator.Send(req) ? NoContentResponse() : NotFound();
    }
}