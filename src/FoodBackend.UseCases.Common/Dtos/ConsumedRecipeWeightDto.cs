namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Consumed food recipe weight DTO.
/// </summary>
public record ConsumedRecipeWeightDto
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Food elementary.
    /// </summary>
    public LightFoodRecipeDto FoodRecipe { get; set; }

    /// <summary>
    /// Course meal.
    /// </summary>
    public LightCourseMealDto CourseMeal { get; set; }

    /// <summary>
    /// Weight value.
    /// </summary>
    public double Weight { get; set; }
}
