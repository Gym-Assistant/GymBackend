using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace GymBackend.UseCases.Workout.RemoveWorkout;

/// <summary>
/// Handler for <see cref="RemoveWorkoutByIdCommand"/>.
/// </summary>
public class RemoveWorkoutByIdCommandHandler : BaseCommandHandler, IRequestHandler<RemoveWorkoutByIdCommand, Unit>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public RemoveWorkoutByIdCommandHandler(IMapper mapper, IAppDbContext dbContext, ILoggedUserAccessor loggedUserAccessor)
        : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task<Unit> Handle(RemoveWorkoutByIdCommand request, CancellationToken cancellationToken)
    {
        var workout = await DbContext.Workouts.GetAsync(workout => workout.Id == request.WorkoutId, cancellationToken);

        if (workout.CreatedById != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You cannot remove this workout.");
        }

        DbContext.Workouts.Remove(workout);
        await DbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
