using FoodBackend.Domain.Foodstuffs;
using FoodBackend.Infrastructure.Abstractions.Interfaces;
using GymBackend.Domain.Users;
using GymBackend.Domain.Workouts;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GymBackend.Infrastructure.Abstractions.Interfaces;
using Npgsql;

namespace GymBackend.Infrastructure.DataAccess;

/// <summary>
/// Application unit of work.
/// </summary>
public class AppDbContext : IdentityDbContext<User, AppIdentityRole, Guid>, IAppDbContext, IFoodDbContext
{
    #region Characteristic

    /// <inheritdoc />
    public DbSet<UserCharacteristic> UserCharacteristics { get; private set; }

    /// <inheritdoc />
    public DbSet<CharacteristicStamp> CharacteristicStamps { get; private set; }

    #endregion

    #region Workouts

    /// <inheritdoc />
    public DbSet<Workout> Workouts { get; private set; }

    /// <inheritdoc />
    public DbSet<Exercise> Exercises { get; private set; }

    /// <inheritdoc />
    public DbSet<TrainSession> TrainSessions { get; private set; }

    /// <inheritdoc />
    public DbSet<Sets> Sets { get; private set; }

    #endregion

    #region WorkoutTemplate

    /// <inheritdoc />
    public DbSet<WorkoutTemplate> WorkoutTemplates { get; private set; }

    /// <inheritdoc />
    public DbSet<WorkoutPackage> WorkoutPackages { get; private set; }

    #endregion

    #region Foods

    /// <inheritdoc/>
    public DbSet<Food> Foods { get; private set; }

    /// <inheritdoc/>
    public DbSet<FoodCharacteristic> FoodCharacteristics { get; private set; }

    /// <inheritdoc/>
    public DbSet<FoodCharacteristicType> FoodCharacteristicTypes { get; private set; }

    #endregion

    /// <summary>
    /// Register enum types. Must be called before db context register.
    /// </summary>
    public static void RegisterTypes()
    {
        NpgsqlConnection.GlobalTypeMapper.MapEnum<WorkoutStatus>();
    }

    private AppDbContext()
    {
        RegisterTypes();
    }

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

        modelBuilder.Entity<Workout>()
            .HasOne(p => p.CreatedBy)
            .WithMany()
            .HasForeignKey(p => p.CreatedById);

        modelBuilder.Entity<Workout>()
            .HasIndex(p => p.CreatedById);

        modelBuilder.Entity<Workout>()
            .HasMany(p => p.Exercises)
            .WithMany(p => p.Workouts)
            .UsingEntity(p => p.ToTable(nameof(WorkoutExercises)));

        modelBuilder.Entity<TrainSession>()
            .HasOne(p => p.CreatedBy)
            .WithMany()
            .HasForeignKey(p => p.CreatedById);

        modelBuilder.Entity<TrainSession>()
            .HasIndex(p => p.ExerciseId);

        modelBuilder.Entity<TrainSession>()
            .HasIndex(p => p.WorkoutId);

        modelBuilder.Entity<TrainSession>()
            .HasOne(p => p.Workout)
            .WithMany(p => p.TrainSessions)
            .HasForeignKey(p => p.WorkoutId);

        modelBuilder.Entity<Sets>()
            .HasOne(p => p.CreatedBy)
            .WithMany()
            .HasForeignKey(p => p.CreatedById);

        modelBuilder.Entity<Sets>()
            .HasOne(p => p.TrainSession)
            .WithMany(p => p.Sets)
            .HasForeignKey(p => p.TrainSessionId);

        modelBuilder.Entity<WorkoutTemplate>()
            .HasMany(p => p.Exercises)
            .WithOne();

        modelBuilder.Entity<WorkoutTemplate>()
            .HasIndex(p => p.CreatedById);

        modelBuilder.Entity<WorkoutPackage>()
            .HasMany(p => p.WorkoutTemplates)
            .WithOne();

        modelBuilder.Entity<WorkoutPackage>()
            .HasIndex(p => p.CreatedById);

        modelBuilder.Entity<FoodCharacteristic>()
            .HasOne(p => p.Food)
            .WithMany(p => p.Characteristics)
            .HasForeignKey(p => p.FoodId);

        modelBuilder.Entity<FoodCharacteristic>()
            .HasIndex(p => p.FoodId);

        modelBuilder.Entity<FoodCharacteristic>()
            .HasOne(p => p.CharacteristicType)
            .WithOne();

        modelBuilder.Entity<FoodCharacteristic>()
            .HasIndex(p => p.CharacteristicTypeId);

        modelBuilder.Entity<FoodCharacteristicType>()
            .HasOne(p => p.CreatedBy)
            .WithOne();

        modelBuilder.Entity<FoodCharacteristicType>()
            .HasIndex(p => p.UserId);

        SetupEnum(modelBuilder);
    }

    private void SetupEnum(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<WorkoutStatus>();
    }
}
