using GymBackend.Domain.Users;

namespace GymBackend.UseCases.Common.Dtos.User;

/// <summary>
/// Lite dto for <see cref="UserCharacteristic"/>.
/// This dto doesn't contain collection of characteristic values.
/// </summary>
public record UserCharacteristicLiteDto
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Name of characteristic.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Characteristic active status.
    /// </summary>
    public bool IsActive { get; init; }
}

/// <summary>
/// Dto for <see cref="UserCharacteristic"/>.
/// </summary>
public record UserCharacteristicDto
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Name of characteristic.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Characteristic active status.
    /// </summary>
    public bool IsActive { get; init; }

    /// <summary>
    /// Values of characteristic.
    /// </summary>
    public ICollection<CharacteristicStamp> Values { get; init; }

    /// <summary>
    /// When characteristic created.
    /// </summary>
    public DateTime CreatedAt { get; init; }
}