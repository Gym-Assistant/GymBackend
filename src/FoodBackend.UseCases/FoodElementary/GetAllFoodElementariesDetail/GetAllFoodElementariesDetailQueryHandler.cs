using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using FoodBackend.UseCases.Common.Dtos;
using MediatR;
using Saritasa.Tools.Common.Pagination;
using Saritasa.Tools.EFCore.Pagination;

namespace FoodBackend.UseCases.FoodElementary.GetAllFoodElementariesDetail;

/// <summary>
/// Get all food elementaries with detail info query handler.
/// </summary>
internal class GetAllFoodElementariesDetailQueryHandler : IRequestHandler<GetAllFoodElementariesDetailQuery, PagedListMetadataDto<DetailFoodElementaryDto>>
{
    private readonly IFoodDbContext dbContext;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllFoodElementariesDetailQueryHandler(IFoodDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }
    
    /// <inheritdoc/>
    public async Task<PagedListMetadataDto<DetailFoodElementaryDto>> Handle(GetAllFoodElementariesDetailQuery request, CancellationToken cancellationToken)
    {
        var foodsQuery = dbContext.FoodElementaries
            .ProjectTo<DetailFoodElementaryDto>(mapper.ConfigurationProvider);
        var pagedFoodsQuery = await
            EFPagedListFactory.FromSourceAsync(foodsQuery, request.Page, request.PageSize, cancellationToken);

        return pagedFoodsQuery.ToMetadataObject();
    }
}
