using GymBackend.Infrastructure.Abstractions.Interfaces;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodRecipe.AddIngredientToRecipe;

/// <summary>
/// Increase recipe character
/// </summary>
public class ChangeRecipeCharacteristicSum : IChangeRecipeCharacteristicSum
{
    private readonly IAppDbContext dbContext;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="dbContext"></param>
    public ChangeRecipeCharacteristicSum(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    /// <inheritdoc/>
    public async Task ChangeRecipeCharacteristic(Domain.Foodstuffs.FoodRecipe foodRecipe,
        Domain.Foodstuffs.FoodElementary foodElementary, double elementaryWeight, bool increaseFlag, CancellationToken cancellationToken)
    {
        const double defaultElementaryWeight = 100.0;
        
        foreach (var characteristic in foodElementary.Characteristics)
        {
            var recipeCharacteristicSum = await dbContext.RecipeCharacteristicSumValues
                .Where(p => p.FoodRecipeId == foodRecipe.Id)
                .GetAsync(p => p.CharacteristicTypeId == characteristic.CharacteristicTypeId,
                    cancellationToken: cancellationToken);
            if (increaseFlag)
            {
                recipeCharacteristicSum.Value += characteristic.Value / defaultElementaryWeight * elementaryWeight;
            }
            else
            {
                recipeCharacteristicSum.Value -= characteristic.Value / defaultElementaryWeight * elementaryWeight;
            }
        }
    }
}
