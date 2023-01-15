using FoodBackend.UseCases.Common.Dtos;
using FoodBackend.UseCases.Common.Pagination;
using MediatR;
using Saritasa.Tools.Common.Pagination;

namespace FoodBackend.UseCases.Food.GetAllFood;

/// <summary>
/// Get all food query.
/// </summary>
public record GetAllFoodQuery : PaginationParameters, IRequest<PagedListMetadataDto<LightFoodDto>>;
