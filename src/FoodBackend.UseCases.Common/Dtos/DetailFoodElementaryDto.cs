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
    /// Id of creator.
    /// </summary>
    public Guid? UserId { get; init; }
    
    /// <summary>
    /// Is food elementary default statement.
    /// </summary>
    public bool IsDefault { get; init; }
    
    /// <summary>
    /// Food elementary characteristics.
    /// </summary>
    public ICollection<DetailFoodCharacteristicDto> Characteristics { get; init; }
}
