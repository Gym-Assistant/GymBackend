using System.Text.Json.Serialization;
using MediatR;

namespace FoodBackend.UseCases.FoodCharacteristic.EditFoodCharacteristicType;

/// <summary>
/// Edit food characteristic type command.
/// </summary>
public record EditFoodCharacteristicTypeCommand : IRequest
{
    /// <summary>
    /// Id.
    /// </summary>
    [JsonIgnore]
    public Guid FoodCharacteristicTypeId { get; init; }

    /// <summary>
    /// Food characteristic type name.
    /// </summary>
    public string Name { get; init; }
}
