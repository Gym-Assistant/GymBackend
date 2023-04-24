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
internal class GetCourseMealDayByIdQueryHandler : BaseQueryHandler, IRequestHandler<GetCourseMealDayByIdQuery, LightCourseMealDayDto>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetCourseMealDayByIdQueryHandler(IMapper mapper, IAppDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc/>
    public async Task<LightCourseMealDayDto> Handle(GetCourseMealDayByIdQuery request, CancellationToken cancellationToken)
    {
        var courseMealDay = await DbContext.CourseMealDays
            .Where(meal => meal.UserId == loggedUserAccessor.GetCurrentUserId())
            .ProjectTo<LightCourseMealDayDto>(Mapper.ConfigurationProvider)
            .GetAsync(mealDay => mealDay.Id == request.CourseMealDayId,
                cancellationToken);

        return courseMealDay;
    }
}
