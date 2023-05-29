namespace Gym.Domain.Meta;

/// <summary>
/// Meta information about entity update.
/// </summary>
public interface IUpdatable
{
    /// <summary>
    /// When entity has been updated last time.
    /// </summary>
    public DateTimeOffset UpdatedAt { get; set; }
}