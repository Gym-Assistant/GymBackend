using System.Reflection;
using AutoMapper;
using FoodBackend.Domain.Foodstuffs;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodRecipe;

/// <summary>
/// Count food recipe characteristics sum service.
/// </summary>
public class CountRecipeCharacteristics : ICountRecipeCharacteristics
{
    private readonly ILoggedUserAccessor loggedUserAccessor;
    private readonly IAppDbContext dbContext;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CountRecipeCharacteristics(ILoggedUserAccessor loggedUserAccessor, IAppDbContext dbContext, IMapper mapper)
    {
        this.loggedUserAccessor = loggedUserAccessor;
        this.dbContext = dbContext;
        this.mapper = mapper;
    }
    
    /// <inheritdoc />
    public async Task<ICollection<FoodRecipeCharacteristicSumDto>> CountCharacteristics(DetailFoodRecipeDto foodRecipe, CancellationToken cancellationToken)
    {
        const double defaultWeight = 100.0;
        var characteristicsSum = new List<FoodRecipeCharacteristicSumDto>();
        foreach (var characteristic in typeof(FoodCharacteristicDefaults)
                     .GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            var defaultCharacteristicId = Guid.Parse($"{characteristic.GetValue(null)}");
            var defaultCharacteristic = await dbContext.FoodCharacteristicTypes
                .GetAsync(type => type.Id == defaultCharacteristicId, cancellationToken);
            characteristicsSum.Add(new FoodRecipeCharacteristicSumDto
            {
                FoodCharacteristicType = mapper.Map<FoodCharacteristicTypeDto>(defaultCharacteristic),
                CharacteristicSumValue = default
            });
        }
        if (loggedUserAccessor.IsAuthenticated())
        {
            var userCharacteristics = await dbContext.FoodCharacteristicTypes
                .Where(type => type.UserId == loggedUserAccessor.GetCurrentUserId())
                .ToListAsync(cancellationToken);
            foreach (var characteristic in userCharacteristics)
            {
                characteristicsSum.Add(new FoodRecipeCharacteristicSumDto
                {
                    FoodCharacteristicType = mapper.Map<FoodCharacteristicTypeDto>(characteristic),
                    CharacteristicSumValue = default
                });
            }
        }
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
                                                 characteristic.Value / defaultWeight * ingredient.ElementaryWeight
                    };
                    characteristicsSum.Add(increasingCharacteristic);
                }
            }
        }
        return characteristicsSum;
    }
}
