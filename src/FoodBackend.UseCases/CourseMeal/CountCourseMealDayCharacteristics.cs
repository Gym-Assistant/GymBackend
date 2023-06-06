using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;

namespace FoodBackend.UseCases.CourseMeal;

/// <summary>
/// Count course meal day characteristics sum service.
/// </summary>
public class CountCourseMealDayCharacteristics : ICountCourseMealDayCharacteristics
{
    private readonly ICreateCharacteristicsList createCharacteristicsList;
    private readonly ICountCourseMealCharacteristics countCourseMealCharacteristics;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CountCourseMealDayCharacteristics(ICreateCharacteristicsList createCharacteristicsList, 
        ICountCourseMealCharacteristics countCourseMealCharacteristics)
    {
        this.createCharacteristicsList = createCharacteristicsList;
        this.countCourseMealCharacteristics = countCourseMealCharacteristics;
    }

    /// <inheritdoc />
    public async Task<ICollection<FoodCharacteristicSumDto>> CountCourseMealDayCharacteristicsSum(DetailCourseMealDayDto courseMealDay, CancellationToken cancellationToken)
    {
        var characteristicsSum = await createCharacteristicsList.CreateCharacteristics(cancellationToken);
        foreach (var courseMeal in courseMealDay.CourseMeals)
        {
            var courseMealFoodCharacteristicsSum = await countCourseMealCharacteristics
                .CountCourseMealCharacteristicsSum(courseMeal, cancellationToken);
            courseMeal.CharacteristicsSum = courseMealFoodCharacteristicsSum;
            foreach (var characteristic in courseMealFoodCharacteristicsSum)
            {
                var increasingCharacteristic = characteristicsSum
                    .FirstOrDefault(dto => dto.FoodCharacteristicType.Id == characteristic.FoodCharacteristicType.Id);
                if (increasingCharacteristic != null)
                {
                    characteristicsSum.Remove(increasingCharacteristic);
                    increasingCharacteristic = increasingCharacteristic with
                    {
                        CharacteristicSumValue = increasingCharacteristic.CharacteristicSumValue + characteristic.CharacteristicSumValue
                    };
                    characteristicsSum.Add(increasingCharacteristic);
                }
            }
        }
        return characteristicsSum;
    }
}
