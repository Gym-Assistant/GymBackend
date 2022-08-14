using AutoMapper;
using GymBackend.Domain.Workouts;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;

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

        return workout.Id;
    }
}
