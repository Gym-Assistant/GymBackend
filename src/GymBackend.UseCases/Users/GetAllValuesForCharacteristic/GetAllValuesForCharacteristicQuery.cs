using GymBackend.UseCases.Common.Dtos.User;
using MediatR;

namespace GymBackend.UseCases.Users.GetAllValuesForCharacteristic;

/// <summary>
/// Characteristic values by characteristic Id.
/// </summary>
/// <param name="UserId">User Id.</param>
/// <param name="CharacteristicId">Characteristic Id.</param>
public record GetAllValuesForCharacteristicQuery(Guid UserId, Guid CharacteristicId) : IRequest<IEnumerable<CharacteristicStampDto>>;
