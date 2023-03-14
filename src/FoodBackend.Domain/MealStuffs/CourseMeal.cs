using System.ComponentModel.DataAnnotations;
using FoodBackend.Domain.Foodstuffs;
using GymBackend.Domain.Users;

namespace FoodBackend.Domain.MealStuffs;

/// <summary>
/// Course meal.
/// </summary>
public record CourseMeal
{
    /// <summary>
    /// Course meal id.
    /// </summary>
    [Key]
    public Guid Id { get; set; }
    
    /// <summary>
    /// Id of user who created course meal.
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// User who created course meal.
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// Consumed food elementaries.
    /// </summary>
    public ICollection<FoodElementary> ConsumedFoodElementaries { get; set; }
    
    /// <summary>
    /// Consumed food elementaries weight.
    /// </summary>
    public ICollection<ConsumedElementaryWeight> ConsumedElementaryWeights { get; set; }
    
    /// <summary>
    /// Consumed food recipes.
    /// </summary>
    public ICollection<FoodRecipe> ConsumedFoodRecipes { get; set; }
    
    /// <summary>
    /// Consumed food recipes weight.
    /// </summary>
    public ICollection<ConsumedRecipeWeight> ConsumedRecipeWeights { get; set; }

    /// <summary>
    /// Time when meal was created.
    /// </summary>
    public TimeOnly CreatedAt { get; set; }
    
    /// <summary>
    /// Meal type id.
    /// </summary>
    public Guid MealTypeId { get; set; }
    
    /// <summary>
    /// Meal type.
    /// </summary>
    public MealType MealType { get; set; }
}
