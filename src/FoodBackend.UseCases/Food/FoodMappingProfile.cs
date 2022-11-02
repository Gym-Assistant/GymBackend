using AutoMapper;
using FoodBackend.UseCases.Common.Dtos;
using FoodBackend.UseCases.Food.AddFood;

namespace FoodBackend.UseCases.Food;

/// <summary>
/// Food mapping profile.
/// </summary>
public class FoodMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public FoodMappingProfile()
    {
        CreateMap<CreateFoodCommand, GymBackend.Domain.FoodRecords.Food>().ReverseMap();
        CreateMap<GymBackend.Domain.FoodRecords.Food, LightFoodDto>();
    }
}
