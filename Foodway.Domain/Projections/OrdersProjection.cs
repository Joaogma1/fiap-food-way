using Foodway.Domain.Entities;
using Foodway.Domain.ViewModels.Order;

namespace Foodway.Domain.Projections;

public static class OrdersProjection
{
    public static IEnumerable<OrderViewModel> ToViewModel(this IEnumerable<Order> query)
    {
        return query.Select(order => new OrderViewModel
        {
            Id = order.Id,
            Client = order.Client?.ToViewModel(),
            OrderStatus = order.OrderStatus,
            Products = order.OrderItems.ToOrderItemViewModel(),
            Total = order.Total,
            OrderCode = order.OrderCode ?? string.Empty,
            PaymentStatus = order.PaymentStatus
        });
    }

    public static IQueryable<OrderViewModel> ToViewModel(this IQueryable<Order> query)
    {
        return query.Select(order => new OrderViewModel
        {
            Client = order.Client.ToViewModel(),
            OrderStatus = order.OrderStatus,
            Products = order.OrderItems.ToOrderItemViewModel(),
            Total = order.Total,
            OrderCode = order.OrderCode ?? string.Empty,
            PaymentStatus = order.PaymentStatus,
            Id = order.Id
        });
    }

    public static OrderViewModel ToViewModel(this Order order)
    {
        return new OrderViewModel()
        {
            Id = order.Id,
            Client = order.Client?.ToViewModel(),
            OrderStatus = order.OrderStatus,
            Products = order.OrderItems.ToOrderItemViewModel(),
            Total = order.Total,
            OrderCode = order.OrderCode ?? string.Empty,
            PaymentStatus = order.PaymentStatus
        };
    }

    public static IEnumerable<OrderItemViewModel> ToOrderItemViewModel(this IEnumerable<OrderItems> query)
    {
        return query.Select(item => new OrderItemViewModel
        {
            Product = item.Product.ToOrderProductViewModel(),
            Quantity = item.Quantity
        });
    }

    public static OrderProductViewModel ToOrderProductViewModel(this Product item)
    {
        return new OrderProductViewModel()
        {
            Id = item.Id,
            Category = item.Category.ToViewModel(),
            Description = item.Description,
            Price = item.Price,
            Name = item.Name
        };
    }
}