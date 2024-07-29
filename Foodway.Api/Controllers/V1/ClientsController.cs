using Foodway.Application.Contracts.Services;
using Foodway.Application.UseCases.Client.Commands.CreateClientCommand;
using Foodway.Application.UseCases.Client.Queries.GetClientByCpfQuery;
using Foodway.Domain.Requests.Clients;
using Foodway.Shared.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Foodway.Api.Controllers.V1;

[Produces("application/json")]
[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class ClientsController : BaseApiController
{
    public ClientsController(IDomainNotification domainNotification, IMediator mediator) : base(
        domainNotification, mediator)
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateClient([FromBody] CreateClientCommand request)
    {
        return CreateResponse(await Mediator.Send(request, CancellationToken.None));
    }

    [HttpGet("{cpf}")]
    public async Task<IActionResult> GetClientByCpf(string cpf)
    {
        var result = await Mediator.Send(new GetClientByCpfQuery(cpf));
        if (result is null) return NotFoundResponse();

        return CreateResponse(result);
    }
}