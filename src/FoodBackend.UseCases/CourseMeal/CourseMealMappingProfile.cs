using AutoMapper;
using FoodBackend.UseCases.Common.Dtos;
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
    }
}
