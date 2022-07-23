using System.Text.Json.Serialization;
using MediatR;

namespace GymBackend.UseCases.Users.AddNewCharacteristicStamp;

/// <summary>
/// Add new characteristic value for some user.
/// </summary>
public record AddNewCharacteristicStampCommand : IRequest<Guid>
{
    /// <summary>
    /// User Id.
    /// </summary>
    [JsonIgnore]
    public Guid UserId { get; init; }

    /// <summary>
    /// Characteristic Id.
    /// </summary>
    [JsonIgnore]
    public Guid CharacteristicId { get; init; }

    /// <summary>
    /// Characteristic value.
    /// </summary>
    public double Value { get; init; }
}
