using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Common.Pagination;
using Saritasa.Tools.EFCore.Pagination;

namespace FoodBackend.UseCases.FoodRecipe.GetAllFoodRecipeDetail;

/// <summary>
/// Get all food recipes with detail information query handler.
/// </summary>
internal class GetAllFoodRecipeDetailQueryHandler : BaseQueryHandler, IRequestHandler<GetAllFoodRecipeDetailQuery, PagedListMetadataDto<DetailFoodRecipeDto>>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllFoodRecipeDetailQueryHandler(IMapper mapper, IAppDbContext dbContext) : base(mapper, dbContext)
    {
    }

    /// <summary>
    /// <inheritdoc/>>
    /// </summary>
    public async Task<PagedListMetadataDto<DetailFoodRecipeDto>> Handle(GetAllFoodRecipeDetailQuery request, CancellationToken cancellationToken)
    {
        var foodsQuery = DbContext.FoodRecipes
            .ProjectTo<DetailFoodRecipeDto>(Mapper.ConfigurationProvider);
        if (request.UserId != null)
        {
            foodsQuery = foodsQuery.Where(foodElementary => foodElementary.UserId == request.UserId);
        }
        var pagedFoodsQuery = await
            EFPagedListFactory.FromSourceAsync(foodsQuery, request.Page, request.PageSize, cancellationToken);

        return pagedFoodsQuery.ToMetadataObject();
    }
}
