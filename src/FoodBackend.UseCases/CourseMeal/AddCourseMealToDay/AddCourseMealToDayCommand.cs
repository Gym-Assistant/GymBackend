using System.Text.Json.Serialization;
using MediatR;

namespace FoodBackend.UseCases.CourseMeal.AddCourseMealToDay;

/// <summary>
/// Add course meal to course meal day command.
/// </summary>
public record AddCourseMealToDayCommand : IRequest
{
    /// <summary>
    /// Course meal day id.
    /// </summary>
    [JsonIgnore]
    public Guid CourseMealDayId { get; init; }
    
    /// <summary>
    /// Course meal id.
    /// </summary>
    public Guid CourseMealId { get; init; }
}
