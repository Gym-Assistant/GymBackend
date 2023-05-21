namespace Gym.Domain.Meta;

/// <summary>
/// Meta information about entity creation. Anonymous users can create this entity.
/// </summary>
public interface ICreatableNullable
{
    /// <summary>
    /// Who created the entity user identifier.
    /// </summary>
    Guid? CreatedById { get; }

    /// <summary>
    /// When entity has been created.
    /// </summary>
    DateTimeOffset CreatedAt { get; }
}