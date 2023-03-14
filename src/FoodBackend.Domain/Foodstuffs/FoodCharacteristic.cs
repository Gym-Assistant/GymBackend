using System.ComponentModel.DataAnnotations;
using GymBackend.Domain.Users;

namespace FoodBackend.Domain.Foodstuffs;

/// <summary>
/// Food characteristic entity.
/// </summary>
public record FoodCharacteristic
{
    /// <summary>
    /// Characteristic id.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Id of food elementary, which owns characteristic.
    /// </summary>
    public Guid FoodElementaryId { get; set; }

    /// <summary>
    /// Food, which owns characteristic.
    /// </summary>
    public FoodElementary FoodElementary { get; set; }

    /// <summary>
    /// Type of food characteristic id.
    /// </summary>
    public Guid CharacteristicTypeId { get; set; }
    
    /// <summary>
    /// Type of food characteristic.
    /// </summary>
    public FoodCharacteristicType CharacteristicType { get; set; }
    
    /// <summary>
    /// Food characteristic value.
    /// </summary>
    public double Value { get; set; }
    
    /// <summary>
    /// Id of user creator.
    /// </summary>
    public Guid? UserId { get; set; }
    
    /// <summary>
    /// User creator.
    /// </summary>
    public User? User { get; set; }
    
    /// <summary>
    /// Is food characteristic default statement.
    /// </summary>
    public double IsDefault { get; set; }
}
