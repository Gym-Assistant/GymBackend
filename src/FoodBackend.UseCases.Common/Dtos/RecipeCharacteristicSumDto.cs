namespace FoodBackend.UseCases.Common.Dtos;

/// <summary>
/// Recipe to characteristic relation DTO.
/// </summary>
public record RecipeCharacteristicSumDto
{
    /// <summary>
    /// Recipe to characteristic relation id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Id of food recipe, which owns characteristic.
    /// </summary>
    public Guid FoodRecipeId { get; init; }

    /// <summary>
    /// Type of food characteristic id.
    /// </summary>
    public Guid CharacteristicTypeId { get; init; }
    
    /// <summary>
    /// Characteristic type name.
    /// </summary>
    public string CharacteristicName { get; init; }
    
    /// <summary>
    /// Food characteristic value.
    /// </summary>
    public double Value { get; set; }
}
