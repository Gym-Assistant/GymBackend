using AutoMapper;
using FoodBackend.UseCases.Common.Dtos;
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
    }
}
