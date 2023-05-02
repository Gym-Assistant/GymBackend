using FoodBackend.UseCases.Common.Dtos;
using GymBackend.UseCases.Common.Pagination;
using MediatR;
using Saritasa.Tools.Common.Pagination;

namespace FoodBackend.UseCases.FoodCharacteristic.GetAllFoodCharacteristicTypes;

/// <summary>
/// Get all food characteristic types query.
/// </summary>
/// <param name="UserId">Filter characteristic types for current user.</param>
public record GetAllFoodCharacteristicTypesQuery(Guid? UserId) : 
    PageQueryFilter, IRequest<PagedListMetadataDto<FoodCharacteristicTypeDto>>;
