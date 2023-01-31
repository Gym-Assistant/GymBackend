using System.ComponentModel.DataAnnotations;
using GymBackend.Domain.Users;

namespace FoodBackend.Domain.MealStuffs;

/// <summary>
/// Meal type.
/// </summary>
public record MealType
{
    /// <summary>
    /// Meal type id.
    /// </summary>
    [Key]
    public Guid Id { get; set; }
    
    /// <summary>
    /// Name of meal type.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Id of user who created meal type.
    /// </summary>
    public Guid? UserId { get; set; }
    
    /// <summary>
    /// User who created meal type.
    /// </summary>
    public User? User { get; set; }
    
    /// <summary>
    /// Is the meal type default value.
    /// </summary>
    public bool IsDefault { get; set; }
}
