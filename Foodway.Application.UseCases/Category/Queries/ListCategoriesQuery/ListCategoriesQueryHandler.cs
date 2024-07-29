using Foodway.Application.Contracts.Services;
using Foodway.Domain.ViewModels.Category;
using Foodway.Shared.Notifications;
using MediatR;

namespace Foodway.Application.UseCases.Category.Queries.ListCategoriesQuery;

public class ListCategoriesQueryHandler : BaseHandler,
    IRequestHandler<ListCategoriesQuery, IEnumerable<CategoryViewModel>>
{
    private readonly ICategoryService _categoryService;

    public ListCategoriesQueryHandler(IDomainNotification notifications, ICategoryService categoryService) :
        base(notifications)
    {
        _categoryService = categoryService;
    }

    public Task<IEnumerable<CategoryViewModel>> Handle(ListCategoriesQuery query, CancellationToken cancellationToken)
    {
        return _categoryService.GetAllAsync();
    }
}