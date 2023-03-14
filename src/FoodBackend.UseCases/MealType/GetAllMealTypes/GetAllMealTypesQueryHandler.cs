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
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllMealTypesQueryHandler(IMapper mapper, IAppDbContext dbContext) : base(mapper, dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<PagedListMetadataDto<LightMealTypeDto>> Handle(GetAllMealTypesQuery request,
        CancellationToken cancellationToken)
    {
        var mealTypeQuery = DbContext.MealTypes
            .ProjectTo<LightMealTypeDto>(Mapper.ConfigurationProvider);
        var pagedMealTypesQuery = await
            EFPagedListFactory.FromSourceAsync(mealTypeQuery, request.Page, request.PageSize, 
                cancellationToken);

        return pagedMealTypesQuery.ToMetadataObject();
    }
}
