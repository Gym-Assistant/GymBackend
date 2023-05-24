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
        CreateMap<Domain.Foodstuffs.FoodElementary, DetailFoodElementaryDto>();
        CreateMap<Domain.Foodstuffs.FoodElementaryWeight, FoodElementaryWeightDto>()
            .ForMember(dest => dest.FoodElementary, opt => opt.MapFrom(src => src.FoodElementary))
            .ForMember(dest => dest.WeightId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ElementaryWeight, opt => opt.MapFrom(src => src.Weight));
    }
}
