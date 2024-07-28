using Foodway.Application.Contracts.Services;
using Foodway.Application.UseCases.Category.Commands.CreateCategoryCommand;
using Foodway.Domain.Requests.Category;
using Foodway.Shared.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Foodway.Api.Controllers.V1;

[Produces("application/json")]
[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class CategoriesController : BaseApiController
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(IDomainNotification domainNotification, IMediator mediator, ICategoryService categoryService) : base(
        domainNotification,mediator)
    {
        _categoryService = categoryService;
        
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand request)
    {
        return CreateResponse(await Mediator.Send(request, CancellationToken.None));
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return CreateResponse(await _categoryService.GetAllAsync());
    }
}