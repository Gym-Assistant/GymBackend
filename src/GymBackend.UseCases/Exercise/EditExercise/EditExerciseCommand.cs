using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MediatR;

namespace GymBackend.UseCases.Exercise.EditExercise;

/// <summary>
/// Edit exercise command.
/// </summary>
public record EditExerciseCommand : IRequest
{
    /// <summary>
    /// Id.
    /// </summary>
    [JsonIgnore]
    public Guid Id { get; set; }

    /// <summary>
    /// Name of exercise.
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Description of exercise.
    /// </summary>
    public string Description { get; set; }
}
