namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Food elementary DTO with detail information.
/// </summary>
public record DetailFoodElementaryDto
{
    /// <summary>
    /// Food elementary id.
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Food elementary name.
    /// </summary>
    public string Name { get; init; }
    
    /// <summary>
    /// Food elementary characteristics.
    /// </summary>
    public ICollection<DetailFoodCharacteristicDto> Characteristics { get; init; }
}
