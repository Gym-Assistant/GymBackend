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
        CreateMap<FoodElementaryWeight, FoodElementaryWeightDto>();
        CreateMap<Domain.Foodstuffs.FoodRecipe, DetailFoodRecipeDto>();
    }
}
