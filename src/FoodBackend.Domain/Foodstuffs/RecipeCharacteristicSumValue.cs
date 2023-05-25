using System.ComponentModel.DataAnnotations;

namespace FoodBackend.Domain.Foodstuffs;

/// <summary>
/// Recipe to characteristic relation.
/// </summary>
public record RecipeCharacteristicSumValue
{
    /// <summary>
    /// Recipe to characteristic relation id.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Id of food recipe, which owns characteristic.
    /// </summary>
    public Guid FoodRecipeId { get; set; }

    /// <summary>
    /// Food recipe, which owns characteristic.
    /// </summary>
    public FoodRecipe FoodRecipe { get; set; }

    /// <summary>
    /// Type of food characteristic id.
    /// </summary>
    public Guid CharacteristicTypeId { get; set; }
    
    /// <summary>
    /// Type of food characteristic.
    /// </summary>
    public FoodCharacteristicType CharacteristicType { get; set; }
    
    /// <summary>
    /// Food characteristic value.
    /// </summary>
    public double Value { get; set; }
}
