using AutoMapper;
using FoodBackend.UseCases.Common.Dtos;
using FoodBackend.UseCases.Food.CreateFood;

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
        // Command -> Entity.
        CreateMap<CreateFoodCommand, Domain.Foodstuffs.Food>();
        CreateMap<Domain.Foodstuffs.Food, LightFoodDto>();
    }
}
