using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodRecipe.GetFoodRecipeById;

/// <summary>
/// Get food recipe by id with detail information query handler.
/// </summary>
internal class GetFoodRecipeByIdQueryHandler : BaseQueryHandler, IRequestHandler<GetFoodRecipeByIdQuery, DetailFoodRecipeDto>
{
    private readonly ICountRecipeCharacteristics countRecipeCharacteristics;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetFoodRecipeByIdQueryHandler(IMapper mapper, IAppDbContext dbContext,
        ICountRecipeCharacteristics countRecipeCharacteristics) : base(mapper, dbContext)
    {
        this.countRecipeCharacteristics = countRecipeCharacteristics;
    }

    /// <inheritdoc/>
    public async Task<DetailFoodRecipeDto> Handle(GetFoodRecipeByIdQuery request, CancellationToken cancellationToken)
    {
        var foodRecipe = await DbContext.FoodRecipes
            .ProjectTo<DetailFoodRecipeDto>(Mapper.ConfigurationProvider)
            .GetAsync(foodRecipe => foodRecipe.Id == request.FoodRecipeId, cancellationToken);
        return foodRecipe with { CharacteristicsSum = await countRecipeCharacteristics.CountCharacteristics(foodRecipe, cancellationToken) };
    }
}
