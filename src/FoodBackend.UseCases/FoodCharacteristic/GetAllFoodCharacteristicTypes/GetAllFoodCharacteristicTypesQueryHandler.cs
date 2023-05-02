using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Common.Pagination;
using Saritasa.Tools.EFCore.Pagination;

namespace FoodBackend.UseCases.FoodCharacteristic.GetAllFoodCharacteristicTypes;

/// <summary>
/// Get all food characteristic types query handler.
/// </summary>
internal class GetAllFoodCharacteristicTypesQueryHandler : BaseQueryHandler,
    IRequestHandler<GetAllFoodCharacteristicTypesQuery, PagedListMetadataDto<FoodCharacteristicTypeDto>>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllFoodCharacteristicTypesQueryHandler(IMapper mapper, IAppDbContext dbContext) : base(mapper, dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<PagedListMetadataDto<FoodCharacteristicTypeDto>> Handle(GetAllFoodCharacteristicTypesQuery request,
        CancellationToken cancellationToken)
    {
        var foodCharacteristicTypesQuery = DbContext.FoodCharacteristicTypes
            .ProjectTo<FoodCharacteristicTypeDto>(Mapper.ConfigurationProvider);
        if (request.UserId != null)
        {
            foodCharacteristicTypesQuery = foodCharacteristicTypesQuery.Where(foodCharacteristic => foodCharacteristic.UserId == request.UserId);
        }
        var pagedFoodCharacteristicTypesQuery = await
            EFPagedListFactory.FromSourceAsync(foodCharacteristicTypesQuery, request.Page, request.PageSize, 
                cancellationToken);

        return pagedFoodCharacteristicTypesQuery.ToMetadataObject();
    }
}
