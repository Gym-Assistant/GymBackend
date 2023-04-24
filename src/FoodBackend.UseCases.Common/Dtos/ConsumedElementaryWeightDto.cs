namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Consumed food elementary weight DTO.
/// </summary>
public record ConsumedElementaryWeightDto
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Food recipe.
    /// </summary>
    public LightFoodElementaryDto FoodElementary { get; set; }
    
    /// <summary>
    /// Course meal.
    /// </summary>
    public LightCourseMealDto CourseMeal { get; set; }
    
    /// <summary>
    /// Weight value.
    /// </summary>
    public double Weight { get; set; }
}
