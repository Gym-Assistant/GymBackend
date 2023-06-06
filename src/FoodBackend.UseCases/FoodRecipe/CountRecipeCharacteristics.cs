using FoodBackend.Domain.Foodstuffs;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;

namespace FoodBackend.UseCases.FoodRecipe;

/// <summary>
/// Count food recipe characteristics sum service.
/// </summary>
public class CountRecipeCharacteristics : ICountRecipeCharacteristics
{
    private readonly ICreateCharacteristicsList createCharacteristicsList;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CountRecipeCharacteristics(ICreateCharacteristicsList createCharacteristicsList)
    {
        this.createCharacteristicsList = createCharacteristicsList;
    }
    
    /// <inheritdoc />
    public async Task<ICollection<FoodCharacteristicSumDto>> CountRecipeCharacteristicSum(DetailFoodRecipeDto foodRecipe, CancellationToken cancellationToken)
    {
        var characteristicsSum = await createCharacteristicsList.CreateCharacteristics(cancellationToken);
        foreach (var ingredient in foodRecipe.Ingredients)
        {
            foreach (var characteristic in ingredient.FoodElementary.Characteristics)
            {
                var increasingCharacteristic = characteristicsSum
                    .FirstOrDefault(dto => dto.FoodCharacteristicType.Id == characteristic.CharacteristicTypeId);
                if (increasingCharacteristic != null)
                {
                    characteristicsSum.Remove(increasingCharacteristic);
                    increasingCharacteristic = increasingCharacteristic with
                    {
                        CharacteristicSumValue = increasingCharacteristic.CharacteristicSumValue +
                                                 characteristic.Value / FoodWeightDefaults.DefaultProductValueWeight * ingredient.ElementaryWeight
                    };
                    characteristicsSum.Add(increasingCharacteristic);
                }
            }
        }
        return characteristicsSum;
    }
}
