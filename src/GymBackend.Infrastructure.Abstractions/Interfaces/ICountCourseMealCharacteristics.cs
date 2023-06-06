using FoodBackend.UseCases.Common.Dtos;

namespace GymBackend.Infrastructure.Abstractions.Interfaces;

/// <summary>
/// Count course meal characteristics sum service abstraction.
/// </summary>
public interface ICountCourseMealCharacteristics
{
    /// <summary>
    /// Count course meal characteristic sum method.
    /// </summary>
    /// <param name="courseMeal">Course meal dto with information.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Characteristics sum collection.</returns>
    Task<ICollection<FoodCharacteristicSumDto>> CountCourseMealCharacteristicsSum(DetailCourseMealDto courseMeal, CancellationToken cancellationToken);
}
