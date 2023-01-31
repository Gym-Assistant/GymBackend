using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using FoodBackend.UseCases.Common.Dtos;
using MediatR;
using Saritasa.Tools.Common.Pagination;
using Saritasa.Tools.EFCore.Pagination;

namespace FoodBackend.UseCases.FoodCharacteristic.GetAllFoodCharacteristicTypes;

/// <summary>
/// Get all food characteristic types query handler.
/// </summary>
internal class GetAllFoodCharacteristicTypesQueryHandler : 
    IRequestHandler<GetAllFoodCharacteristicTypesQuery, PagedListMetadataDto<LightFoodCharacteristicTypeDto>>
{
    private readonly IFoodDbContext dbContext;
    private readonly IMapper mapper;
    
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllFoodCharacteristicTypesQueryHandler(IMapper mapper, IFoodDbContext dbContext)
    {
        this.mapper = mapper;
        this.dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<PagedListMetadataDto<LightFoodCharacteristicTypeDto>> Handle(GetAllFoodCharacteristicTypesQuery request,
        CancellationToken cancellationToken)
    {
        var foodCharacteristicTypesQuery = dbContext.FoodCharacteristicTypes
            .ProjectTo<LightFoodCharacteristicTypeDto>(mapper.ConfigurationProvider);
        var pagedFoodCharacteristicTypesQuery = await
            EFPagedListFactory.FromSourceAsync(foodCharacteristicTypesQuery, request.Page, request.PageSize, 
                cancellationToken);

        return pagedFoodCharacteristicTypesQuery.ToMetadataObject();
    }
}
