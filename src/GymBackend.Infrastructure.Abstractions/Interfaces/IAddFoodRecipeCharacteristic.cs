namespace GymBackend.Infrastructure.Abstractions.Interfaces;

/// <summary>
/// Add characteristic to food recipe service abstraction.
/// </summary>
public interface IAddFoodRecipeCharacteristic
{
    /// <summary>
    /// Add characteristic to food elementary by given id.
    /// </summary>
    Task AddRecipeCharacteristic(Guid characteristicId, FoodBackend.Domain.Foodstuffs.FoodRecipe foodRecipe,
        double characteristicValue, CancellationToken cancellationToken);
}
