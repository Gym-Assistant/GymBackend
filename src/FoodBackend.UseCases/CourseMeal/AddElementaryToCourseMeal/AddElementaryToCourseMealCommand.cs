using System.Text.Json.Serialization;
using MediatR;

namespace FoodBackend.UseCases.CourseMeal.AddElementaryToCourseMeal;

/// <summary>
/// Add food elementary to course meal.
/// </summary>
public record AddElementaryToCourseMealCommand : IRequest<Unit>
{
    /// <summary>
    /// Course meal id.
    /// </summary>
    [JsonIgnore]
    public Guid CourseMealId { get; init; }
    
    /// <summary>
    /// Food elementary id.
    /// </summary>
    public Guid FoodElementaryId { get; init; }
    
    /// <summary>
    /// Food elementary weight.
    /// </summary>
    public double Weight { get; init; }
}
