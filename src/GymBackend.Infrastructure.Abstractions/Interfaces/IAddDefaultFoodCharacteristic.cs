namespace GymBackend.Infrastructure.Abstractions.Interfaces;

/// <summary>
/// Add default characteristic to food elementary service abstraction.
/// </summary>
public interface IAddDefaultFoodCharacteristic
{
    /// <summary>
    /// Add default characteristic to food elementary by given id.
    /// </summary>
    /// <param name="defaultCharacteristicId">Id of default characteristic.</param>
    /// <param name="foodElementary">Food elementary entity.</param>
    /// <param name="characteristicValue">Default food characteristic value.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    Task AddDefaultCharacteristic(Guid defaultCharacteristicId, FoodBackend.Domain.Foodstuffs.FoodElementary foodElementary,
        double characteristicValue, CancellationToken cancellationToken);
}
