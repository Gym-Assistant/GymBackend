using MediatR;

namespace FoodBackend.UseCases.FoodCharacteristic.CreateFoodCharacteristic;

/// <summary>
/// Create food characteristic id.
/// </summary>
public record CreateFoodCharacteristicCommand : IRequest<Guid>
{
    /// <summary>
    /// Id of food elementary, which owns characteristic.
    /// </summary>
    public Guid FoodElementaryId { get; init; }
    
    /// <summary>
    /// Type of food characteristic id.
    /// </summary>
    public Guid CharacteristicTypeId { get; init; }
    
    /// <summary>
    /// Food characteristic value.
    /// </summary>
    public double Value { get; init; }
}
