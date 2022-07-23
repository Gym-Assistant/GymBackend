using MediatR;

namespace GymBackend.UseCases.Users.AddDefaultCharacteristicForUser;

/// <summary>
/// Add default characteristics for some user.
/// </summary>
/// <param name="UserId">User Id.</param>
public record AddDefaultCharacteristicForUserCommand(Guid UserId) : IRequest;
