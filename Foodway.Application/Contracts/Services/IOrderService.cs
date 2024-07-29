using Foodway.Domain.QueryFilters;
using Foodway.Domain.Requests.Order;
using Foodway.Domain.ViewModels.Order;
using Foodway.Shared.Pagination;

namespace Foodway.Application.Contracts.Services;

public interface IOrderService
{
    Task<PagedList<OrderViewModel>> GetPagedAsync(OrdersFilter filter);
    Task<OrderViewModel> GetByIdAsync(Guid id);
    Task<string?> CreateAsync(CreateOrdersRequest req);
    Task<bool> UpdateOrderStatusAsync(UpdateOrderStatusRequest req);
    Task<PagedList<OrderViewModel>> GetAllFilteredOrdersAsync(Pagination pagination, int? lastOrderId = null);
}