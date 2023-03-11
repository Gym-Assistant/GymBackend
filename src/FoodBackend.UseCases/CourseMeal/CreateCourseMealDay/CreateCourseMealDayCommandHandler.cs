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
    private ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Counstructor.
    /// </summary>
    public CreateCourseMealDayCommandHandler(IMapper mapper, IAppDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc/>
    public async Task<Guid> Handle(CreateCourseMealDayCommand request, CancellationToken cancellationToken)
    {
        var courseMealDay = new CourseMealDay()
        {
            CourseMealDate = DateOnly.FromDateTime(DateTime.UtcNow),
            UserId = loggedUserAccessor.GetCurrentUserId()
        };
        await DbContext.CourseMealDays.AddAsync(courseMealDay, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);

        return courseMealDay.Id;
    }
}
