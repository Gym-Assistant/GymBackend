namespace FoodBackend.Domain.Foodstuffs;

/// <summary>
/// Food elementary weight in recipe.
/// </summary>
public record FoodElementaryWeight
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; set; }
    
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
    
    /// <summary>
    /// Food elementary weight value.
    /// </summary>
    public double Weight { get; set; }
}
