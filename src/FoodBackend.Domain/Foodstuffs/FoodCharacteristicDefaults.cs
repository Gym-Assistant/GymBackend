namespace FoodBackend.Domain.Foodstuffs;

/// <summary>
/// Food characteristic default constants.
/// </summary>
public static class FoodCharacteristicDefaults
{
    /// <summary>
    /// Protein characteristic type id.
    /// </summary>
    public static readonly Guid ProteinId = Guid.Parse("0141a646-e0ce-4f7a-9433-97112f05db0f");

    /// <summary>
    /// Fat characteristic type id.
    /// </summary>
    public static readonly Guid FatId = Guid.Parse("d126d15b-853a-4b7e-b122-af811a160609");

    /// <summary>
    /// Carbohydrate characteristic type id.
    /// </summary>
    public static readonly Guid CarbohydrateId = Guid.Parse("e3c6d689-4f63-44ff-8844-5bd11e4ed5af");
    
    /// <summary>
    /// Calories characteristic type id.
    /// </summary>
    public static readonly Guid EmptyCaloriesId = Guid.Parse("9fe9959f-7c51-479e-8138-43950064712e");

    /// <summary>
    /// Calories characteristic type id.
    /// </summary>
    public static readonly Guid CaloriesId = Guid.Parse("cdcc58c7-5c5f-454a-9728-0643afccf491");
}
