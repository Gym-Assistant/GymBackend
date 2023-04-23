using MediatR;

namespace FoodBackend.UseCases.FoodRecipe.RemoveIngredientFromRecipe;

public record RemoveIngredientFromRecipeCommand(Guid FoodRecipeId, Guid FoodElementaryId) : IRequest;
