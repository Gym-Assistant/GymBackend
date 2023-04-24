using System.Text.Json.Serialization;
using MediatR;

namespace FoodBackend.UseCases.FoodRecipe.ChangeElementaryWeightInFoodRecipe;

/// <summary>
/// Change food elementary weight in food recipe command.
/// </summary>
public record ChangeElementaryWeightInRecipeCommand : IRequest
{
    /// <summary>
    /// Food recipe id.
    /// </summary>
    [JsonIgnore]
    public Guid FoodRecipeId { get; init; }
    
    /// <summary>
    /// Food elementary id.
    /// </summary>
    [JsonIgnore]
    public Guid FoodElementaryId { get; init; }
    
    /// <summary>
    /// Consumed food elementary weight value.
    /// </summary>
    public double Weight { get; init; }
}
