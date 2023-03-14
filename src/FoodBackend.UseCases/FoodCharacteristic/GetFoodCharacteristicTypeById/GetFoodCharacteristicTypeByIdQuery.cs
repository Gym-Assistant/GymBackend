using FoodBackend.UseCases.Common.Dtos;
using MediatR;

namespace FoodBackend.UseCases.FoodCharacteristic.GetFoodCharacteristicTypeById;

/// <summary>
/// Get food characteristic type by id query.
/// </summary>
public record GetFoodCharacteristicTypeByIdQuery(Guid FoodCharacteristicTypeId) : IRequest<LightFoodCharacteristicTypeDto>;
