namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Food elementary DTO with minimum information.
/// </summary>
public record LightFoodElementaryDto
{
    /// <summary>
    /// Food elementary id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Food elementary name.
    /// </summary>
    public string Name { get; init; } 
}
