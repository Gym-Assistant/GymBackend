using AutoMapper;
using GymBackend.Domain.Workouts;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GymBackend.UseCases.Workout.StartWorkout;

/// <summary>
/// Handler for <see cref="StartWorkoutCommand"/>.
/// </summary>
internal class StartWorkoutCommandHandler : BaseCommandHandler, IRequestHandler<StartWorkoutCommand, Guid>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public StartWorkoutCommandHandler(IMapper mapper, IAppDbContext dbContext, ILoggedUserAccessor loggedUserAccessor)
        : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task<Guid> Handle(StartWorkoutCommand request, CancellationToken cancellationToken)
    {
        var workout = new Domain.Workouts.Workout()
        {
            CreatedById = loggedUserAccessor.GetCurrentUserId(),
            CreatedAt = DateTime.UtcNow,
            WorkoutStatus = WorkoutStatus.InProgress
        };
        DbContext.Workouts.Add(workout);
        await DbContext.SaveChangesAsync(cancellationToken);

        await CloseLastWorkoutAsync(cancellationToken);
        return workout.Id;
    }

    private async Task CloseLastWorkoutAsync(CancellationToken cancellationToken)
    {
        var lastWorkout = await DbContext.Workouts
            .Where(w => w.CreatedById == loggedUserAccessor.GetCurrentUserId())
            .OrderByDescending(w => w.CreatedAt)
            .FirstOrDefaultAsync(cancellationToken);

        if (lastWorkout == null)
        {
            return;
        }

        if (lastWorkout.WorkoutStatus == WorkoutStatus.InProgress)
        {
            lastWorkout.WorkoutStatus = WorkoutStatus.IsOver;

            await DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
