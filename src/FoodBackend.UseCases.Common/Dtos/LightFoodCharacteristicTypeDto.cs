namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Food characteristic type DTO with minimum information.
/// </summary>
public record LightFoodCharacteristicTypeDto
{
    /// <inheritdoc />
    public Guid Id { get; init; }

    /// <inheritdoc />
    public string Name { get; init; }
}
