using FoodBackend.UseCases.Common.Dtos;
using GymBackend.UseCases.Common.Pagination;
using MediatR;
using Saritasa.Tools.Common.Pagination;

namespace FoodBackend.UseCases.Food.GetAllFoods;

/// <summary>
/// Get all foods query.
/// </summary>
public record GetAllFoodsQuery : PageQueryFilter, IRequest<PagedListMetadataDto<LightFoodDto>>;
