using GymBackend.Domain.Users;

namespace GymBackend.UseCases.Common.Dtos.User;

/// <summary>
/// Dto for <see cref="CharacteristicStamp"/>.
/// </summary>
public record CharacteristicStampDto
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Characteristic Id.
    /// </summary>
    public Guid UserCharacteristicId { get; init; }

    /// <summary>
    /// Characteristic.
    /// </summary>
    public UserCharacteristicLiteDto UserCharacteristic { get; init; }

    /// <summary>
    /// When its characteristic created.
    /// </summary>
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// Value.
    /// </summary>
    public double Value { get; init; }
}
