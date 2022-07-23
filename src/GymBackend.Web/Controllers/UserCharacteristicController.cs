using GymBackend.UseCases.Common.Dtos.User;
using GymBackend.UseCases.Users.ActivateCharacteristicById;
using GymBackend.UseCases.Users.AddNewCharacteristicValue;
using GymBackend.UseCases.Users.CreateUserCharacteristic;
using GymBackend.UseCases.Users.DeleteCharacteristicValuesById;
using GymBackend.UseCases.Users.GetAllUserCharacteristicByUserId;
using GymBackend.UseCases.Users.GetAllValuesForCharacteristic;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymBackend.Web.Controllers;

/// <summary>
/// User profile controller.
/// </summary>
[ApiController]
[Route("api/profile/{userId:guid}/characteristic")]
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
    [HttpGet]
    public async Task<IEnumerable<UserCharacteristicLiteDto>> GetAllCharacteristic(Guid userId, CancellationToken cancellationToken) =>
        await mediator.Send(new GetAllUserCharacteristicByUserIdQuery(userId), cancellationToken);

    /// <summary>
    /// Create characteristics for user.
    /// </summary>
    /// <param name="command">Command.</param>
    /// <param name="userId">User id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>User profile.</returns>
    [HttpPost]
    [Authorize]
    public async Task CreateUserCharacteristic(CreateUserCharacteristicCommand command, Guid userId, CancellationToken cancellationToken)
    {
        command = command with
        {
            UserId = userId
        };
        await mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Update characteristic status.
    /// </summary>
    /// <param name="userId">User id.</param>
    /// <param name="characteristicId">Characteristic Id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>User profile.</returns>
    [HttpPut("{characteristicId}")]
    [Authorize]
    public async Task UpdateCharacteristicStatus(Guid userId, Guid characteristicId, CancellationToken cancellationToken)
    {
        var command = new ChangeActivateStatusCharacteristicByIdCommand()
        {
            UserId = userId,
            CharacteristicId = characteristicId
        };
        await mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Add new characteristic stamp.
    /// </summary>
    /// <param name="userId">User id.</param>
    /// <param name="characteristicId">Characteristic Id.</param>
    /// <param name="command">Command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpPost("{characteristicId}")]
    [Authorize]
    public async Task<Guid> AddNewValue(Guid userId, Guid characteristicId, AddNewCharacteristicValueCommand command, CancellationToken cancellationToken)
    {
        command = command with
        {
            UserId = userId,
            CharacteristicId = characteristicId
        };
        return await mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// Get all characteristic stamps.
    /// </summary>
    /// <param name="userId">User id.</param>
    /// <param name="characteristicId">Characteristic Id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpGet("{characteristicId}")]
    [Authorize]
    public async Task<IEnumerable<CharacteristicStampDto>> GetAllValuesForCharacteristic(Guid userId, Guid characteristicId, CancellationToken cancellationToken)
    {
        var query = new GetAllValuesForCharacteristicQuery(UserId: userId, CharacteristicId: characteristicId);
        return await mediator.Send(query, cancellationToken);
    }


    /// <summary>
    /// Delete characteristic stamp.
    /// </summary>
    /// <param name="userId">User id.</param>
    /// <param name="characteristicId">Characteristic Id.</param>
    /// <param name="characteristicStampId">Characteristic value Id.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    [HttpDelete("{characteristicId}/stamp/{characteristicStampId}")]
    [Authorize]
    public async Task DeleteValuesForCharacteristic(Guid userId, Guid characteristicId, Guid characteristicStampId, CancellationToken cancellationToken)
    {
        var command = new DeleteCharacteristicValuesByIdCommand(userId, characteristicId, characteristicStampId);
        await mediator.Send(command, cancellationToken);
    }
}
