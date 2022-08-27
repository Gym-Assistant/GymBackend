using System.ComponentModel.DataAnnotations;
using GymBackend.Domain.Users;

namespace GymBackend.Domain.Workouts;

/// <summary>
/// Workout template.
/// </summary>
public record WorkoutTemplate
{
    /// <summary>
    /// Id.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Name of template.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Description of template.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Exercises.
    /// </summary>
    public ICollection<Exercise> Exercises { get; set; }

    /// <summary>
    /// User Id.
    /// </summary>
    public Guid CreatedById { get; set; }

    /// <summary>
    /// Created by.
    /// </summary>
    public User CreatedBy { get; set; }

    /// <summary>
    /// Created At.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}
