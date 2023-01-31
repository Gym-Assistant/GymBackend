using MediatR;

namespace FoodBackend.UseCases.FoodCharacteristic.RemoveFoodCharacteristicById;

/// <summary>
/// Remove food characteristic by id.
/// </summary>
public record RemoveFoodCharacteristicByIdCommand(Guid FoodCharacteristicId) : IRequest;
