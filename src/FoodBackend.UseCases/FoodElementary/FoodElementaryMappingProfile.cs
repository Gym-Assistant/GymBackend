using AutoMapper;
using FoodBackend.UseCases.Common.Dtos;
using FoodBackend.UseCases.FoodElementary.CreateFoodElementary;

namespace FoodBackend.UseCases.FoodElementary;

/// <summary>
/// Food mapping profile.
/// </summary>
public class FoodElementaryMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public FoodElementaryMappingProfile()
    {
        // Command -> Entity.
        CreateMap<CreateFoodElementaryCommand, Domain.Foodstuffs.FoodElementary>();
        CreateMap<Domain.Foodstuffs.FoodElementary, LightFoodElementaryDto>();
    }
}
