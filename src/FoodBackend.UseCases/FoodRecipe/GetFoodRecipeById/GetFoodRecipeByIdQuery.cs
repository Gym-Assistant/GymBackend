using FoodBackend.UseCases.Common.Dtos;
using MediatR;

namespace FoodBackend.UseCases.FoodRecipe.GetFoodRecipeById;

/// <summary>
/// Get food recipe by id query.
/// </summary>
/// <param name="FoodRecipeId"></param>
public record GetFoodRecipeByIdQuery(Guid FoodRecipeId) : IRequest<LightFoodRecipeDto>;
