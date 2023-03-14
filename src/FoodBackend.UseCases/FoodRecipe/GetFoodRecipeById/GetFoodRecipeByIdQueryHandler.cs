using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodRecipe.GetFoodRecipeById;

/// <summary>
/// Get food recipe by id query handler.
/// </summary>
internal class GetFoodRecipeByIdQueryHandler : BaseQueryHandler, IRequestHandler<GetFoodRecipeByIdQuery, LightFoodRecipeDto>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetFoodRecipeByIdQueryHandler(IAppDbContext dbContext, IMapper mapper) : base(mapper, dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<LightFoodRecipeDto> Handle(GetFoodRecipeByIdQuery request, CancellationToken cancellationToken)
    {
        var food = await DbContext.FoodRecipes
            .ProjectTo<LightFoodRecipeDto>(Mapper.ConfigurationProvider)
            .GetAsync(food => food.Id == request.FoodRecipeId, cancellationToken);

        return food;
    }
}
