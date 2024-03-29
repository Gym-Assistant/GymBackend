﻿using GymBackend.Domain.Users;

namespace GymBackend.Domain.Meta;

/// <summary>
/// Meta information about entity creation.
/// </summary>
public interface ICreatable
{
    /// <summary>
    /// Who created the entity user identifier.
    /// </summary>
    Guid CreatedById { get; set; }

    /// <summary>
    /// Created by.
    /// </summary>
    User CreatedBy { get; set; }

    /// <summary>
    /// When entity has been created.
    /// </summary>
    DateTimeOffset CreatedAt { get; set; }
}