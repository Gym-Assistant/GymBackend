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
    public Guid Id { get; set; }

    /// <summary>
    /// User id.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// User id.
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// Name of characteristic.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Characteristic active status.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Characteristic stamps.
    /// </summary>
    public ICollection<CharacteristicStamp> Values { get; set; }

    /// <summary>
    /// When characteristic created.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}
