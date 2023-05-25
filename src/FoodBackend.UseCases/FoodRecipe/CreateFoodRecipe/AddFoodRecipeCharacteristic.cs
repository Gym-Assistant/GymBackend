using FoodBackend.Domain.Foodstuffs;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodRecipe.CreateFoodRecipe;

public class AddFoodRecipeCharacteristic : IAddFoodRecipeCharacteristic
{
    private readonly IAppDbContext dbContext;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="dbContext"></param>
    public AddFoodRecipeCharacteristic(IAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddRecipeCharacteristic(Guid characteristicId, Domain.Foodstuffs.FoodRecipe foodRecipe, double characteristicValue,
        CancellationToken cancellationToken)
    {
        var characteristicType = await dbContext.FoodCharacteristicTypes
            .GetAsync(type => type.Id == characteristicId, cancellationToken);
        var recipeSumCharacteristic = new RecipeCharacteristicSumValue
        {
            CharacteristicType = characteristicType,
            CharacteristicTypeId = characteristicType.Id,
            FoodRecipe = foodRecipe,
            FoodRecipeId = foodRecipe.Id,
            Value = characteristicValue
        };
        await dbContext.RecipeCharacteristicSumValues.AddAsync(recipeSumCharacteristic, cancellationToken);
        foodRecipe.CharacteristicValuesSum.Add(recipeSumCharacteristic);
    }
}
