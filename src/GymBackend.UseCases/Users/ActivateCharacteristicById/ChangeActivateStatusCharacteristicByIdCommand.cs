using MediatR;

namespace GymBackend.UseCases.Users.ActivateCharacteristicById;

/// <summary>
/// Change activate status of a characteristic by id.
/// </summary>
public record ChangeActivateStatusCharacteristicByIdCommand : IRequest
{
    /// <summary>
    /// User Id.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// Characteristic Id.
    /// </summary>
    public Guid CharacteristicId { get; init; }
}
