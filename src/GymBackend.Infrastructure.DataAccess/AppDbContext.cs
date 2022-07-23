using GymBackend.Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GymBackend.Infrastructure.Abstractions.Interfaces;

namespace GymBackend.Infrastructure.DataAccess;

/// <summary>
/// Application unit of work.
/// </summary>
public class AppDbContext : IdentityDbContext<User, AppIdentityRole, Guid>, IAppDbContext
{
    #region Characteristic

    /// <inheritdoc />
    public DbSet<UserCharacteristic> UserCharacteristics { get; private set; }

    /// <inheritdoc />
    public DbSet<CharacteristicStamp> CharacteristicStamps { get; private set; }

    #endregion

    /// <summary>
    /// Constructor.
    /// </summary>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserCharacteristic>()
            .HasOne(p => p.User)
            .WithMany(p => p.Characteristics)
            .HasForeignKey(p => p.UserId);

        modelBuilder.Entity<UserCharacteristic>()
            .HasIndex(p => p.UserId);

        modelBuilder.Entity<CharacteristicStamp>()
            .HasOne(p => p.UserCharacteristic)
            .WithMany(p => p.Values)
            .HasForeignKey(p => p.UserCharacteristicId);

        modelBuilder.Entity<CharacteristicStamp>()
            .HasIndex(p => p.UserCharacteristicId);
    }
}
