using Microsoft.AspNetCore.Identity;

namespace GymBackend.Domain.Users.Entities;

/// <summary>
/// Custom application identity role.
/// </summary>
public class AppIdentityRole : IdentityRole<Guid>
{
}
