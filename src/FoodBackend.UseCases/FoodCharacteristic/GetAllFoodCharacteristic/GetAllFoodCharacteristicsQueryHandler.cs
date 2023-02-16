using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Common.Pagination;
using Saritasa.Tools.EFCore.Pagination;

namespace FoodBackend.UseCases.FoodCharacteristic.GetAllFoodCharacteristic;

/// <summary>
/// Get all food characteristic query handler.
/// </summary>
internal class GetAllFoodCharacteristicsQueryHandler : BaseQueryHandler,
    IRequestHandler<GetAllFoodCharacteristicsQuery, PagedListMetadataDto<LightFoodCharacteristicDto>>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllFoodCharacteristicsQueryHandler(IMapper mapper, IAppDbContext dbContext) : base(mapper, dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<PagedListMetadataDto<LightFoodCharacteristicDto>> Handle(GetAllFoodCharacteristicsQuery request,
        CancellationToken cancellationToken)
    {
        var foodCharacteristicsQuery = DbContext.FoodCharacteristics
            .ProjectTo<LightFoodCharacteristicDto>(Mapper.ConfigurationProvider);
        var pagedFoodCharacteristicsQuery = await
            EFPagedListFactory.FromSourceAsync(foodCharacteristicsQuery, request.Page, request.PageSize, 
                cancellationToken);

        return pagedFoodCharacteristicsQuery.ToMetadataObject();
    }
}
