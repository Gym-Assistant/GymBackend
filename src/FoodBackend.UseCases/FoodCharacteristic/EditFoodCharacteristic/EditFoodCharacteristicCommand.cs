using System.Text.Json.Serialization;
using MediatR;

namespace FoodBackend.UseCases.FoodCharacteristic.EditFoodCharacteristic;

/// <summary>
/// Edit food characteristic command.
/// </summary>
public record EditFoodCharacteristicCommand : IRequest<Unit>
{
    /// <summary>
    /// Id.
    /// </summary>
    [JsonIgnore]
    public Guid FoodCharacteristicId { get; init; }

    /// <summary>
    /// Food characteristic value.
    /// </summary>
    public double Value { get; init; }
}
