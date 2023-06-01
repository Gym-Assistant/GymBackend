using AutoMapper;
using FoodBackend.Domain.MealStuffs;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;

namespace FoodBackend.UseCases.CourseMeal.CreateCourseMealDay;

/// <summary>
/// Create course meal day command handler.
/// </summary>
internal class CreateCourseMealDayCommandHandler : BaseCommandHandler, IRequestHandler<CreateCourseMealDayCommand, Guid>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;
    private readonly IAddDefaultCourseMeal defaultCourseMeal;

    /// <summary>
    /// Constructor.
    /// </summary>
    public CreateCourseMealDayCommandHandler(IMapper mapper, IAppDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor, IAddDefaultCourseMeal defaultCourseMeal) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
        this.defaultCourseMeal = defaultCourseMeal;
    }

    /// <inheritdoc/>
    public async Task<Guid> Handle(CreateCourseMealDayCommand request, CancellationToken cancellationToken)
    {
        var courseMealDay = new CourseMealDay
        {
            UserId = loggedUserAccessor.GetCurrentUserId()
        };
        if (request.CourseMealDate != null)
        {
            courseMealDay.CourseMealDate = request.CourseMealDate.Value;
        }
        else
        {
            courseMealDay.CourseMealDate = DateOnly.FromDateTime(DateTime.UtcNow);
        }
        await defaultCourseMeal.AddDefaultCourseMealToDay(CourseMealDefaults.BreakfastId,
            loggedUserAccessor.GetCurrentUserId(), courseMealDay, cancellationToken);
        await defaultCourseMeal.AddDefaultCourseMealToDay(CourseMealDefaults.LunchId,
            loggedUserAccessor.GetCurrentUserId(), courseMealDay, cancellationToken);
        await defaultCourseMeal.AddDefaultCourseMealToDay(CourseMealDefaults.DinnerId,
            loggedUserAccessor.GetCurrentUserId(), courseMealDay, cancellationToken);
        await DbContext.CourseMealDays.AddAsync(courseMealDay, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);
        return courseMealDay.Id;
    }
}
