using System.Text.Json.Serialization;
using MediatR;

namespace FoodBackend.UseCases.FoodElementary.EditFoodElementary;

/// <summary>
/// Edit food elementary command.
/// </summary>
public record EditFoodElementaryCommand: IRequest
{
    /// <summary>
    /// Id.
    /// </summary>
    [JsonIgnore]
    public Guid Id { get; init; }

    /// <summary>
    /// Food elementary name.
    /// </summary>
    public string Name { get; init; }
}
