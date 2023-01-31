using AutoMapper;
using FoodBackend.UseCases.Common.Dtos;
using FoodBackend.UseCases.MealType.CreateMealType;

namespace FoodBackend.UseCases.MealType;

/// <summary>
/// Meal type mapping profile.
/// </summary>
public class MealTypeMappingProfile : Profile
{
    public MealTypeMappingProfile()
    {
        CreateMap<CreateMealTypeCommand, Domain.MealStuffs.MealType>();
        CreateMap<Domain.MealStuffs.MealType, LightMealTypeDto>();
    }
}
