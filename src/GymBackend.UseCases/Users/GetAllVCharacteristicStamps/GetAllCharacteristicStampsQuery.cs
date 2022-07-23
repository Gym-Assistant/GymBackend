using GymBackend.UseCases.Common.Dtos.User;
using MediatR;

namespace GymBackend.UseCases.Users.GetAllVCharacteristicStamps;

/// <summary>
/// Characteristic values by characteristic Id.
/// </summary>
/// <param name="UserId">User Id.</param>
/// <param name="CharacteristicId">Characteristic Id.</param>
public record GetAllCharacteristicStampsQuery(Guid UserId, Guid CharacteristicId) : IRequest<IEnumerable<CharacteristicStampDto>>;
