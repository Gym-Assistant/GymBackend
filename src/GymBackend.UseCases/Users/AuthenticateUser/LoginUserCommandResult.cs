namespace GymBackend.UseCases.Users.AuthenticateUser;

/// <summary>
/// Represents user login attempt to system.
/// </summary>
public class LoginUserCommandResult
{
    /// <summary>
    /// Logged user id (if success).
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// New refresh token.
    /// </summary>
    public TokenModel TokenModel { get; set; }
}
