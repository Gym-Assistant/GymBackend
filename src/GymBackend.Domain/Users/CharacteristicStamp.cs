using System.ComponentModel.DataAnnotations;

namespace GymBackend.Domain.Users;

/// <summary>
/// The value of a characteristic at a certain moment.
/// </summary>
public record CharacteristicStamp
{
    /// <summary>
    /// Id.
    /// </summary>
    [Key]
    public Guid Id { get; init; }

    /// <summary>
    /// Characteristic Id.
    /// </summary>
    public Guid UserCharacteristicId { get; init; }

    /// <summary>
    /// Characteristic.
    /// </summary>
    public UserCharacteristic UserCharacteristic { get; init; }

    /// <summary>
    /// When its characteristic created.
    /// </summary>
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// Value.
    /// </summary>
    public float Value { get; init; }
}
