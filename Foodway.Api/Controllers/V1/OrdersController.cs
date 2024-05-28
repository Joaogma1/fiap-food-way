using Foodway.Application.Contracts.Services;
using Foodway.Domain.QueryFilters;
using Foodway.Domain.Requests.Order;
using Foodway.Shared.Notifications;
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

    public OrdersController(IDomainNotification domainNotification, IOrderService orderService) : base(
        domainNotification)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] OrdersFilter filter)
    {
        return CreateResponse(await _orderService.GetPagedAsync(filter));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _orderService.GetByIdAsync(id);

        return CreateResponse(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateOrdersRequest req)
    {
        return CreatedResponse(await _orderService.CreateAsync(req));
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