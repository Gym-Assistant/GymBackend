namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Food elementary weight in recipe DTO.
/// </summary>
public record FoodElementaryWeightDto
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Food recipe id.
    /// </summary>
    public Guid FoodRecipeId { get; set; }
    
    /// <summary>
    /// Food elementary id.
    /// </summary>
    public Guid FoodElementaryId { get; set; }
    
    /// <summary>
    /// Food elementary weight value.
    /// </summary>
    public double Weight { get; set; }
}
