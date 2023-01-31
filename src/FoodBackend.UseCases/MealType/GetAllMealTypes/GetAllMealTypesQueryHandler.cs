using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using FoodBackend.UseCases.Common.Dtos;
using MediatR;
using Saritasa.Tools.Common.Pagination;
using Saritasa.Tools.EFCore.Pagination;

namespace FoodBackend.UseCases.MealType.GetAllMealTypes;

/// <summary>
/// Get all food characteristic types query handler.
/// </summary>
internal class GetAllMealTypesQueryHandler : 
    IRequestHandler<GetAllMealTypesQuery, PagedListMetadataDto<LightMealTypeDto>>
{
    private readonly IFoodDbContext dbContext;
    private readonly IMapper mapper;
    
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllMealTypesQueryHandler(IMapper mapper, IFoodDbContext dbContext)
    {
        this.mapper = mapper;
        this.dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<PagedListMetadataDto<LightMealTypeDto>> Handle(GetAllMealTypesQuery request,
        CancellationToken cancellationToken)
    {
        var mealTypeQuery = dbContext.MealTypes
            .ProjectTo<LightMealTypeDto>(mapper.ConfigurationProvider);
        var pagedMealTypesQuery = await
            EFPagedListFactory.FromSourceAsync(mealTypeQuery, request.Page, request.PageSize, 
                cancellationToken);

        return pagedMealTypesQuery.ToMetadataObject();
    }
}
