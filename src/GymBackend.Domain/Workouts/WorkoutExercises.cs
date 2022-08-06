namespace GymBackend.Domain.Workouts;

/// <summary>
/// Relation between a workout and exercises.
/// </summary>
public record WorkoutExercises
{
    /// <summary>
    /// Workout Id.
    /// </summary>
    public Guid WorkoutId { get; init; }

    /// <summary>
    /// Workout.
    /// </summary>
    public Workout Workout { get; init; }

    /// <summary>
    /// Exercise Id.
    /// </summary>
    public Guid ExerciseId { get; init; }

    /// <summary>
    /// Exercise.
    /// </summary>
    public Exercise Exercise { get; init; }
}