namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Food characteristic DTO with detail information.
/// </summary>
public record DetailFoodCharacteristicDto
{
    /// <summary>
    /// Food characteristic name.
    /// </summary>
    public string CharacteristicName { get; init; }
    
    /// <summary>
    /// Food characteristic value.
    /// </summary>
    public double Value { get; init; }
}
