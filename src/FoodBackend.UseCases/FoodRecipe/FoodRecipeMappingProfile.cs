using AutoMapper;
using FoodBackend.Domain.Foodstuffs;
using FoodBackend.UseCases.Common.Dtos;
using FoodBackend.UseCases.FoodRecipe.AddIngredientToRecipe;
using FoodBackend.UseCases.FoodRecipe.CreateFoodRecipe;

namespace FoodBackend.UseCases.FoodRecipe;

/// <summary>
/// Food recipe mapping profile.
/// </summary>
public class FoodRecipeMappingProfile : Profile
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public FoodRecipeMappingProfile()
    {
        // Command -> Entity.
        CreateMap<CreateFoodRecipeCommand, Domain.Foodstuffs.FoodRecipe>();
        CreateMap<Domain.Foodstuffs.FoodRecipe, LightFoodRecipeDto>();
        CreateMap<AddIngredientToRecipeCommand, FoodElementaryWeight>();
        CreateMap<FoodElementaryWeight, FoodElementaryWeightDto>()
            .ForMember(dest => dest.FoodElementary, opt => opt.MapFrom(src => src.FoodElementary))
            .ForMember(dest => dest.WeightId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ElementaryWeight, opt => opt.MapFrom(src => src.Weight));
        CreateMap<RecipeCharacteristicSumValue, RecipeCharacteristicSumDto>()
            .ForMember(dest=>dest.CharacteristicName, opt=>opt.MapFrom(src=>src.CharacteristicType.Name));
        CreateMap<Domain.Foodstuffs.FoodRecipe, DetailFoodRecipeDto>()
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.IngredientWeights))
            .ForMember(dest => dest.CharacteristicsSum, opt => opt.MapFrom(src => src.CharacteristicValuesSum));
    }
}
