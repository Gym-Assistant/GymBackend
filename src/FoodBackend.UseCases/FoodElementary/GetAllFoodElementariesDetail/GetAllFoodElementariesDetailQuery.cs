using FoodBackend.UseCases.Common.Dtos;
using FoodBackend.UseCases.Common.Pagination;
using MediatR;
using Saritasa.Tools.Common.Pagination;

namespace FoodBackend.UseCases.FoodElementary.GetAllFoodElementariesDetail;

/// <summary>
/// Get all food elementaries with detail info query.
/// </summary>
public record GetAllFoodElementariesDetailQuery : PaginationParameters, IRequest<PagedListMetadataDto<DetailFoodElementaryDto>>;
