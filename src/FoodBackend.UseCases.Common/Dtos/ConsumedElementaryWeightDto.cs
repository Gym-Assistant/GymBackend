namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Consumed food elementary weight DTO.
/// </summary>
public record ConsumedElementaryWeightDto
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Food recipe.
    /// </summary>
    public LightFoodElementaryDto FoodElementary { get; init; }
    
    /// <summary>
    /// Course meal.
    /// </summary>
    public LightCourseMealDto CourseMeal { get; init; }
    
    /// <summary>
    /// Weight value.
    /// </summary>
    public double Weight { get; init; }
}
