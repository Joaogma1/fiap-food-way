using Foodway.Domain.Requests.Category;
using Foodway.Domain.ViewModels.Category;

namespace Foodway.Application.Contracts.Services;

public interface ICategoryService
{
    Task<string> CreateAsync(CreateCategoryRequest req);
    Task<IEnumerable<CategoryViewModel>> GetAllAsync();
}