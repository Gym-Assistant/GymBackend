using System.ComponentModel.DataAnnotations;
using FoodBackend.Domain.MealStuffs;
using GymBackend.Domain.Users;

namespace FoodBackend.Domain.Foodstuffs;

/// <summary>
/// Food recipe entity.
/// </summary>
public record FoodRecipe
{
    /// <summary>
    /// Food id.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Food name.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Id of creator.
    /// </summary>
    public Guid? UserId { get; set; }
    
    /// <summary>
    /// User creator.
    /// </summary>
    public User? User { get; set; }
    
    /// <summary>
    /// Is food default statement.
    /// </summary>
    public bool IsDefault { get; set; }
    
    /// <summary>
    /// Ingredients collection.
    /// </summary>
    public ICollection<FoodElementary> Ingredients { get; set; }
    
    /// <summary>
    /// Ingredient weights collection.
    /// </summary>
    public ICollection<FoodElementaryWeight> IngredientWeights { get; set; }

    /// <summary>
    /// Food recipe characteristics summary value.
    /// </summary>
    public ICollection<RecipeCharacteristicSumValue> CharacteristicValuesSum { get; set; }

    /// <summary>
    /// Related course meals.
    /// </summary>
    public ICollection<CourseMeal> CourseMeals { get; set; }
}
