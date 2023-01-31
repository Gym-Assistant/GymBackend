using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using FoodBackend.UseCases.Common.Dtos;
using MediatR;
using Saritasa.Tools.Common.Pagination;
using Saritasa.Tools.EFCore.Pagination;

namespace FoodBackend.UseCases.CourseMeal.GetAllCourseMeal;

/// <summary>
/// Get all food characteristic types query handler.
/// </summary>
internal class GetAllCourseMealQueryHandler : 
    IRequestHandler<GetAllCourseMealQuery, PagedListMetadataDto<LightCourseMealDto>>
{
    private readonly IFoodDbContext dbContext;
    private readonly IMapper mapper;
    
    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllCourseMealQueryHandler(IMapper mapper, IFoodDbContext dbContext)
    {
        this.mapper = mapper;
        this.dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<PagedListMetadataDto<LightCourseMealDto>> Handle(GetAllCourseMealQuery request,
        CancellationToken cancellationToken)
    {
        var courseMealsQuery = dbContext.CourseMeals
            .ProjectTo<LightCourseMealDto>(mapper.ConfigurationProvider);
        var pagedCourseMealsQuery = await
            EFPagedListFactory.FromSourceAsync(courseMealsQuery, request.Page, request.PageSize, 
                cancellationToken);

        return pagedCourseMealsQuery.ToMetadataObject();
    }
}
