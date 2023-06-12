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
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllFoodCharacteristicTypesQueryHandler(IMapper mapper, IAppDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task<PagedListMetadataDto<FoodCharacteristicTypeDto>> Handle(GetAllFoodCharacteristicTypesQuery request,
        CancellationToken cancellationToken)
    {
        const bool isDefaultStatement = true;
        var foodCharacteristicTypesQuery = DbContext.FoodCharacteristicTypes
            .Where(foodCharacteristic => foodCharacteristic.IsDefault == isDefaultStatement);
        if (loggedUserAccessor.IsAuthenticated())
        {
            foodCharacteristicTypesQuery = foodCharacteristicTypesQuery.Union(DbContext.FoodCharacteristicTypes
                .Where(foodCharacteristic => foodCharacteristic.UserId == loggedUserAccessor.GetCurrentUserId()));
        }
        if (request.SearchBy != null)
        {
            foodCharacteristicTypesQuery = foodCharacteristicTypesQuery
                .Where(dto => dto.Name.ToLower().Contains(request.SearchBy.ToLower()));
        }
        var foodCharacteristicsTypesDtos = foodCharacteristicTypesQuery
            .ProjectTo<FoodCharacteristicTypeDto>(Mapper.ConfigurationProvider);
        var pagedFoodCharacteristicTypesQuery = await
            EFPagedListFactory.FromSourceAsync(foodCharacteristicsTypesDtos, request.Page, request.PageSize, 
                cancellationToken);
        return pagedFoodCharacteristicTypesQuery.ToMetadataObject();
    }
}
