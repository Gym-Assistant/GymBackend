namespace GymBackend.Domain.Workouts;

/// <summary>
/// Workout status.
/// </summary>
public enum WorkoutStatus
{
    /// <summary>
    /// Indicate that the workout is planned.
    /// </summary>
    Planned = 1,

    /// <summary>
    /// Workout in progress.
    /// </summary>
    InProgress = 2,

    /// <summary>
    /// Workout is over.
    /// </summary>
    IsOver = 3,
}
