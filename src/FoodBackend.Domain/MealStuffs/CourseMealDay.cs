using System.ComponentModel.DataAnnotations;
using GymBackend.Domain.Users;

namespace FoodBackend.Domain.MealStuffs;

/// <summary>
/// Course meal day for current user.
/// </summary>
public record CourseMealDay
{
    /// <summary>
    /// Course meal day id.
    /// </summary>
    [Key]
    public Guid Id { get; set; }
    
    /// <summary>
    /// Id of user who created course meal day.
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// User who created course meal day.
    /// </summary>
    public User User { get; set; }

    /// <summary>
    /// Course meal date.
    /// </summary>
    public DateOnly CourseMealDate { get; set; }

    /// <summary>
    /// Course meals for current day.
    /// </summary>
    public ICollection<CourseMeal> CourseMeals { get; set; }
}
