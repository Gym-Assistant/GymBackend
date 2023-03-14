using FoodBackend.Domain.MealStuffs;
using GymBackend.Domain.Users;

namespace FoodBackend.Domain.Foodstuffs;

/// <summary>
/// Consumed food elementary weight.
/// </summary>
public record ConsumedElementaryWeight
{
    /// <summary>
    /// Id.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Food elementary id.
    /// </summary>
    public Guid FoodElementaryId { get; set; }
    
    /// <summary>
    /// Food elementary.
    /// </summary>
    public FoodElementary FoodElementary { get; set; }
    
    /// <summary>
    /// Course meal id.
    /// </summary>
    public Guid CourseMealId { get; set; }
    
    /// <summary>
    /// Course meal.
    /// </summary>
    public CourseMeal CourseMeal { get; set; }
    
    /// <summary>
    /// Weight value.
    /// </summary>
    public double Weight { get; set; }
    
    /// <summary>
    /// User creator id.
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// User creator.
    /// </summary>
    public User User { get; set; }
}
