namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Food recipe DTO with detail information.
/// </summary>
public record DetailFoodRecipeDto
{
    /// <summary>
    /// Food recipe id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Food recipe name.
    /// </summary>
    public string Name { get; init; }
    
    /// <summary>
    /// Id of creator.
    /// </summary>
    public Guid? UserId { get; init; }

    /// <summary>
    /// Ingredients collection.
    /// </summary>
    public ICollection<FoodElementaryWeightDto> Ingredients { get; init; }
}
