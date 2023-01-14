using System.ComponentModel.DataAnnotations;
using GymBackend.Domain.Users;

namespace FoodBackend.Domain.Foodstuffs;

/// <summary>
/// Type of food characteristic entity.
/// </summary>
public record FoodCharacteristicType
{
    /// <summary>
    /// Type of food characteristic id.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Name of food characteristic type.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// User who created this characteristic type id.
    /// </summary>
    public Guid? UserId { get; set; }
    
    /// <summary>
    /// User who created this characteristic type.
    /// </summary>
    public User? CreatedBy { get; set; }
    
    /// <summary>
    /// Is the characteristic default value.
    /// </summary>
    public bool IsDefault { get; set; }
}
