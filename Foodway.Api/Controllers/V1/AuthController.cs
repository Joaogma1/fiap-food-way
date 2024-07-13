using Foodway.Application.UseCases.Auth.Commands.SignInCommand;
using Foodway.Domain.Requests.Auth;
using Foodway.Shared.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Foodway.Api.Controllers.V1;

/// <summary>
///     Represents the authentication controller for handling user authentication and authorization.
/// </summary>
[Produces("application/json")]
[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class AuthController : BaseApiController
{
    public AuthController(IDomainNotification domainNotification, IMediator mediator) : base(domainNotification, mediator)
    {
    }
    /// <summary>
    ///     Initiates the sign-in process for a user.
    /// </summary>
    /// <param name="request">The SignInRequest containing the user credentials.</param>
    /// <returns>
    ///     A Task representing the asynchronous operation. The IActionResult containing the result of the sign-in
    ///     process.
    /// </returns>
    [HttpPost("/login")]
    public async Task<IActionResult> SignIn([FromBody] SignInCommand request)
    {
        return CreateResponse(await Mediator.Send(request,CancellationToken.None));
    }

    /// <summary>
    ///     Refreshes the access token using the refresh token.
    /// </summary>
    /// <param name="request">The request object containing the refresh token.</param>
    /// <returns>An IActionResult representing the result of the refresh token request.</returns>
    [HttpPost("/refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshRequest request)
    {
        return CreateResponse("success");
    }

    /// <summary>
    ///     Changes the password for the current user.
    /// </summary>
    /// <param name="request">The <see cref="ChangePasswordRequest" /> object containing the new password.</param>
    /// <returns>An <see cref="IActionResult" /> representing the result of the operation.</returns>
    [Authorize(Policy = "AllEmployees")]
    [HttpPut("/change-password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
    {
        return NoContentResponse();
    }


}