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
