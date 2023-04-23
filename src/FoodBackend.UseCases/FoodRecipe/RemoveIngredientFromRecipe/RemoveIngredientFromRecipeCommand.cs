using MediatR;

namespace FoodBackend.UseCases.FoodRecipe.RemoveIngredientFromRecipe;

/// <summary>
/// Remove food elementary from recipe command.
/// </summary>
/// <param name="FoodRecipeId">Food recipe id.</param>
/// <param name="FoodElementaryId">Food elementary id.</param>
public record RemoveIngredientFromRecipeCommand(Guid FoodRecipeId, Guid FoodElementaryId) : IRequest;
