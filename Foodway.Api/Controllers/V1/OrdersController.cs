using Foodway.Application.Contracts.Services;
using Foodway.Domain.QueryFilters;
using Foodway.Domain.Requests.Order;
using Foodway.Application.UseCases.Order.Commands.CreateOrderCommand;
using Foodway.Shared.Notifications;
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
    private readonly IOrderService _orderService;

    public OrdersController(IDomainNotification domainNotification,IMediator mediator, IOrderService orderService) : base(
        domainNotification, mediator)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] OrdersFilter filter)
    {
        return CreateResponse(await _orderService.GetPagedAsync(filter));
    }

    [HttpGet("all-filtered")]
    public async Task<IActionResult> GetAllFiltered(int pageIndex = 1, int pageSize = 10, int? lastOrderId = null)
    {
        var orders = await _orderService.GetAllFilteredOrdersAsync(pageIndex, pageSize, lastOrderId);
        return CreateResponse(orders);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _orderService.GetByIdAsync(id);

        return CreateResponse(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateOrderCommand req)
    {
        return CreateResponse(await Mediator.Send(req, CancellationToken.None));
    }

    [HttpPatch("status/{orderId}")]
    public async Task<IActionResult> Put(Guid orderId, [FromBody] UpdateOrderStatusRequest req)
    {
        req.OrderId = orderId;
        var result = await _orderService.UpdateOrderStatusAsync(req);
        if (result) return NoContentResponse();
        return NotFound();
    }
}