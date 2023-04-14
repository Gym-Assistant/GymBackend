using System.Text.Json.Serialization;
using MediatR;

namespace FoodBackend.UseCases.MealType.EditMealType;

/// <summary>
/// Edit meal type command.
/// </summary>
public record EditMealTypeCommand : IRequest<Unit>
{
    /// <summary>
    /// Id.
    /// </summary>
    [JsonIgnore]
    public Guid MealTypeId { get; init; }

    /// <summary>
    /// Meal type name.
    /// </summary>
    public string Name { get; init; }
}
