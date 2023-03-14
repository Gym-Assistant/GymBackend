using FoodBackend.Domain.Foodstuffs;

namespace FoodBackend.Domain.MealStuffs;

/// <summary>
/// Relation between course meal and food recipe.
/// </summary>
public record CourseMealFoodRecipe
{
    /// <summary>
    /// Course meal id.
    /// </summary>
    public Guid CourseMealId { get; set; }

    /// <summary>
    /// Course meal.
    /// </summary>
    public CourseMeal CourseMeal { get; set; }

    /// <summary>
    /// Food recipe id.
    /// </summary>
    public Guid FoodRecipeId { get; set; }

    /// <summary>
    /// Food recipe.
    /// </summary>
    public FoodRecipe FoodRecipe { get; set; }
}
