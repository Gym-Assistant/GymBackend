using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Common.Pagination;
using Saritasa.Tools.EFCore.Pagination;

namespace FoodBackend.UseCases.FoodElementary.GetAllFoodElementariesDetail;

/// <summary>
/// Get all food elementaries with detail info query handler.
/// </summary>
internal class GetAllFoodElementariesDetailQueryHandler : BaseQueryHandler, 
    IRequestHandler<GetAllFoodElementariesDetailQuery, PagedListMetadataDto<DetailFoodElementaryDto>>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllFoodElementariesDetailQueryHandler(IAppDbContext dbContext, IMapper mapper) : base(mapper, dbContext)
    {
    }
    
    /// <inheritdoc/>
    public async Task<PagedListMetadataDto<DetailFoodElementaryDto>> Handle(GetAllFoodElementariesDetailQuery request, CancellationToken cancellationToken)
    {
        var foodsQuery = DbContext.FoodElementaries
            .ProjectTo<DetailFoodElementaryDto>(Mapper.ConfigurationProvider);
        var pagedFoodsQuery = await
            EFPagedListFactory.FromSourceAsync(foodsQuery, request.Page, request.PageSize, cancellationToken);

        return pagedFoodsQuery.ToMetadataObject();
    }
}
