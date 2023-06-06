using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.CourseMeal.GetCourseMealById;

/// <summary>
/// Get course meal by id with detail information query handler.
/// </summary>
internal class GetCourseMealByIdQueryHandler : BaseQueryHandler, IRequestHandler<GetCourseMealByIdQuery, DetailCourseMealDto>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;
    private readonly ICountCourseMealCharacteristics countCourseMealCharacteristics;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetCourseMealByIdQueryHandler(IMapper mapper, IAppDbContext dbContext, ILoggedUserAccessor loggedUserAccessor,
        ICountCourseMealCharacteristics countCourseMealCharacteristics) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
        this.countCourseMealCharacteristics = countCourseMealCharacteristics;
    }

    /// <inheritdoc/>
    public async Task<DetailCourseMealDto> Handle(GetCourseMealByIdQuery request, CancellationToken cancellationToken)
    {
        var courseMeal = await DbContext.CourseMeals
            .Where(meal => meal.UserId == loggedUserAccessor.GetCurrentUserId())
            .ProjectTo<DetailCourseMealDto>(Mapper.ConfigurationProvider)
            .GetAsync(courseMeal => courseMeal.Id == request.CourseMealId,
                cancellationToken);
        return courseMeal with { CharacteristicsSum = await countCourseMealCharacteristics
            .CountCourseMealCharacteristicsSum(courseMeal, cancellationToken) };
    }
}
