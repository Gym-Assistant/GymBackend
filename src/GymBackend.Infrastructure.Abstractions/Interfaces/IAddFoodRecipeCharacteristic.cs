namespace GymBackend.Infrastructure.Abstractions.Interfaces;

/// <summary>
/// Add characteristic to food recipe service abstraction.
/// </summary>
public interface IAddFoodRecipeCharacteristic
{
    /// <summary>
    /// Add characteristic sum to food recipe method.
    /// </summary>
    Task AddRecipeCharacteristic(Guid characteristicId, FoodBackend.Domain.Foodstuffs.FoodRecipe foodRecipe,
        double characteristicValue, CancellationToken cancellationToken);
}
