using Foodway.Application.Contracts.Services;
using Foodway.Domain.Requests.Category;
using Foodway.Shared.Notifications;
using MediatR;

namespace Foodway.Application.UseCases.Category.Commands.CreateCategoryCommand;

public class CreateCategoryHandler : BaseHandler, IRequestHandler<CreateCategoryCommand, string>
{
    private ICategoryService _categoryService;

    public CreateCategoryHandler(IDomainNotification notifications, ICategoryService categoryService) : base(
        notifications)
    {
        _categoryService = categoryService;
    }

    public async Task<string> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        return await _categoryService.CreateAsync(new CreateCategoryRequest() { Name = request.Name });
    }
}