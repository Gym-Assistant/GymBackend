using Microsoft.EntityFrameworkCore;
using GymBackend.Domain.Users.Entities;

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
    /// Save pending changes.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the request.</param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
