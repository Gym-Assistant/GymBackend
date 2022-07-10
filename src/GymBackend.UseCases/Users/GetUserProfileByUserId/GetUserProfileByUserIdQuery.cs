using GymBackend.UseCases.Common.Dtos.User;
using MediatR;

namespace GymBackend.UseCases.Users.GetUserProfileByUserId;

/// <summary>
/// Get user profile by user id.
/// </summary>
/// <param name="UserId">UserId</param>
public record GetUserProfileByUserIdQuery(Guid UserId) : IRequest<UserProfileDto>;
