using FoodBackend.UseCases.Common.Dtos;
using FoodBackend.UseCases.Common.Pagination;
using MediatR;
using Saritasa.Tools.Common.Pagination;

namespace FoodBackend.UseCases.FoodElementary.GetAllFoodElementaries;

/// <summary>
/// Get all food elementaries query.
/// </summary>
public record GetAllFoodElementariesQuery : PaginationParameters, IRequest<PagedListMetadataDto<LightFoodElementaryDto>>;
