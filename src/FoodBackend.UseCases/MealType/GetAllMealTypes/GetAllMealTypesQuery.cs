using FoodBackend.UseCases.Common.Dtos;
using GymBackend.UseCases.Common.Pagination;
using MediatR;
using Saritasa.Tools.Common.Pagination;

namespace FoodBackend.UseCases.MealType.GetAllMealTypes;

/// <summary>
/// Get all meal types query.
/// </summary>
public record GetAllMealTypesQuery(string? SearchBy) : PageQueryFilter, IRequest<PagedListMetadataDto<LightMealTypeDto>>;
