using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MediatR;

namespace FoodBackend.UseCases.Food.EditFood;

/// <summary>
/// Edit food command.
/// </summary>
public record EditFoodCommand: IRequest
{
    /// <summary>
    /// Id.
    /// </summary>
    [JsonIgnore]
    public Guid Id { get; init; }

    /// <summary>
    /// Food name.
    /// </summary>
    [Required]
    public string Name { get; init; }
}
