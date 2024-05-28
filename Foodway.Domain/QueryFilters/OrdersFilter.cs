using Foodway.Shared.Enums;
using Foodway.Shared.Pagination;

namespace Foodway.Domain.QueryFilters;

public class OrdersFilter : Pagination
{
    public Guid? ClientId { get; set; }

    public string? Code { get; set; }

    public OrderStatus? OrderStatus { get; set; }

    public PaymentStatus? PaymentStatus { get; set; }
}