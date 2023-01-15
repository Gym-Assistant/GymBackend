using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using FoodBackend.UseCases.Common.Dtos;
using MediatR;
using Saritasa.Tools.Common.Pagination;
using Saritasa.Tools.EFCore.Pagination;

namespace FoodBackend.UseCases.Food.GetAllFood;

/// <summary>
/// Get all food query handler.
/// </summary>
internal class GetAllFoodQueryHandler : IRequestHandler<GetAllFoodQuery, PagedListMetadataDto<LightFoodDto>>
{
    private readonly IFoodDbContext dbContext;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllFoodQueryHandler(IFoodDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<PagedListMetadataDto<LightFoodDto>> Handle(GetAllFoodQuery request, CancellationToken cancellationToken)
    {
        var foodsQuery = dbContext.Foods
            .ProjectTo<LightFoodDto>(mapper.ConfigurationProvider);
        var pagedFoodsQuery = await
            EFPagedListFactory.FromSourceAsync(foodsQuery, request.Page, request.PageSize, cancellationToken);

        return pagedFoodsQuery.ToMetadataObject();
    }
}
