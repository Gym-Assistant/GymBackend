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
        CreateMap<Domain.Foodstuffs.FoodRecipe, DetailFoodRecipeDto>()
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.IngredientWeights));
        CreateMap<Domain.Foodstuffs.FoodRecipe, FoodRecipeDtoWithCharacteristics>()
            .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.IngredientWeights));
        CreateMap<FoodElementaryWeight, FoodElementaryInRecipeDto>()
            .ForMember(dest => dest.ElementaryWeight, opt => opt.MapFrom(src => src.Weight));
        
    }
}
