using System.ComponentModel.DataAnnotations;

namespace GymBackend.Domain.Users;

/// <summary>
/// User characteristic.
/// </summary>
public record UserCharacteristic
{
    /// <summary>
    /// Id.
    /// </summary>
    [Key]
    public Guid Id { get; init; }

    /// <summary>
    /// User id.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// User id.
    /// </summary>
    public User User { get; init; }

    /// <summary>
    /// Name of characteristic.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Characteristic active status.
    /// </summary>
    public bool IsActive { get; init; }

    /// <summary>
    /// Characteristic stamps.
    /// </summary>
    public ICollection<CharacteristicStamp> Values { get; init; }

    /// <summary>
    /// When characteristic created.
    /// </summary>
    public DateTime CreatedAt { get; init; }
}
