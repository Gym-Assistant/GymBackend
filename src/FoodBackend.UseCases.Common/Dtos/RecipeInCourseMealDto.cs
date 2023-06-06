namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Consumed food recipe in course meal DTO.
/// </summary>
public record RecipeInCourseMealDto
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Food recipe.
    /// </summary>
    public DetailFoodRecipeDto FoodRecipe { get; init; }

    /// <summary>
    /// Food recipe in course meal weight value.
    /// </summary>
    public double RecipeInMealWeight { get; init; }
}
