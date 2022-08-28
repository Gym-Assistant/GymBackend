using System.ComponentModel.DataAnnotations;
using MediatR;

namespace GymBackend.UseCases.Exercise.CreateExercise;

/// <summary>
/// Create exercise command.
/// </summary>
/// <param name="Name">Name of exercise.</param>
/// <param name="Description">Description.</param>
public record CreateExerciseCommand() : IRequest<Guid>
{
    /// <summary>
    /// Name of exercise.
    /// </summary>
    [Required]
    public string Name { get; init; }

    /// <summary>
    /// Description.
    /// </summary>
    public string Description { get; init; }
}
