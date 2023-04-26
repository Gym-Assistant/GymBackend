using FoodBackend.UseCases.Common.Dtos;
using MediatR;

namespace FoodBackend.UseCases.FoodRecipe.GetFoodRecipeByIdDetail;

/// <summary>
/// Get food recipe by id with detail information query.
/// </summary>
/// <param name="FoodRecipeId"></param>
public record GetFoodRecipeByIdDetailQuery(Guid FoodRecipeId) : IRequest<DetailFoodRecipeDto>;
