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
/// Get all food recipes with detail information query handler.
/// </summary>
internal class GetAllFoodRecipeQueryHandler : BaseQueryHandler, IRequestHandler<GetAllFoodRecipeQuery, PagedListMetadataDto<DetailFoodRecipeDto>>
{
    private readonly ICountRecipeCharacteristics countRecipeCharacteristics;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllFoodRecipeQueryHandler(IMapper mapper, IAppDbContext dbContext,
        ICountRecipeCharacteristics countRecipeCharacteristics) : base(mapper, dbContext)
    {
        this.countRecipeCharacteristics = countRecipeCharacteristics;
    }

    /// <summary>
    /// <inheritdoc/>>
    /// </summary>
    public async Task<PagedListMetadataDto<DetailFoodRecipeDto>> Handle(GetAllFoodRecipeQuery request, CancellationToken cancellationToken)
    {
        var foodsQuery = DbContext.FoodRecipes
            .ProjectTo<DetailFoodRecipeDto>(Mapper.ConfigurationProvider);
        if (request.UserId != null)
        {
            foodsQuery = foodsQuery.Where(food => food.UserId == request.UserId);
        }
        var pagedFoodsQuery = await
            EFPagedListFactory.FromSourceAsync(foodsQuery, request.Page, request.PageSize, cancellationToken);
        return pagedFoodsQuery.ToMetadataObject();
    }
}
