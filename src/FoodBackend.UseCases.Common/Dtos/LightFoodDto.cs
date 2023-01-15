namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Food DTO with minimum information.
/// </summary>
public record LightFoodDto
{
    /// <inheritdoc />>
    public Guid Id { get; set; }

    /// <inheritdoc />>
    public string Name { get; set; }
}
