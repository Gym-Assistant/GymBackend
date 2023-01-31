namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Light food characteristic DTO with minimum information.
/// </summary>
public record LightFoodCharacteristicDto
{
    /// <summary>
    /// Id of food characteristic.
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Id of food, which owns characteristic.
    /// </summary>
    public Guid FoodId { get; init; }

    /// <summary>
    /// Type of food characteristic id.
    /// </summary>
    public Guid CharacteristicTypeId { get; init; }
    
    /// <summary>
    /// Food characteristic value.
    /// </summary>
    public double Value { get; init; }
}
