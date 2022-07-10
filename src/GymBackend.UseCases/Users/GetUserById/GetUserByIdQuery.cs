using GymBackend.UseCases.Common.Dtos;
using GymBackend.UseCases.Common.Dtos.User;
using MediatR;

namespace GymBackend.UseCases.Users.GetUserById;

/// <summary>
/// Get user details by identifier.
/// </summary>
public record GetUserByIdQuery : IRequest<UserDetailsDto>
{
    /// <summary>
    /// User id.
    /// </summary>
    public Guid UserId { get; init; }
}
