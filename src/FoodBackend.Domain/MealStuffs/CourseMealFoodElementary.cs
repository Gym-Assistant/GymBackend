using FoodBackend.Domain.Foodstuffs;

namespace FoodBackend.Domain.MealStuffs;

/// <summary>
/// Relation between course meal and food elementary
/// </summary>
public record CourseMealFoodElementary
{
    /// <summary>
    /// Course meal id.
    /// </summary>
    public Guid CourseMealId { get; set; }

    /// <summary>
    /// Course meal.
    /// </summary>
    public CourseMeal CourseMeal { get; set; }

    /// <summary>
    /// Food elementary id.
    /// </summary>
    public Guid FoodElementaryId { get; set; }

    /// <summary>
    /// Food elementary.
    /// </summary>
    public FoodElementary FoodElementary { get; set; }
}
