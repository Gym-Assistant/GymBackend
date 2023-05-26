using FoodBackend.Domain.Foodstuffs;

namespace GymBackend.Infrastructure.Abstractions.Interfaces;

/// <summary>
/// Increase recipe characteristic sum service abstraction.
/// </summary>
public interface IChangeRecipeCharacteristicSum
{
    /// <summary>
    /// Increase food recipe characteristic method.
    /// </summary>
    /// <param name="foodRecipe">Food recipe.</param>
    /// <param name="foodElementary">Food elementary.</param>
    /// <param name="elementaryWeight">Elementary weight.</param>
    /// <param name="increaseFlag">If statement is true, method will increase value, else decrease.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task ChangeRecipeCharacteristic(FoodRecipe foodRecipe, FoodElementary foodElementary, double elementaryWeight,
        bool increaseFlag, CancellationToken cancellationToken);
}
