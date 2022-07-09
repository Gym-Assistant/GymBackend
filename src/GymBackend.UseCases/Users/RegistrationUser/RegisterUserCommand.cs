using MediatR;

namespace GymBackend.UseCases.Users.RegistrationUser;

/// <summary>
/// Command for register user.
/// </summary>
public record RegisterUserCommand : IRequest<Guid>
{
    /// <summary>
    /// Email.
    /// </summary>
    public string Email { get; init; }

    /// <summary>
    /// Password.
    /// </summary>
    public string Password { get; init; }
}
