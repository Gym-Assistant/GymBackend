using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Common.Pagination;
using Saritasa.Tools.EFCore.Pagination;

namespace FoodBackend.UseCases.CourseMeal.GetAllCourseMeal;

/// <summary>
/// Get all course meal detail query handler.
/// </summary>
internal class GetAllCourseMealQueryHandler : BaseQueryHandler, IRequestHandler<GetAllCourseMealQuery, PagedListMetadataDto<DetailCourseMealDto>>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllCourseMealQueryHandler(IMapper mapper, IAppDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc/>
    public async Task<PagedListMetadataDto<DetailCourseMealDto>> Handle(GetAllCourseMealQuery request, CancellationToken cancellationToken)
    {
        var courseMealsQuery = DbContext.CourseMeals
            .Where(meal => meal.UserId == loggedUserAccessor.GetCurrentUserId())
            .ProjectTo<DetailCourseMealDto>(Mapper.ConfigurationProvider);
        var pagedCourseMealsQuery = await
            EFPagedListFactory.FromSourceAsync(courseMealsQuery, request.Page, request.PageSize, 
                cancellationToken);

        return pagedCourseMealsQuery.ToMetadataObject();
    }
}
