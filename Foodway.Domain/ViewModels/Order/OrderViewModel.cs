using Foodway.Domain.ViewModels.Category;
using Foodway.Domain.ViewModels.Clients;
using Foodway.Shared.Enums;
using Foodway.Shared.Extensions;

namespace Foodway.Domain.ViewModels.Order;

public class OrderViewModel
{
    public Guid Id { get; set; }

    public ClientsViewModel? Client { get; set; }

    public IEnumerable<OrderItemViewModel> Products { get; set; } = new List<OrderItemViewModel>();

    public OrderStatus OrderStatus { get; set; }

    public string OrderStatusDescription => OrderStatus.Description() ?? string.Empty;
    public PaymentStatus PaymentStatus { get; set; }

    public string PaymentStatusDescription => PaymentStatus.Description() ?? string.Empty;


    public string? OrderCode { get; set; }

    public decimal Total { get; set; }
}

public class OrderItemViewModel
{
    public OrderProductViewModel Product { get; set; }
    public int Quantity { get; set; }
}

public class OrderProductViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public CategoryViewModel Category { get; set; }
}