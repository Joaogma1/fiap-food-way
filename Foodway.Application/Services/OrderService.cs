using FluentValidation;
using Foodway.Application.Contracts.Services;
using Foodway.Domain.Contracts.Repositories;
using Foodway.Domain.Entities;
using Foodway.Domain.Helpers;
using Foodway.Domain.Projections;
using Foodway.Domain.QueryFilters;
using Foodway.Domain.Requests.Order;
using Foodway.Domain.ViewModels.Order;
using Foodway.Shared.Enums;
using Foodway.Shared.Helpers;
using Foodway.Shared.Notifications;
using Foodway.Shared.Pagination;
using Microsoft.EntityFrameworkCore;

namespace Foodway.Application.Services;

public class OrderService : BaseService, IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    public OrderService(IDomainNotification notifications, IOrderRepository orderRepository,
        IProductRepository productRepository) : base(notifications)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    public async Task<PagedList<OrderViewModel>> GetPagedAsync(OrdersFilter filter)
    {
        var joins = new IncludeHelper<Order>()
            .Include(x => x.OrderItems)
            .Include(x => x.OrderItems.Select(y => y.Product))
            .Include(x => x.OrderItems.Select(y => y.Product.Stock))
            .Include(x => x.OrderItems.Select(y => y.Product.Category));

        if (filter.ClientId is not null) joins.Include(x => x.Client);

        var where = _orderRepository.Where(filter);
        var total = await _orderRepository.CountAsync(where);
        var items = (await _orderRepository.ListAsNoTrackingAsync(
            where, filter.PageIndex, filter.PageSize, includes: joins.Includes
        )).ToViewModel().ToList();

        return new PagedList<OrderViewModel>(items, total, filter.PageSize);
    }

    public async Task<PagedList<OrderViewModel>> GetAllFilteredOrdersAsync(Pagination pagination,
        int? lastOrderId = null)
    {
        var joins = new IncludeHelper<Order>()
            .Include(x => x.Client)
            .Include(x => x.OrderItems)
            .Include(x => x.OrderItems.Select(y => y.Product))
            .Include(x => x.OrderItems.Select(y => y.Product.Stock))
            .Include(x => x.OrderItems.Select(y => y.Product.Category))
            .Includes;

        var query = _orderRepository.ListAsNoTracking().AsQueryable();

        query = query.Where(o => o.OrderStatus != OrderStatus.Done && o.OrderStatus != OrderStatus.Cancelled);

        query = query.OrderBy(o => o.OrderStatus == OrderStatus.ReadyForPickUp ? 1 :
                o.OrderStatus == OrderStatus.Preparing ? 2 :
                o.OrderStatus == OrderStatus.WaitingApproval ? 3 : 4)
            .ThenBy(o => o.CreatedAt);

        var total = await query.CountAsync();
        var paginatedOrders = await query.Skip((pagination.PageIndex - 1) * pagination.PageSize)
            .Take(pagination.PageSize).ToListAsync();

        var items = paginatedOrders.ToViewModel().ToList();

        return new PagedList<OrderViewModel>(items, total, pagination.PageSize);
    }

    public async Task<OrderViewModel> GetByIdAsync(Guid id)
    {
        var joins = new IncludeHelper<Order>()
            .Include(x => x.Client)
            .Include(x => x.OrderItems)
            .Include(x => x.OrderItems.Select(y => y.Product))
            .Include(x => x.OrderItems.Select(y => y.Product.Stock))
            .Include(x => x.OrderItems.Select(y => y.Product.Category))
            .Includes;
        var result = await _orderRepository.FindAsync(x => x.Id == id, joins);
        return result.ToViewModel();
    }

    public async Task<string?> CreateAsync(CreateOrdersRequest req)
    {
        var order = await _orderRepository.AddAsync(new Order
        {
            ClientId = req.ClientId,
            OrderCode = StringGeneratorHelper.RandomCode(),
            CreatedBy = "Checkout",
            LastModifiedBy = "Checkout"
        });

        await _orderRepository.SaveChanges();

        try
        {
            var joins = new IncludeHelper<Product>()
                .Include(x => x.Stock)
                .Includes;

            var notAvailableProducts = (await _productRepository.ListAsNoTrackingAsync(
                x => x.Stock.QuantityInStock == 0, includes: joins)).ToList();

            if (req.Items.Any(x =>
                    notAvailableProducts.Any(y => y.Id == x.ProductId && y.Stock.QuantityInStock < x.Quantity)))
            {
                foreach (var product in notAvailableProducts)
                    Notifications.Handle($"{product.Id.ToString()}-missing",
                        $"Product: {product.Name} is not available");

                return null;
            }

            foreach (var item in req.Items)
            {
                order.OrderItems.Add(new OrderItems
                {
                    ProductId = item.ProductId,
                    OrderId = order.Id,
                    Quantity = item.Quantity
                });

                var itemInDb = await _productRepository.FindAsync(x => x.Id == item.ProductId, joins);
                if (itemInDb is null)
                {
                    Notifications.Handle($"{item.ProductId.ToString()}-missing",
                        $"Product: {item.ProductId} is not available");
                    continue;
                }

                itemInDb.Stock.QuantityInStock -= item.Quantity;
                _productRepository.Modify(itemInDb);
            }

            if (Notifications.HasNotifications()) throw new Exception("Unable to Save Order");
            await _orderRepository.SaveChanges();
            return order.Id.ToString();
        }
        catch (Exception e)
        {
            order.OrderStatus = OrderStatus.Cancelled;
            await _orderRepository.SaveChanges();
            Notifications.Handle("EntityError", "Unable to process Order");
            return order.Id.ToString();
        }
    }

    public async Task<bool> UpdateOrderStatusAsync(UpdateOrderStatusRequest req)
    {
        var order = await _orderRepository.FindAsync(x => x.Id == req.OrderId);
        if (order is null) return false;

        if (req.PaymentStatus > order.PaymentStatus)
        {
            order.PaymentStatus = req.PaymentStatus;
            _orderRepository.Modify(order);
            await _orderRepository.SaveChanges();
        }

        if (order.PaymentStatus == PaymentStatus.Approved && req.OrderStatus > order.OrderStatus)
        {
            order.OrderStatus = req.OrderStatus;
            _orderRepository.Modify(order);
            await _orderRepository.SaveChanges();
            return true;
        }

        Notifications.Handle("Entity Error", "Was not possible to update Status");
        return false;
    }
}