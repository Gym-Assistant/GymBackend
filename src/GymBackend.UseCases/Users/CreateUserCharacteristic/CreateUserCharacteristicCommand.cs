using System.Text.Json.Serialization;
using MediatR;

namespace GymBackend.UseCases.Users.CreateUserCharacteristic;

/// <summary>
/// Create User Characteristic Command.
/// </summary>
public record CreateUserCharacteristicCommand : IRequest<Guid>
{
    /// <summary>
    /// Name of the characteristic.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// User Id.
    /// </summary>
    [JsonIgnore]
    public Guid UserId { get; init; }
}