using FoodBackend.UseCases.Common.Dtos;

namespace GymBackend.Infrastructure.Abstractions.Interfaces;

/// <summary>
/// Create characteristic list to count service abstraction.
/// </summary>
public interface ICreateCharacteristicsList
{
    /// <summary>
    /// Create food characteristics list for counting method.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of characteristics to count.</returns>
    Task<ICollection<FoodCharacteristicSumDto>> CreateCharacteristics(CancellationToken cancellationToken);
}
