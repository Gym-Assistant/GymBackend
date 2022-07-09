using Microsoft.AspNetCore.Identity;

namespace GymBackend.Domain.Users;

/// <summary>
/// Custom application identity role.
/// </summary>
public class AppIdentityRole : IdentityRole<Guid>
{
}
