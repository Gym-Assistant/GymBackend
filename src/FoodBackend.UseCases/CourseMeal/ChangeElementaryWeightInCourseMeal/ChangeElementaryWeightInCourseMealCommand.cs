using System.Text.Json.Serialization;
using MediatR;

namespace FoodBackend.UseCases.CourseMeal.ChangeElementaryWeightInCourseMeal;

/// <summary>
/// Change elementary weight in course meal command.
/// </summary>
public record ChangeElementaryWeightInCourseMealCommand : IRequest
{
    /// <summary>
    /// Course meal id.
    /// </summary>
    [JsonIgnore]
    public Guid CourseMealId { get; init; }
    
    /// <summary>
    /// Food elementary id.
    /// </summary>
    [JsonIgnore]
    public Guid FoodElementaryId { get; init; }
    
    /// <summary>
    /// Consumed food elementary weight value.
    /// </summary>
    public double Weight { get; init; }
}
