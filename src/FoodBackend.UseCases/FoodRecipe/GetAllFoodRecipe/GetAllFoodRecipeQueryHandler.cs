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
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllFoodRecipeQueryHandler(IMapper mapper, IAppDbContext dbContext,
        ICountRecipeCharacteristics countRecipeCharacteristics, ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.countRecipeCharacteristics = countRecipeCharacteristics;
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <summary>
    /// <inheritdoc/>>
    /// </summary>
    public async Task<PagedListMetadataDto<DetailFoodRecipeDto>> Handle(GetAllFoodRecipeQuery request, CancellationToken cancellationToken)
    {
        const bool isDefaultStatement = true;
        var foodRecipesQuery = DbContext.FoodRecipes
            .Where(dto => dto.IsDefault == isDefaultStatement);
        if (loggedUserAccessor.IsAuthenticated())
        {
            foodRecipesQuery = foodRecipesQuery.Union(DbContext.FoodRecipes
                .Where(dto => dto.UserId == loggedUserAccessor.GetCurrentUserId()));
        }
        if (request.SearchBy != null)
        {
            foodRecipesQuery = foodRecipesQuery
                .Where(dto => dto.Name.ToLower().Contains(request.SearchBy.ToLower()));
        }
        var foodRecipeDtos = foodRecipesQuery
            .ProjectTo<DetailFoodRecipeDto>(Mapper.ConfigurationProvider);
        var pagedFoodsQuery = await
            EFPagedListFactory.FromSourceAsync(foodRecipeDtos, request.Page, request.PageSize, cancellationToken);
        var foodRecipes = pagedFoodsQuery.ToMetadataObject(); 
        foreach (var foodRecipeDto in foodRecipes.Items)
        {
            foodRecipeDto.CharacteristicsSum =
                await countRecipeCharacteristics.CountRecipeCharacteristicSum(foodRecipeDto, cancellationToken);
        }
        return foodRecipes;
    }
}
