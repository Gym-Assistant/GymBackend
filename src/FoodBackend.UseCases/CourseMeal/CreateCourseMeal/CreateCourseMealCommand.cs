using MediatR;

namespace FoodBackend.UseCases.CourseMeal.CreateCourseMeal;

/// <summary>
/// Create Course meal.
/// </summary>
public record CreateCourseMealCommand : IRequest<Guid>
{
    /// <summary>
    /// Meal type id.
    /// </summary>
    public Guid MealTypeId { get; init; }
    
    /// <summary>
    /// Course meal day id.
    /// </summary>
    public Guid CourseMealDayId { get; init; }
    
    /// <summary>
    /// Course meal time.
    /// </summary>
    public TimeOnly? CourseMealTime { get; init; }
}
