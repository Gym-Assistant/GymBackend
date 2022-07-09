using GymBackend.UseCases.Common.Dtos.Dtos;

namespace GymBackend.UseCases.Users.GetUserById;

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
