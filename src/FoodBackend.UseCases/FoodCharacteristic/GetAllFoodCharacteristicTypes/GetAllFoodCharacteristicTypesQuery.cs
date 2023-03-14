using FoodBackend.UseCases.Common.Dtos;
using GymBackend.UseCases.Common.Pagination;
using MediatR;
using Saritasa.Tools.Common.Pagination;

namespace FoodBackend.UseCases.FoodCharacteristic.GetAllFoodCharacteristicTypes;

/// <summary>
/// Get all food characteristic types query.
/// </summary>
public record GetAllFoodCharacteristicTypesQuery : 
    PageQueryFilter, IRequest<PagedListMetadataDto<LightFoodCharacteristicTypeDto>>;
