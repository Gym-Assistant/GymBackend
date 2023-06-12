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
/// Get all food elementaries with detail info query handler.
/// </summary>
internal class GetAllFoodElementariesQueryHandler : BaseQueryHandler, 
    IRequestHandler<GetAllFoodElementariesQuery, PagedListMetadataDto<DetailFoodElementaryDto>>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllFoodElementariesQueryHandler(IAppDbContext dbContext, IMapper mapper,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }
    
    /// <inheritdoc/>
    public async Task<PagedListMetadataDto<DetailFoodElementaryDto>> Handle(GetAllFoodElementariesQuery request, CancellationToken cancellationToken)
    {
        const bool isDefaultStatement = true;
        var foodElementariesQuery = DbContext.FoodElementaries
            .Where(dto => dto.IsDefault == isDefaultStatement);
        if (loggedUserAccessor.IsAuthenticated())
        {
            foodElementariesQuery = foodElementariesQuery.Union(DbContext.FoodElementaries
                .Where(dto => dto.UserId == loggedUserAccessor.GetCurrentUserId()));
        }
        if (request.SearchBy != null)
        {
            foodElementariesQuery = foodElementariesQuery
                .Where(dto => dto.Name.ToLower().Contains(request.SearchBy.ToLower()));
        }
        var foodElementariesDtos = foodElementariesQuery
            .ProjectTo<DetailFoodElementaryDto>(Mapper.ConfigurationProvider);
        var pagedFoodsQuery = await
            EFPagedListFactory.FromSourceAsync(foodElementariesDtos, request.Page, request.PageSize, cancellationToken);
        return pagedFoodsQuery.ToMetadataObject();
    }
}
