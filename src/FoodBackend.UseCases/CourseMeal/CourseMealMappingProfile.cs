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
        CreateMap<Domain.MealStuffs.CourseMeal, LightCourseMealDto>();
        CreateMap<AddElementaryToCourseMealCommand, ConsumedElementaryWeight>();
        CreateMap<AddRecipeToCourseMealCommand, ConsumedRecipeWeight>();
    }
}
