using System.ComponentModel.DataAnnotations;

namespace FoodBackend.Domain.Foodstuffs;

/// <summary>
/// Food characteristic entity.
/// </summary>
public record FoodCharacteristic
{
    /// <summary>
    /// Food characteristic id.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Id of food, which owns characteristic.
    /// </summary>
    public Guid FoodId { get; set; }

    /// <summary>
    /// Food, which owns characteristic.
    /// </summary>
    public Food Food { get; set; }

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
}
