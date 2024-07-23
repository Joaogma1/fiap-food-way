using Foodway.Shared.Results;
using MediatR;

namespace Foodway.Application.UseCases.Order.Commands.CreateOrderCommand;

public class CreateOrderCommand : IRequest<string>
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}