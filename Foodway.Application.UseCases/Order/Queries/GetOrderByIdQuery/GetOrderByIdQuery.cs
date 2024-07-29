using Foodway.Domain.ViewModels.Order;
using MediatR;

namespace Foodway.Application.UseCases.Order.Queries.GetOrderByIdQuery;

public class GetOrderByIdQuery(Guid id) : IRequest<OrderViewModel?>
{
    public Guid Id { get; private set; } = id;
}