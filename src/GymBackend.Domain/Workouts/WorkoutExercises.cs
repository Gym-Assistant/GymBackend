namespace GymBackend.Domain.Workouts;

/// <summary>
/// Relation between a workout and exercises.
/// </summary>
public record WorkoutExercises
{
    /// <summary>
    /// Workout Id.
    /// </summary>
    public Guid WorkoutId { get; set; }

    /// <summary>
    /// Workout.
    /// </summary>
    public Workout Workout { get; set; }

    /// <summary>
    /// Exercise Id.
    /// </summary>
    public Guid ExerciseId { get; set; }

    /// <summary>
    /// Exercise.
    /// </summary>
    public Exercise Exercise { get; set; }
}
