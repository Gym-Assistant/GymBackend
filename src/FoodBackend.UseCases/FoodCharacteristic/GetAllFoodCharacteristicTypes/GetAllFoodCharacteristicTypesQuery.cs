using FoodBackend.UseCases.Common.Dtos;
using FoodBackend.UseCases.Common.Pagination;
using MediatR;
using Saritasa.Tools.Common.Pagination;

namespace FoodBackend.UseCases.FoodCharacteristic.GetAllFoodCharacteristicTypes;

/// <summary>
/// Get all food characteristic types query.
/// </summary>
public record GetAllFoodCharacteristicTypesQuery : 
    PaginationParameters, IRequest<PagedListMetadataDto<LightFoodCharacteristicTypeDto>>;
