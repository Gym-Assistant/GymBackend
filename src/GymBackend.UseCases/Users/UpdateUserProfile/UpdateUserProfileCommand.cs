using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;
using MediatR;

namespace GymBackend.UseCases.Users.UpdateUserProfile;

/// <summary>
/// Update user profile command.
/// </summary>
public record UpdateUserProfileCommand : IRequest
{
    /// <summary>
    /// User identifier.
    /// </summary>
    [JsonIgnore]
    public Guid Id { get; set; }

    /// <summary>
    /// User email.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// First name.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Last name.
    /// </summary>
    public string LastName { get; set; }
}
