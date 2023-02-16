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
/// Get all food characteristic types query handler.
/// </summary>
internal class GetAllCourseMealQueryHandler : 
    BaseQueryHandler, IRequestHandler<GetAllCourseMealQuery, PagedListMetadataDto<LightCourseMealDto>>
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllCourseMealQueryHandler(IMapper mapper, IAppDbContext dbContext) : base(mapper, dbContext)
    {
    }

    /// <inheritdoc />
    public async Task<PagedListMetadataDto<LightCourseMealDto>> Handle(GetAllCourseMealQuery request,
        CancellationToken cancellationToken)
    {
        var courseMealsQuery = DbContext.CourseMeals
            .ProjectTo<LightCourseMealDto>(Mapper.ConfigurationProvider);
        var pagedCourseMealsQuery = await
            EFPagedListFactory.FromSourceAsync(courseMealsQuery, request.Page, request.PageSize, 
                cancellationToken);

        return pagedCourseMealsQuery.ToMetadataObject();
    }
}
