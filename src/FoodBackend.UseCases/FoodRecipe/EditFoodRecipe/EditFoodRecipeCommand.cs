using System.Text.Json.Serialization;
using MediatR;

namespace FoodBackend.UseCases.FoodRecipe.EditFoodRecipe;

/// <summary>
/// Edit food recipe command.
/// </summary>
public record EditFoodRecipeCommand: IRequest<Unit>
{
    /// <summary>
    /// Id.
    /// </summary>
    [JsonIgnore]
    public Guid Id { get; init; }

    /// <summary>
    /// Food recipe name.
    /// </summary>
    public string Name { get; init; }
}
