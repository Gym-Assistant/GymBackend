using GymBackend.Infrastructure.Abstractions.Interfaces;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodElementary.CreateFoodElementary;

/// <summary>
/// Add default characteristic to food elementary service.
/// </summary>
public class AddDefaultFoodCharacteristic : IAddDefaultFoodCharacteristic
{
    private readonly IAppDbContext dbContext;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="dbContext"></param>
    public AddDefaultFoodCharacteristic(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    /// <summary>
    /// Add default characteristic to food elementary by given id.
    /// </summary>
    /// <param name="defaultCharacteristicId">Id of default characteristic.</param>
    /// <param name="foodElementary">Food elementary entity.</param>
    /// <param name="characteristicValue">Default food characteristic value.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    public async Task AddDefaultCharacteristic(Guid defaultCharacteristicId, Domain.Foodstuffs.FoodElementary foodElementary,
        double characteristicValue, CancellationToken cancellationToken)
    {
        var characteristicType = await dbContext.FoodCharacteristicTypes
            .GetAsync(type => type.Id == defaultCharacteristicId, cancellationToken);
        var characteristic = new Domain.Foodstuffs.FoodCharacteristic
        {
            CharacteristicType = characteristicType,
            CharacteristicTypeId = characteristicType.Id,
            FoodElementary = foodElementary,
            FoodElementaryId = foodElementary.Id,
            IsDefault = true,
            Value = characteristicValue
        };
        await dbContext.FoodCharacteristics.AddAsync(characteristic, cancellationToken);
        foodElementary.Characteristics.Add(characteristic);
    }
}
