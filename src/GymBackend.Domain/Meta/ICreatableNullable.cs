using GymBackend.Domain.Users;

namespace Gym.Domain.Meta;

/// <summary>
/// Meta information about entity creation. Anonymous users can create this entity.
/// </summary>
public interface ICreatableNullable
{
    /// <summary>
    /// Who created the entity user identifier.
    /// </summary>
    Guid? CreatedById { get; set; }

    /// <summary>
    /// Created by.
    /// </summary>
    User CreatedBy { get; set; }

    /// <summary>
    /// When entity has been created.
    /// </summary>
    DateTimeOffset CreatedAt { get; set; }
}