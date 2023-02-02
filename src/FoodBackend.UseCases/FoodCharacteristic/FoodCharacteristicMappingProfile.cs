using AutoMapper;
using FoodBackend.Domain.Foodstuffs;
using FoodBackend.UseCases.Common.Dtos;
using FoodBackend.UseCases.FoodCharacteristic.CreateFoodCharacteristicType;

namespace FoodBackend.UseCases.FoodCharacteristic;

/// <summary>
/// Food characteristic mapping profile.
/// </summary>
public class FoodCharacteristicMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public FoodCharacteristicMappingProfile()
    {
        CreateMap<CreateFoodCharacteristicTypeCommand, FoodCharacteristicType>();
        CreateMap<FoodCharacteristicType, LightFoodCharacteristicTypeDto>();
        CreateMap<Domain.Foodstuffs.FoodCharacteristic, LightFoodCharacteristicDto>();
        CreateMap<Domain.Foodstuffs.FoodCharacteristic, DetailFoodCharacteristicDto>()
            .ForMember(dest=>dest.CharacteristicName, opt=>opt.MapFrom(src=>src.CharacteristicType.Name));
    }
}
