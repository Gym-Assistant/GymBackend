namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Food elementary weight in recipe DTO.
/// </summary>
public record FoodElementaryInRecipeDto
{
    /// <summary>
    /// Food elementary with characteristics.
    /// </summary>
    public DetailFoodElementaryDto FoodElementary { get; init; }
    
    /// <summary>
    /// Food elementary weight value.
    /// </summary>
    public double ElementaryWeight { get; init; }
}
