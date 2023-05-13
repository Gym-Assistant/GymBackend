namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Food characteristic type DTO with minimum information.
/// </summary>
public record FoodCharacteristicTypeDto
{
    /// <inheritdoc />
    public Guid Id { get; init; }

    /// <inheritdoc />
    public string Name { get; init; }

    /// <inheritdoc />
    public Guid? UserId { get; init; }
    
    /// <inheritdoc />
    public bool IsDefault { get; init; }
}
