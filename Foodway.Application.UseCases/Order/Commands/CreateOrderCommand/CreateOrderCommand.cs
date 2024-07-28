using Foodway.Domain.Requests.Order;
using Foodway.Shared.Results;
using MediatR;

namespace Foodway.Application.UseCases.Order.Commands.CreateOrderCommand;

public class CreateOrderCommand : IRequest<string>
{
    public Guid? ClientId { get; set; }
    public IEnumerable<OrderItem> Items { get; set; } = new List<OrderItem>();
}