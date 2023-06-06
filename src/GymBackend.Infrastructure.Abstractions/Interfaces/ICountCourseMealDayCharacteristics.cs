using FoodBackend.UseCases.Common.Dtos;

namespace GymBackend.Infrastructure.Abstractions.Interfaces;

/// <summary>
/// Count course meal day characteristics service abstraction.
/// </summary>
public interface ICountCourseMealDayCharacteristics
{
    /// <summary>
    /// Count course meal day characteristics sum method.
    /// </summary>
    /// <param name="courseMealDay">Course meal day DTO.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Characteristics sum collection.</returns>
    Task<ICollection<FoodCharacteristicSumDto>> CountCourseMealDayCharacteristicsSum(
        DetailCourseMealDayDto courseMealDay, CancellationToken cancellationToken);
}
