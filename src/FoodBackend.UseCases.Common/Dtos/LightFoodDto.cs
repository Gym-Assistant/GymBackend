namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Food light DTO.
/// </summary>
public record LightFoodDto
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Food name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Food callories value.
    /// </summary>
    public int? Callories { get; set; }
}
