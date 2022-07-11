using GymBackend.UseCases.Common.Dtos.User;
using GymBackend.UseCases.Users.CreateUserCharacteristic;
using GymBackend.UseCases.Users.GetAllUserCharacteristicByUserId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymBackend.Web.Controllers;

/// <summary>
/// User profile controller.
/// </summary>
[ApiController]
[Route("api/profile/characteristic")]
[ApiExplorerSettings(GroupName = "profile")]
public class UserCharacteristicController : ControllerBase
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public UserCharacteristicController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Get all user characteristics.
    /// </summary>
    /// <param name="userId">User id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>User profile.</returns>
    [HttpGet("{userId}")]
    public async Task<IEnumerable<UserCharacteristicLiteDto>> GetAll(Guid userId, CancellationToken cancellationToken) =>
        await mediator.Send(new GetAllUserCharacteristicByUserIdQuery(userId), cancellationToken);

    /// <summary>
    /// Create characteristics for user.
    /// </summary>
    /// <param name="command">Command.</param>
    /// <param name="userId">User id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>User profile.</returns>
    [HttpPost("{userId}")]
    [Authorize]
    public async Task CreateUserCharacteristic(
        CreateUserCharacteristicCommand command, Guid userId, CancellationToken cancellationToken)
    {
        command = command with
        {
            UserId = userId
        };
        await mediator.Send(command, cancellationToken);
    }
}