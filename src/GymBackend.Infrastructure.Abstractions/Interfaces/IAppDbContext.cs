using GymBackend.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace GymBackend.Infrastructure.Abstractions.Interfaces;

/// <summary>
/// Application abstraction for unit of work.
/// </summary>
public interface IAppDbContext : IDisposable
{
    /// <summary>
    /// Users.
    /// </summary>
    DbSet<User> Users { get; }

    /// <summary>
    /// User characteristic set.
    /// </summary>
    DbSet<UserCharacteristic> UserCharacteristics { get; }

    /// <summary>
    /// Characteristic stamp.
    /// </summary>
    DbSet<CharacteristicStamp> CharacteristicStamps { get; }

    /// <summary>
    /// Save pending changes.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the request.</param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
