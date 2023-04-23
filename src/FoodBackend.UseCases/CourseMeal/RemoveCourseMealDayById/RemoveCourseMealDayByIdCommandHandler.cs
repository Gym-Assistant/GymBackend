using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace FoodBackend.UseCases.CourseMeal.RemoveCourseMealDayById;

/// <summary>
/// Delete course meal day by id command handler.
/// </summary>
internal class RemoveCourseMealDayByIdCommandHandler : BaseCommandHandler, IRequestHandler<RemoveCourseMealDayByIdCommand>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RemoveCourseMealDayByIdCommandHandler(IMapper mapper, IAppDbContext dbContext,
        ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc/>
    public async Task Handle(RemoveCourseMealDayByIdCommand request, CancellationToken cancellationToken)
    {
        var courseMealDay = await DbContext.CourseMealDays.GetAsync(courseMealDay =>
            courseMealDay.Id == request.CourseMealDayId, cancellationToken);
        if (courseMealDay.UserId != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You can't remove course meal day that you didn't create.");
        }
        DbContext.CourseMealDays.Remove(courseMealDay);
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}
