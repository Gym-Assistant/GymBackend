using System.Text.Json.Serialization;
using MediatR;

namespace FoodBackend.UseCases.CourseMeal.ChangeRecipeWeightInCourseMeal;

/// <summary>
/// Change food recipe weight in course meal command.
/// </summary>
public record ChangeRecipeWeightInCourseMealCommand : IRequest
{
    /// <summary>
    /// Course meal id.
    /// </summary>
    [JsonIgnore]
    public Guid CourseMealId { get; init; }
    
    /// <summary>
    /// Food recipe id.
    /// </summary>
    [JsonIgnore]
    public Guid FoodRecipeId { get; init; }
    
    /// <summary>
    /// Consumed food recipe weight value.
    /// </summary>
    public double Weight { get; init; }
}
