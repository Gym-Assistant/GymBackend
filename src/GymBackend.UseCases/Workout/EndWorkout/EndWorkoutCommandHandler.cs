using AutoMapper;
using GymBackend.Domain.Workouts;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace GymBackend.UseCases.Workout.EndWorkout;

/// <summary>
/// Handler for <see cref="EndWorkoutCommand"/>.
/// </summary>
public class EndWorkoutCommandHandler : BaseCommandHandler, IRequestHandler<EndWorkoutCommand>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public EndWorkoutCommandHandler(IMapper mapper, IAppDbContext dbContext, ILoggedUserAccessor loggedUserAccessor) : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(EndWorkoutCommand request, CancellationToken cancellationToken)
    {
        var workout = await DbContext.Workouts.GetAsync(workout => workout.Id == request.WorkoutId, cancellationToken);

        if (workout.CreatedById != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You cannot change status of this workout.");
        }

        workout.WorkoutStatus = WorkoutStatus.IsOver;
        await DbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
