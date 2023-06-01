using FoodBackend.UseCases.Common.Dtos;
using MediatR;

namespace FoodBackend.UseCases.FoodRecipe.GetFoodRecipeById;

/// <summary>
/// Get food recipe by id with detail information query.
/// </summary>
/// <param name="FoodRecipeId"></param>
public record GetFoodRecipeByIdQuery(Guid FoodRecipeId) : IRequest<DetailFoodRecipeDto>;
