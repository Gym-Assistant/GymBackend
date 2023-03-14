using MediatR;

namespace FoodBackend.UseCases.FoodRecipe.DeleteFoodRecipeById;

/// <summary>
/// Remove food recipe by id command.
/// </summary>
public record RemoveFoodRecipeByIdCommand(Guid FoodRecipeId) : IRequest;
