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
    
    /// <summary>
    /// Id of user who owns meal type.
    /// </summary>
    public Guid? UserId { get; init; }
    
    /// <summary>
    /// Is meal type default statement.
    /// </summary>
    public bool IsDefault { get; init; }
}
