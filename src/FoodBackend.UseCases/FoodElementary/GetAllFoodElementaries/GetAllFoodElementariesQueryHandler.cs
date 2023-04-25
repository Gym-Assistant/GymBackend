using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Common.Pagination;
using Saritasa.Tools.EFCore.Pagination;

namespace FoodBackend.UseCases.FoodElementary.GetAllFoodElementaries;

/// <summary>
/// Get all food elementaries query handler.
/// </summary>
internal class GetAllFoodElementariesQueryHandler : BaseQueryHandler,
    IRequestHandler<GetAllFoodElementariesQuery, PagedListMetadataDto<LightFoodElementaryDto>>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllFoodElementariesQueryHandler(IAppDbContext dbContext, IMapper mapper) : base(mapper, dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<PagedListMetadataDto<LightFoodElementaryDto>> Handle(GetAllFoodElementariesQuery request, CancellationToken cancellationToken)
    {
        var foodsQuery = DbContext.FoodElementaries
            .ProjectTo<LightFoodElementaryDto>(Mapper.ConfigurationProvider);
        if (request.UserId != null)
        {
            foodsQuery = foodsQuery.Where(foodElementary => foodElementary.UserId == request.UserId);
        }
        var pagedFoodsQuery = await
            EFPagedListFactory.FromSourceAsync(foodsQuery, request.Page, request.PageSize, cancellationToken);

        return pagedFoodsQuery.ToMetadataObject();
    }
}
