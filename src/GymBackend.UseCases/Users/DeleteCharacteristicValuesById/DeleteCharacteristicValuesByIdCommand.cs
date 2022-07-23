using MediatR;

namespace GymBackend.UseCases.Users.DeleteCharacteristicValuesById;

/// <summary>
/// Delete characteristic value by id.
/// </summary>
/// <param name="UserId">UserId.</param>
/// <param name="CharacteristicId">Characteristic Id.</param>
/// <param name="CharacteristicStampId">Characteristic Stamp Id.</param>
public record DeleteCharacteristicValuesByIdCommand(Guid UserId, Guid CharacteristicId, Guid CharacteristicStampId) : IRequest;
