using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Common.Pagination;
using Saritasa.Tools.EFCore.Pagination;

namespace FoodBackend.UseCases.CourseMeal.GetAllCourseMealDay;

/// <summary>
/// Get all course meal day query handler.
/// </summary>
internal class GetAllCourseMealDayQueryHandler : BaseQueryHandler, IRequestHandler<GetAllCourseMealDayQuery, PagedListMetadataDto<DetailCourseMealDayDto>>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;
    private readonly ICountCourseMealDayCharacteristics countCourseMealDayCharacteristics;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetAllCourseMealDayQueryHandler(IMapper mapper, IAppDbContext dbContext, ILoggedUserAccessor loggedUserAccessor,
        ICountCourseMealDayCharacteristics countCourseMealDayCharacteristics) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
        this.countCourseMealDayCharacteristics = countCourseMealDayCharacteristics;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public async Task<PagedListMetadataDto<DetailCourseMealDayDto>> Handle(GetAllCourseMealDayQuery request, CancellationToken cancellationToken)
    {
        var courseMealDaysQuery = DbContext.CourseMealDays
            .Where(mealDay => mealDay.UserId == loggedUserAccessor.GetCurrentUserId())
            .ProjectTo<DetailCourseMealDayDto>(Mapper.ConfigurationProvider);
        if (request.CourseMealDayDate != null)
        {
            courseMealDaysQuery = courseMealDaysQuery.Where(courseMealDay => courseMealDay.CourseMealDate == request.CourseMealDayDate);
        }
        var pagedCourseMealDaysQuery = await
            EFPagedListFactory.FromSourceAsync(courseMealDaysQuery, request.Page, request.PageSize, 
                cancellationToken);
        var courseMealDays = pagedCourseMealDaysQuery.ToMetadataObject(); 
        foreach (var courseMealDayDto in courseMealDays.Items)
        {
            courseMealDayDto.CharacteristicsSum =
                await countCourseMealDayCharacteristics.CountCourseMealDayCharacteristicsSum(courseMealDayDto, cancellationToken);
        }
        return courseMealDays;
    }
}
