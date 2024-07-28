using Foodway.Application.Contracts.Services;
using Foodway.Domain.Contracts.Repositories;
using Foodway.Domain.Entities;
using Foodway.Domain.Projections;
using Foodway.Domain.Requests.Category;
using Foodway.Domain.ViewModels.Category;
using Foodway.Shared.Notifications;

namespace Foodway.Application.Services;

public class CategoryService : BaseService, ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(IDomainNotification notifications, ICategoryRepository categoryRepository) : base(notifications)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<string> CreateAsync(CreateCategoryRequest req)
    {
        var createdCategory = await _categoryRepository.AddAsync(new Category
        {
            Name = req.Name,
            CreatedBy = "BackOffice",
            LastModifiedBy = "BackOffice"
        });

        await _categoryRepository.SaveChanges();

        return createdCategory.Id.ToString();
    }

    public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
    {
        return await Task.FromResult(_categoryRepository.ListAsNoTracking().ToViewModel());
    }
}