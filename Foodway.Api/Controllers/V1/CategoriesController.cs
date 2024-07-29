using Foodway.Application.UseCases.Category.Commands.CreateCategoryCommand;
using Foodway.Application.UseCases.Category.Queries.ListCategoriesQuery;
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
    public CategoriesController(IDomainNotification domainNotification, IMediator mediator) : base(domainNotification,
        mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand request)
    {
        return CreateResponse(await Mediator.Send(request, CancellationToken.None));
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return CreateResponse(await Mediator.Send(new ListCategoriesQuery(), CancellationToken.None));
    }
}