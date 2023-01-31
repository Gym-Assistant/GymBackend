using MediatR;

namespace FoodBackend.UseCases.FoodCharacteristic.CreateFoodCharacteristicType;

/// <summary>
/// Create food characteristic type id.
/// </summary>
public record CreateFoodCharacteristicTypeCommand : IRequest<Guid>
{
    /// <summary>
    /// Name of food characteristic type.
    /// </summary>
    public string Name { get; init; }
}
