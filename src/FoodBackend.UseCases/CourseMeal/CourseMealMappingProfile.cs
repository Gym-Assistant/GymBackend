using AutoMapper;
using FoodBackend.Domain.Foodstuffs;
using FoodBackend.UseCases.Common.Dtos;
using FoodBackend.UseCases.CourseMeal.AddElementaryToCourseMeal;
using FoodBackend.UseCases.CourseMeal.AddRecipeToCourseMeal;
using FoodBackend.UseCases.CourseMeal.CreateCourseMeal;

namespace FoodBackend.UseCases.CourseMeal;

/// <summary>
/// Course meal mapping profile.
/// </summary>
public class CourseMealMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public CourseMealMappingProfile()
    {
        CreateMap<CreateCourseMealCommand, Domain.MealStuffs.CourseMeal>();
        CreateMap<Domain.MealStuffs.CourseMeal, LightCourseMealDto>()
            .ForMember(dest => dest.MealTypeName, opt => opt.MapFrom(src=> src.MealType.Name));
        CreateMap<AddElementaryToCourseMealCommand, ConsumedElementaryWeight>();
        CreateMap<AddRecipeToCourseMealCommand, ConsumedRecipeWeight>();
        CreateMap<Domain.MealStuffs.CourseMealDay, LightCourseMealDayDto>();
        CreateMap<Domain.MealStuffs.CourseMeal, DetailCourseMealDto>()
            .ForMember(dest => dest.MealTypeName, opt => opt.MapFrom(src=> src.MealType.Name));
        CreateMap<ConsumedRecipeWeight, ConsumedRecipeWeightDto>();
        CreateMap<ConsumedElementaryWeight, ConsumedElementaryWeightDto>();
        CreateMap<ConsumedRecipeWeight, ConsumedRecipeWeightDto>();
        CreateMap<Domain.Foodstuffs.FoodElementary, LightFoodElementaryDto>();
        CreateMap<Domain.Foodstuffs.FoodRecipe, LightFoodRecipeDto>();
    }
}
