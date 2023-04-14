using MediatR;

namespace FoodBackend.UseCases.FoodCharacteristic.RemoveFoodCharacteristicTypeById;

/// <summary>
/// Remove food characteristic type by id.
/// </summary>
public record RemoveFoodCharacteristicTypeByIdCommand(Guid FoodCharacteristicTypeId) : IRequest<Unit>;
