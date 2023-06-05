namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Food recipe characteristic sum DTO.
/// </summary>
public record FoodRecipeCharacteristicSumDto
{
    /// <summary>
    /// Food characteristic type.
    /// </summary>
    public FoodCharacteristicTypeDto FoodCharacteristicType { get; init; }
    
    /// <summary>
    /// Food characteristic sum value in current recipe.
    /// </summary>
    public double CharacteristicSumValue { get; init; }
}
