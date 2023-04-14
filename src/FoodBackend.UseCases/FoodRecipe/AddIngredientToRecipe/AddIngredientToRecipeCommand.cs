using System.Text.Json.Serialization;
using MediatR;

namespace FoodBackend.UseCases.FoodRecipe.AddIngredientToRecipe;

public record AddIngredientToRecipeCommand : IRequest<Unit>
{
    /// <summary>
    /// Recipe Id.
    /// </summary>
    [JsonIgnore]
    public Guid FoodRecipeId { get; init; }
    
    /// <summary>
    /// Food elementary id.
    /// </summary>
    public Guid FoodElementaryId { get; init; }
    
    /// <summary>
    /// Food elementary weight value in grams.
    /// </summary>
    public double Weight { get; init; }
}
