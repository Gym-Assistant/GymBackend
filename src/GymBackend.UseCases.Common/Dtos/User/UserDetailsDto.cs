namespace GymBackend.UseCases.Common.Dtos.User;

/// <summary>
/// User details.
/// </summary>
public class UserDetailsDto : UserDto
{
    /// <summary>
    /// User email.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Last login date time.
    /// </summary>
    public DateTime LastLogin { get; set; }
}
