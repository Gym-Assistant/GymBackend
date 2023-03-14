using FoodBackend.Domain.MealStuffs;
using GymBackend.Domain.Users;

namespace FoodBackend.Domain.Foodstuffs;

/// <summary>
/// Consumed food recipes weight.
/// </summary>
public record ConsumedRecipeWeight
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
    /// Course meal id.
    /// </summary>
    public Guid CourseMealId { get; set; }
    
    /// <summary>
    /// Course meal.
    /// </summary>
    public CourseMeal CourseMeal { get; set; }
    
    /// <summary>
    /// Weight value.
    /// </summary>
    public double Weight { get; set; }
    
    /// <summary>
    /// User creator id.
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// User creator.
    /// </summary>
    public User User { get; set; }
}
