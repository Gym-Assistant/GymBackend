using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Common.Pagination;
using Saritasa.Tools.EFCore.Pagination;

namespace FoodBackend.UseCases.FoodRecipe.GetAllFoodRecipe;

/// <summary>
/// Get all food recipes query handler.
/// </summary>
internal class GetAllFoodRecipesQueryHandler : BaseQueryHandler, IRequestHandler<GetAllFoodRecipesQuery, PagedListMetadataDto<LightFoodRecipeDto>>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllFoodRecipesQueryHandler(IAppDbContext dbContext, IMapper mapper) : base(mapper, dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<PagedListMetadataDto<LightFoodRecipeDto>> Handle(GetAllFoodRecipesQuery request, CancellationToken cancellationToken)
    {
        var foodsQuery = DbContext.FoodRecipes
            .ProjectTo<LightFoodRecipeDto>(Mapper.ConfigurationProvider);
        var pagedFoodsQuery = await
            EFPagedListFactory.FromSourceAsync(foodsQuery, request.Page, request.PageSize, cancellationToken);

        return pagedFoodsQuery.ToMetadataObject();
    }
}
