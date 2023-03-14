using System.ComponentModel.DataAnnotations;
using MediatR;

namespace FoodBackend.UseCases.FoodRecipe.CreateFoodRecipe;

/// <summary>
/// Create food recipe command.
/// </summary>
public record CreateFoodRecipeCommand : IRequest<Guid>
{
    /// <summary>
    /// Food recipe name.
    /// </summary>
    [Required]
    public string Name { get; init; }
}
