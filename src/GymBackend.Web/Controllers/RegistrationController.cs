using System.ComponentModel.DataAnnotations;
using GymBackend.UseCases.Users.RegistrationUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymBackend.Web.Controllers;

/// <summary>
/// Authentication controller.
/// </summary>
[ApiController]
[Route("api/register")]
[ApiExplorerSettings(GroupName = "Registration")]
public class RegistrationController
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RegistrationController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Classic registration.
    /// </summary>
    /// <param name="command">Register command.</param>
    /// <param name="cancellationToken">Cancellation token to cancel the request.</param>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task Register([Required] RegisterUserCommand command, CancellationToken cancellationToken)
    {
        await mediator.Send(command, cancellationToken);
    }
}
