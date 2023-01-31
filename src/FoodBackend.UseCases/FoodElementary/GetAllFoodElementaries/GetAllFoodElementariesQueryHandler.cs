using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using FoodBackend.UseCases.Common.Dtos;
using MediatR;
using Saritasa.Tools.Common.Pagination;
using Saritasa.Tools.EFCore.Pagination;

namespace FoodBackend.UseCases.FoodElementary.GetAllFoodElementaries;

/// <summary>
/// Get all food elementaries query handler.
/// </summary>
internal class GetAllFoodElementariesQueryHandler : IRequestHandler<GetAllFoodElementariesQuery, PagedListMetadataDto<LightFoodElementaryDto>>
{
    private readonly IFoodDbContext dbContext;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllFoodElementariesQueryHandler(IFoodDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<PagedListMetadataDto<LightFoodElementaryDto>> Handle(GetAllFoodElementariesQuery request, CancellationToken cancellationToken)
    {
        var foodsQuery = dbContext.FoodElementaries
            .ProjectTo<LightFoodElementaryDto>(mapper.ConfigurationProvider);
        var pagedFoodsQuery = await
            EFPagedListFactory.FromSourceAsync(foodsQuery, request.Page, request.PageSize, cancellationToken);

        return pagedFoodsQuery.ToMetadataObject();
    }
}
