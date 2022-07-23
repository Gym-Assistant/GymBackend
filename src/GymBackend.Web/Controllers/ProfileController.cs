using GymBackend.UseCases.Common.Dtos.User;
using GymBackend.UseCases.Users.GetUserProfileByUserId;
using GymBackend.UseCases.Users.UpdateUserProfile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymBackend.Web.Controllers;

/// <summary>
/// User profile controller.
/// </summary>
[ApiController]
[Route("api/profile")]
[ApiExplorerSettings(GroupName = "profile")]
public class ProfileController : ControllerBase
{
    private readonly IMediator mediator;

    /// <summary>
    /// Constructor.
    /// </summary>
    public ProfileController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    /// <summary>
    /// Get user profile.
    /// </summary>
    /// <param name="userId">User id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>User profile.</returns>
    [HttpGet("{userId}")]
    public async Task<UserProfileDto> GetUserProfileById(Guid userId, CancellationToken cancellationToken) =>
        await mediator.Send(new GetUserProfileByUserIdQuery(userId), cancellationToken);

    /// <summary>
    /// Update user profile.
    /// </summary>
    /// <param name="command">Update user profile command.</param>
    /// <param name="userId">User id..</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPut("{userId}")]
    [Authorize]
    public async Task UpdateProfile(UpdateUserProfileCommand command, Guid userId, CancellationToken cancellationToken)
    {
        command = command with
        {
            Id = userId
        };

        await mediator.Send(command, cancellationToken);
    }
}
