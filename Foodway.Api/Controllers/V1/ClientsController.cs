using Foodway.Application.Contracts.Services;
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
    private readonly IClientsService _clientsService;
    public ClientsController(IDomainNotification domainNotification, IMediator mediator, IClientsService clientsService) : base(
        domainNotification,mediator)
    {
        _clientsService = clientsService;
    }
    [HttpPost]
    public async Task<IActionResult> CreateClient([FromBody] CreateClientRequest request)
    {
        return CreatedResponse(await _clientsService.CreateAsync(request));
    }

    [HttpGet("{cpf}")]
    public async Task<IActionResult> GetClientByCPF(string cpf)
    {
        var result = await _clientsService.GetByCPFAsync(cpf);
        if (result is null) return NotFoundResponse();

        return CreateResponse(result);
    }
}