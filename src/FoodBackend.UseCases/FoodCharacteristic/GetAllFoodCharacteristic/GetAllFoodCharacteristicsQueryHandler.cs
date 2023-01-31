using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using FoodBackend.UseCases.Common.Dtos;
using MediatR;
using Saritasa.Tools.Common.Pagination;
using Saritasa.Tools.EFCore.Pagination;

namespace FoodBackend.UseCases.FoodCharacteristic.GetAllFoodCharacteristic;

/// <summary>
/// Get all food characteristic query handler.
/// </summary>
internal class GetAllFoodCharacteristicsQueryHandler : 
    IRequestHandler<GetAllFoodCharacteristicsQuery, PagedListMetadataDto<LightFoodCharacteristicDto>>
{
    private readonly IFoodDbContext dbContext;
    private readonly IMapper mapper;
    
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllFoodCharacteristicsQueryHandler(IMapper mapper, IFoodDbContext dbContext)
    {
        this.mapper = mapper;
        this.dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<PagedListMetadataDto<LightFoodCharacteristicDto>> Handle(GetAllFoodCharacteristicsQuery request,
        CancellationToken cancellationToken)
    {
        var foodCharacteristicsQuery = dbContext.FoodCharacteristics
            .ProjectTo<LightFoodCharacteristicDto>(mapper.ConfigurationProvider);
        var pagedFoodCharacteristicsQuery = await
            EFPagedListFactory.FromSourceAsync(foodCharacteristicsQuery, request.Page, request.PageSize, 
                cancellationToken);

        return pagedFoodCharacteristicsQuery.ToMetadataObject();
    }
}
