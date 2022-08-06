using System.ComponentModel.DataAnnotations;
using GymBackend.Domain.Users;

namespace GymBackend.Domain.Workouts;

/// <summary>
/// Workout package.
/// </summary>
public record WorkoutPackage
{
    /// <summary>
    /// Id.
    /// </summary>
    [Key]
    public Guid Id { get; init; }

    /// <summary>
    /// Name of template.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Description of template.
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Exercises.
    /// </summary>
    public ICollection<WorkoutTemplate> WorkoutTemplates { get; init; }

    /// <summary>
    /// User Id.
    /// </summary>
    public Guid CreatedById { get; init; }

    /// <summary>
    /// Created by.
    /// </summary>
    public User CreatedBy { get; init; }

    /// <summary>
    /// Created At.
    /// </summary>
    public DateTime CreatedAt { get; init; }
}
