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
    public Guid Id { get; set; }

    /// <summary>
    /// Characteristic Id.
    /// </summary>
    public Guid UserCharacteristicId { get; set; }

    /// <summary>
    /// Characteristic.
    /// </summary>
    public UserCharacteristic UserCharacteristic { get; set; }

    /// <summary>
    /// When its characteristic created.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Value.
    /// </summary>
    public double Value { get; set; }
}
