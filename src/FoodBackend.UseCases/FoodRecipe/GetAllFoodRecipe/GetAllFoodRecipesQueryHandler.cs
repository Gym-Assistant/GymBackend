using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using FoodBackend.UseCases.Common.Dtos;
using MediatR;
using Saritasa.Tools.Common.Pagination;
using Saritasa.Tools.EFCore.Pagination;

namespace FoodBackend.UseCases.FoodRecipe.GetAllFoodRecipe;

/// <summary>
/// Get all food recipes query handler.
/// </summary>
internal class GetAllFoodRecipesQueryHandler : IRequestHandler<GetAllFoodRecipesQuery, PagedListMetadataDto<LightFoodRecipeDto>>
{
    private readonly IFoodDbContext dbContext;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllFoodRecipesQueryHandler(IFoodDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<PagedListMetadataDto<LightFoodRecipeDto>> Handle(GetAllFoodRecipesQuery request, CancellationToken cancellationToken)
    {
        var foodsQuery = dbContext.FoodRecipes
            .ProjectTo<LightFoodRecipeDto>(mapper.ConfigurationProvider);
        var pagedFoodsQuery = await
            EFPagedListFactory.FromSourceAsync(foodsQuery, request.Page, request.PageSize, cancellationToken);

        return pagedFoodsQuery.ToMetadataObject();
    }
}
