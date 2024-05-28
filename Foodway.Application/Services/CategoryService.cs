using FluentValidation;
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
    private readonly IValidator<CreateCategoryRequest> _createCategoryValidator;

    public CategoryService(IDomainNotification notifications, ICategoryRepository categoryRepository,
        IValidator<CreateCategoryRequest> createCategoryValidator) : base(notifications)
    {
        _categoryRepository = categoryRepository;
        _createCategoryValidator = createCategoryValidator;
    }

    public async Task<string> CreateAsync(CreateCategoryRequest req)
    {
        var reqValidation = await _createCategoryValidator.ValidateAsync(req);

        if (!reqValidation.IsValid)
        {
            HandleValidationErrors(reqValidation);
            return "";
        }

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