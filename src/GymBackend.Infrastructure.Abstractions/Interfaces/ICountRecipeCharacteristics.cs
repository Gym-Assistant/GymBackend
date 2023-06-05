using FoodBackend.UseCases.Common.Dtos;

namespace GymBackend.Infrastructure.Abstractions.Interfaces;

/// <summary>
/// Count food recipe characteristics sum service abstraction.
/// </summary>
public interface ICountRecipeCharacteristics
{
    /// <summary>
    /// Count food recipe characteristics sum method.
    /// </summary>
    /// <param name="foodRecipe">Food recipe DTO.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Food recipe characteristics sum collection.</returns>
    Task<ICollection<FoodRecipeCharacteristicSumDto>> CountCharacteristics(DetailFoodRecipeDto foodRecipe, CancellationToken cancellationToken);
}
