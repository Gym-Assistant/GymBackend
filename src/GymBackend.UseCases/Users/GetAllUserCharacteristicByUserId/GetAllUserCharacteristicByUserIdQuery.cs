using GymBackend.UseCases.Common.Dtos.User;
using MediatR;

namespace GymBackend.UseCases.Users.GetAllUserCharacteristicByUserId;

/// <summary>
/// Query to get all user characteristics by user id.
/// </summary>
/// <remarks>
/// This characteristic doesn't contains values.
/// </remarks>
/// <param name="UserId">User id.</param>
public record GetAllUserCharacteristicByUserIdQuery(Guid UserId) : IRequest<IEnumerable<UserCharacteristicLiteDto>>;