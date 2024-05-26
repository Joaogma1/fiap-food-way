using Foodway.Shared.Notifications;
using Foodway.Shared.Results;
using Microsoft.AspNetCore.Mvc;

namespace Foodway.Api.Controllers;

public class BaseApiController : ControllerBase
{
    private readonly IDomainNotification _domainNotification;

    public BaseApiController(IDomainNotification domainNotification)
    {
        _domainNotification = domainNotification;
    }

    [NonAction]
    public IActionResult CreateResponse()
    {
        if (!_domainNotification.HasNotifications()) return Ok(EnvelopResult.Ok());
        return BadRequest(EnvelopResult.Fail(_domainNotification.Notify()));
    }

    [NonAction]
    public IActionResult CreateResponse<T>(T? data = default)
    {
        if (!_domainNotification.HasNotifications()) return Ok(EnvelopDataResult<T>.Ok(data!));
        return BadRequest(EnvelopResult.Fail(_domainNotification.Notify()));
    }

    [NonAction]
    public IActionResult CreatedResponse(string? url = "")
    {
        if (!_domainNotification.HasNotifications()) return Created(url, EnvelopResult.Ok());
        return BadRequest(EnvelopResult.Fail(_domainNotification.Notify()));
    }

    [NonAction]
    public IActionResult CreatedResponse<T>(T? data = default, string url = "")
    {
        if (!_domainNotification.HasNotifications()) return Created(url, EnvelopDataResult<T>.Ok(data!));
        return BadRequest(EnvelopResult.Fail(_domainNotification.Notify()));
    }

    [NonAction]
    public IActionResult NotFoundResponse()
    {
        if (_domainNotification.HasNotifications()) return BadRequest(EnvelopResult.Fail(_domainNotification.Notify()));
        _domainNotification.Dispose();
        _domainNotification.Handle(new Notification("Entity Error", "Not Found"));
        return new NotFoundObjectResult(EnvelopResult.Fail(_domainNotification.Notify()));
    }

    [NonAction]
    public IActionResult UnprocessableResponse()
    {
        if (_domainNotification.HasNotifications()) _domainNotification.Dispose();

        _domainNotification.Handle(new Notification("Entity Error", "Unprocessable Entity"));

        return UnprocessableEntity(EnvelopResult.Fail(_domainNotification.Notify()));
    }

    [NonAction]
    public IActionResult UnauthorizedResponse()
    {
        if (_domainNotification.HasNotifications()) _domainNotification.Dispose();

        _domainNotification.Handle(new Notification("Unauthorized"));

        return new ObjectResult(EnvelopResult.Fail(_domainNotification.Notify()))
        {
            StatusCode = 401
        };
    }

    [NonAction]
    public IActionResult ForbiddenResponse(string? errorMessage = null)
    {
        if (_domainNotification.HasNotifications()) _domainNotification.Dispose();

        _domainNotification.Handle(new Notification("Entity Error", errorMessage ?? "Forbidden"));

        return new ObjectResult(EnvelopResult.Fail(_domainNotification.Notify()))
        {
            StatusCode = 403
        };
    }

    [NonAction]
    public IActionResult NoContentResponse()
    {
        if (!_domainNotification.HasNotifications()) return NoContent();
        return BadRequest(EnvelopResult.Fail(_domainNotification.Notify()));
    }
}