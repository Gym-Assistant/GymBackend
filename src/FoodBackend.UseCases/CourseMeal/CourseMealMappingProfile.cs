using AutoMapper;
using FoodBackend.Domain.Foodstuffs;
using FoodBackend.Domain.MealStuffs;
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
        CreateMap<CourseMealDay, LightCourseMealDayDto>();
        CreateMap<Domain.MealStuffs.CourseMeal, DetailCourseMealDto>()
            .ForMember(dest => dest.MealTypeName, opt => opt.MapFrom(src=> src.MealType.Name))
            .ForMember(dest => dest.ConsumedElementaries, opt => opt.MapFrom(src=> src.ConsumedElementaryWeights))
            .ForMember(dest => dest.ConsumedRecipes, opt => opt.MapFrom(src=> src.ConsumedRecipeWeights));
        CreateMap<ConsumedRecipeWeight, RecipeInCourseMealDto>()
            .ForMember(dest => dest.RecipeInMealWeight, opt => opt.MapFrom(src => src.Weight));
        CreateMap<ConsumedElementaryWeight, FoodElementaryInCourseMealDto>()
            .ForMember(dest => dest.ElementaryInMealWeight, opt => opt.MapFrom(src => src.Weight));
        CreateMap<Domain.Foodstuffs.FoodElementary, LightFoodElementaryDto>();
        CreateMap<Domain.Foodstuffs.FoodRecipe, LightFoodRecipeDto>();
        CreateMap<CourseMealDay, DetailCourseMealDayDto>();
    }
}
