using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.FoodRecipe.GetFoodRecipeByIdDetail;

/// <summary>
/// Get food recipe by id with detail information query handler.
/// </summary>
internal class GetFoodRecipeByIdDetailQueryHandler : BaseQueryHandler, IRequestHandler<GetFoodRecipeByIdDetailQuery, DetailFoodRecipeDto>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetFoodRecipeByIdDetailQueryHandler(IMapper mapper, IAppDbContext dbContext) : base(mapper, dbContext)
    {
    }

    /// <inheritdoc/>
    public async Task<DetailFoodRecipeDto> Handle(GetFoodRecipeByIdDetailQuery request, CancellationToken cancellationToken)
    {
        var foodRecipe = await DbContext.FoodRecipes
            .ProjectTo<DetailFoodRecipeDto>(Mapper.ConfigurationProvider)
            .GetAsync(foodRecipe => foodRecipe.Id == request.FoodRecipeId, cancellationToken);

        return foodRecipe;
    }
}
