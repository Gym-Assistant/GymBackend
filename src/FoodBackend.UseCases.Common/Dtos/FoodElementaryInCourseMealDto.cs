namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Consumed food elementary in course meal DTO.
/// </summary>
public record FoodElementaryInCourseMealDto
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Food elementary.
    /// </summary>
    public DetailFoodElementaryDto FoodElementary { get; init; }
    
    /// <summary>
    /// Food elementary in course meal weight value.
    /// </summary>
    public double ElementaryInMealWeight { get; init; }
}
