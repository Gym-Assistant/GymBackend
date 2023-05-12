using FoodBackend.Domain.MealStuffs;

namespace GymBackend.Infrastructure.Abstractions.Interfaces;

/// <summary>
/// Add default course meal to course meal day service abstraction.
/// </summary>
public interface IAddDefaultCourseMeal
{
    /// <summary>
    /// Add default course meal to course meal day.
    /// </summary>
    /// <param name="defaultMealTypeId">Default meal type id.</param>
    /// <param name="userId">Owner id.</param>
    /// <param name="courseMealDay">Course meal day.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns></returns>
    Task AddDefaultCourseMealToDay(Guid defaultMealTypeId, Guid userId, CourseMealDay courseMealDay,
        CancellationToken cancellationToken);
}
