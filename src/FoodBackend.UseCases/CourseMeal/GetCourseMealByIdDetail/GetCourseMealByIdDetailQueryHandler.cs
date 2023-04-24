using AutoMapper;
using AutoMapper.QueryableExtensions;
using FoodBackend.UseCases.Common.Dtos;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.CourseMeal.GetCourseMealByIdDetail;

/// <summary>
/// Get course meal by id with detail information query handler.
/// </summary>
internal class GetCourseMealByIdDetailQueryHandler : BaseQueryHandler, IRequestHandler<GetCourseMealByIdDetailQuery, DetailCourseMealDto>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public GetCourseMealByIdDetailQueryHandler(IMapper mapper, IAppDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc/>
    public async Task<DetailCourseMealDto> Handle(GetCourseMealByIdDetailQuery request, CancellationToken cancellationToken)
    {
        var courseMeal = await DbContext.CourseMeals
            .Where(meal => meal.UserId == loggedUserAccessor.GetCurrentUserId())
            .ProjectTo<DetailCourseMealDto>(Mapper.ConfigurationProvider)
            .GetAsync(courseMeal => courseMeal.Id == request.CourseMealId,
                cancellationToken);

        return courseMeal;
    }
}
