namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Food recipe DTO with minimum information.
/// </summary>
public record LightFoodRecipeDto
{
    /// <summary>
    /// Food recipe id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Food recipe name.
    /// </summary>
    public string Name { get; init; }
    
    /// <summary>
    /// Id of creator.
    /// </summary>
    public Guid? UserId { get; set; }
}
