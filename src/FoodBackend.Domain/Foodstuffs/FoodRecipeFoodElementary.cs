namespace FoodBackend.Domain.Foodstuffs;

/// <summary>
/// Relation between Food elementary and food recipes.
/// </summary>
public record FoodRecipeFoodElementary
{
    /// <summary>
    /// Food recipe id.
    /// </summary>
    public Guid FoodRecipeId { get; set; }

    /// <summary>
    /// Food recipe.
    /// </summary>
    public FoodRecipe FoodRecipe { get; set; }

    /// <summary>
    /// Food elementary id.
    /// </summary>
    public Guid FoodElementaryId { get; set; }

    /// <summary>
    /// Food elementary.
    /// </summary>
    public FoodElementary FoodElementary { get; set; }
}
