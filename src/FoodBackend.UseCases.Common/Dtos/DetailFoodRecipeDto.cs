namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Food recipe DTO with detail information.
/// </summary>
public record DetailFoodRecipeDto
{
    /// <summary>
    /// Food recipe id.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Food recipe name.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Id of creator.
    /// </summary>
    public Guid? UserId { get; set; }

    /// <summary>
    /// Ingredients collection.
    /// </summary>
    public ICollection<DetailFoodElementaryDto> Ingredients { get; set; }
    
    /// <summary>
    /// Ingredient weights collection.
    /// </summary>
    public ICollection<FoodElementaryWeightDto> IngredientWeights { get; set; }
}
