using FoodBackend.Domain.MealStuffs;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.CourseMeal.CreateCourseMealDay;

/// <summary>
/// Add default course meal to course meal day service.
/// </summary>
public class AddDefaultCourseMeal : IAddDefaultCourseMeal
{
    private readonly IAppDbContext dbContext;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="dbContext"></param>
    public AddDefaultCourseMeal(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    /// <summary>
    /// Add default course meal to course meal day.
    /// </summary>
    /// <param name="defaultMealTypeId">Default meal type id.</param>
    /// <param name="userId">Owner id.</param>
    /// <param name="courseMealDay">Course meal day.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns></returns>
    public async Task AddDefaultCourseMealToDay(Guid defaultMealTypeId, Guid userId, CourseMealDay courseMealDay,
        CancellationToken cancellationToken)
    {
        var mealType = await dbContext.MealTypes
            .GetAsync(mealType => mealType.Id == defaultMealTypeId, cancellationToken);
        var courseMeal = new Domain.MealStuffs.CourseMeal
        {
            CourseMealDay = courseMealDay,
            CourseMealDayId = courseMealDay.Id,
            MealType = mealType,
            MealTypeId = mealType.Id,
            UserId = userId,
            CreationTime = TimeOnly.FromDateTime(DateTime.UtcNow)
        };
        await dbContext.CourseMeals.AddAsync(courseMeal, cancellationToken);
    }
}
