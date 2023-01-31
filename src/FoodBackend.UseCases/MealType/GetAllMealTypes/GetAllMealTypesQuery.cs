using FoodBackend.UseCases.Common.Dtos;
using FoodBackend.UseCases.Common.Pagination;
using MediatR;
using Saritasa.Tools.Common.Pagination;

namespace FoodBackend.UseCases.MealType.GetAllMealTypes;

/// <summary>
/// Get all meal types query.
/// </summary>
public record GetAllMealTypesQuery : 
    PaginationParameters, IRequest<PagedListMetadataDto<LightMealTypeDto>>;
