using System.Reflection;
using AutoMapper;
using FoodBackend.Domain.Foodstuffs;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases;

/// <summary>
/// Create characteristic list to count service.
/// </summary>
public class CreateCharacteristicsList : ICreateCharacteristicsList
{
    private readonly ILoggedUserAccessor loggedUserAccessor;
    private readonly IAppDbContext dbContext;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateCharacteristicsList(ILoggedUserAccessor loggedUserAccessor, IAppDbContext dbContext, IMapper mapper)
    {
        this.loggedUserAccessor = loggedUserAccessor;
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<ICollection<FoodCharacteristicSumDto>> CreateCharacteristics(CancellationToken cancellationToken)
    {
        var characteristicsList = new List<FoodCharacteristicSumDto>();
        foreach (var characteristic in typeof(FoodCharacteristicDefaults)
                     .GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            var defaultCharacteristicId = Guid.Parse($"{characteristic.GetValue(null)}");
            var defaultCharacteristic = await dbContext.FoodCharacteristicTypes
                .GetAsync(type => type.Id == defaultCharacteristicId, cancellationToken);
            characteristicsList.Add(new FoodCharacteristicSumDto
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
                characteristicsList.Add(new FoodCharacteristicSumDto
                {
                    FoodCharacteristicType = mapper.Map<FoodCharacteristicTypeDto>(characteristic),
                    CharacteristicSumValue = default
                });
            }
        }
        return characteristicsList;
    }
}
