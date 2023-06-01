using FoodBackend.UseCases.Common.Dtos;
using GymBackend.UseCases.Common.Pagination;
using MediatR;
using Saritasa.Tools.Common.Pagination;

namespace FoodBackend.UseCases.FoodRecipe.GetAllFoodRecipe;

/// <summary>
/// Get all food recipe with detail information query.
/// </summary>
public record GetAllFoodRecipeQuery(Guid? UserId) : PageQueryFilter, IRequest<PagedListMetadataDto<DetailFoodRecipeDto>>;
