using System.ComponentModel.DataAnnotations;

namespace FoodBackend.Domain.Foodstuffs;

/// <summary>
/// Food entity.
/// </summary>
public record Food
{
    /// <summary>
    /// Food id.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Food name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Food characteristics collection.
    /// </summary>
    public ICollection<FoodCharacteristic> Characteristics { get; set; }
}
