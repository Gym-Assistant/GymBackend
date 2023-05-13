namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Consumed food recipe weight DTO.
/// </summary>
public record ConsumedRecipeWeightDto
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Food recipe.
    /// </summary>
    public LightFoodRecipeDto FoodRecipe { get; init; }

    /// <summary>
    /// Course meal.
    /// </summary>
    public LightCourseMealDto CourseMeal { get; init; }

    /// <summary>
    /// Weight value.
    /// </summary>
    public double Weight { get; init; }
}
