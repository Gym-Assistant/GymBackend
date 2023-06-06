using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.CourseMeal.GetCourseMealDayById;

/// <summary>
/// Get course meal day by id query.
/// </summary>
internal class GetCourseMealDayByIdQueryHandler : BaseQueryHandler, IRequestHandler<GetCourseMealDayByIdQuery, DetailCourseMealDayDto>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;
    private readonly ICountCourseMealDayCharacteristics countCourseMealDayCharacteristics;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetCourseMealDayByIdQueryHandler(IMapper mapper, IAppDbContext dbContext, ILoggedUserAccessor loggedUserAccessor,
        ICountCourseMealDayCharacteristics countCourseMealDayCharacteristics) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
        this.countCourseMealDayCharacteristics = countCourseMealDayCharacteristics;
    }

    /// <inheritdoc/>
    public async Task<DetailCourseMealDayDto> Handle(GetCourseMealDayByIdQuery request, CancellationToken cancellationToken)
    {
        var courseMealDay = await DbContext.CourseMealDays
            .Where(meal => meal.UserId == loggedUserAccessor.GetCurrentUserId())
            .ProjectTo<DetailCourseMealDayDto>(Mapper.ConfigurationProvider)
            .GetAsync(mealDay => mealDay.Id == request.CourseMealDayId,
                cancellationToken);
        return courseMealDay with { CharacteristicsSum = await countCourseMealDayCharacteristics
            .CountCourseMealDayCharacteristicsSum(courseMealDay, cancellationToken)};
    }
}
