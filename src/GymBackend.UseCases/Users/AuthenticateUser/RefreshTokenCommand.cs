using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GymBackend.UseCases.Users.AuthenticateUser;

/// <summary>
/// Refresh token command.
/// </summary>
public record RefreshTokenCommand : IRequest<TokenModel>
{
    /// <summary>
    /// User token.
    /// </summary>
    [Required]
    public string Token { get; init; }
}
