using FoodBackend.UseCases.Common.Dtos;
using MediatR;

namespace FoodBackend.UseCases.FoodCharacteristic.GetFoodCharacteristicById;

/// <summary>
/// Get food characteristic by id query.
/// </summary>
public record GetFoodCharacteristicByIdQuery(Guid FoodCharacteristicId) : IRequest<LightFoodCharacteristicDto>;
