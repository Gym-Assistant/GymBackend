using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Common.Pagination;
using Saritasa.Tools.EFCore.Pagination;

namespace FoodBackend.UseCases.MealType.GetAllMealTypes;

/// <summary>
/// Get all food characteristic types query handler.
/// </summary>
internal class GetAllMealTypesQueryHandler : BaseQueryHandler, 
    IRequestHandler<GetAllMealTypesQuery, PagedListMetadataDto<LightMealTypeDto>>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllMealTypesQueryHandler(IMapper mapper, IAppDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task<PagedListMetadataDto<LightMealTypeDto>> Handle(GetAllMealTypesQuery request,
        CancellationToken cancellationToken)
    {
        const bool isDefaultStatement = true;
        var mealTypeQuery = DbContext.MealTypes
            .Where(dto => dto.IsDefault == isDefaultStatement);
        if (loggedUserAccessor.IsAuthenticated())
        {
            mealTypeQuery = mealTypeQuery.Union(DbContext.MealTypes
                .Where(dto => dto.UserId == loggedUserAccessor.GetCurrentUserId()));
        }
        if (request.SearchBy != null)
        {
            mealTypeQuery = mealTypeQuery
                .Where(dto => dto.Name.ToLower().Contains(request.SearchBy.ToLower()));
        }
        var mealTypeDtos = mealTypeQuery
            .ProjectTo<LightMealTypeDto>(Mapper.ConfigurationProvider);
        var pagedMealTypesQuery = await
            EFPagedListFactory.FromSourceAsync(mealTypeDtos, request.Page, request.PageSize, 
                cancellationToken);
        return pagedMealTypesQuery.ToMetadataObject();
    }
}
