using System.Text.Json.Serialization;
using MediatR;

namespace FoodBackend.UseCases.CourseMeal.AddRecipeToCourseMeal;

/// <summary>
/// Add recipe to course meal command.
/// </summary>
public record AddRecipeToCourseMealCommand : IRequest
{
    /// <summary>
    /// Course meal id.
    /// </summary>
    [JsonIgnore]
    public Guid CourseMealId { get; init; }
    
    /// <summary>
    /// Food recipe id.
    /// </summary>
    public Guid FoodRecipeId { get; init; }
    
    /// <summary>
    /// Food recipe weight value.
    /// </summary>
    public double Weight { get; init; }
}
