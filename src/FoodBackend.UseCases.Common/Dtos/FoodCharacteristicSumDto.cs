namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Food characteristic sum DTO.
/// </summary>
public record FoodCharacteristicSumDto
{
    /// <summary>
    /// Food characteristic type.
    /// </summary>
    public FoodCharacteristicTypeDto FoodCharacteristicType { get; init; }
    
    /// <summary>
    /// Food characteristic sum value.
    /// </summary>
    public double CharacteristicSumValue { get; init; }
}
