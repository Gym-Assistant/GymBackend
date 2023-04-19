using AutoMapper;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.UseCases.Common.BaseHandlers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Saritasa.Tools.Domain.Exceptions;
using Saritasa.Tools.EFCore;

namespace GymBackend.UseCases.Exercise.AddExerciseToWorkout;

/// <summary>
/// Handler for <see cref="AddExerciseToWorkoutCommand"/>.
/// </summary>
public class AddExerciseToWorkoutCommandHandler : BaseCommandHandler, IRequestHandler<AddExerciseToWorkoutCommand>
{
    private readonly ILoggedUserAccessor loggedUserAccessor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public AddExerciseToWorkoutCommandHandler(IMapper mapper, IAppDbContext dbContext, ILoggedUserAccessor loggedUserAccessor)
        : base(mapper, dbContext)
    {
        this.loggedUserAccessor = loggedUserAccessor;
    }

    /// <inheritdoc />
    public async Task Handle(AddExerciseToWorkoutCommand request, CancellationToken cancellationToken)
    {
        var workout = await DbContext.Workouts
            .Include(workout => workout.Exercises)
            .GetAsync(workout => workout.Id == request.WorkoutId, cancellationToken);
        var exercise = await DbContext.Exercises.GetAsync(exercise => exercise.Id == request.ExerciseId, cancellationToken);

        // We cannot add exercise to workout when its not our workout.
        // But we can add not out exercise to our workout.
        if (workout.CreatedById != loggedUserAccessor.GetCurrentUserId())
        {
            throw new ForbiddenException("You are not allowed to add exercise to this workout");
        }

        workout.Exercises.Add(exercise);
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}
