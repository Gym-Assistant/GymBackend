using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Common.Pagination;
using Saritasa.Tools.EFCore.Pagination;

namespace FoodBackend.UseCases.Food.GetAllFoods;

/// <summary>
/// Get all foods query handler.
/// </summary>
internal class GetAllFoodsQueryHandler : BaseQueryHandler, IRequestHandler<GetAllFoodsQuery, PagedListMetadataDto<LightFoodDto>>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllFoodsQueryHandler(IMapper mapper, IAppDbContext dbContext) : base(mapper, dbContext) { }

    /// <inheritdoc/>
    public async Task<PagedListMetadataDto<LightFoodDto>> Handle(GetAllFoodsQuery request, CancellationToken cancellationToken)
    {
        var exersiceQuery = DbContext.Foods
            .ProjectTo<LightFoodDto>(Mapper.ConfigurationProvider);
        var pagedExersiceQuery = await
            EFPagedListFactory.FromSourceAsync(exersiceQuery, request.Page, request.PageSize, cancellationToken);

        return pagedExersiceQuery.ToMetadataObject();
    }
}
