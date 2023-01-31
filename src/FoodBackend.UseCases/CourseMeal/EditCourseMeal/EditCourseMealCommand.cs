using System.Text.Json.Serialization;
using MediatR;

namespace FoodBackend.UseCases.CourseMeal.EditCourseMeal;

/// <summary>
/// Edit course meal command.
/// </summary>
public record EditCourseMealCommand : IRequest
{
    /// <summary>
    /// Id.
    /// </summary>
    [JsonIgnore]
    public Guid CourseMealId { get; init; }

    /// <summary>
    /// Meal type id.
    /// </summary>
    public Guid MealTypeId { get; set; }
}
