using Foodway.Domain.QueryFilters;
using Foodway.Domain.Requests.Product;
using Foodway.Domain.ViewModels.Product;
using Foodway.Shared.Pagination;

namespace Foodway.Application.Contracts.Services;

public interface IProductService
{
    Task<string> CreateAsync(CreateProductRequest req);

    Task<string> UpdateAsync(UpdateProductRequest req);

    Task<PagedList<ProductViewModel>> getPagedAsync(ProductFilter filter);
    Task<bool> DeleteAsync(Guid id);
    Task<ProductViewModel?> GetByIdAsync(Guid id);
}