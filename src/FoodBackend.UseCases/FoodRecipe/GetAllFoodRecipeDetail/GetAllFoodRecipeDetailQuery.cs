using FoodBackend.UseCases.Common.Dtos;
using GymBackend.UseCases.Common.Pagination;
using MediatR;
using Saritasa.Tools.Common.Pagination;

namespace FoodBackend.UseCases.FoodRecipe.GetAllFoodRecipeDetail;

/// <summary>
/// Get all food recipe with detail information query.
/// </summary>
public record GetAllFoodRecipeDetailQuery : PageQueryFilter, IRequest<PagedListMetadataDto<DetailFoodRecipeDto>>;
