namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Light meal type DTO with minimum information.
/// </summary>
public record LightMealTypeDto
{
    /// <summary>
    /// Meal type id.
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Name of meal type.
    /// </summary>
    public string Name { get; init; }
}
