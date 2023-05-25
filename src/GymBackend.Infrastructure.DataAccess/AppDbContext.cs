using FoodBackend.Domain.Foodstuffs;
using FoodBackend.Domain.MealStuffs;
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
public class AppDbContext : IdentityDbContext<User, AppIdentityRole, Guid>, IAppDbContext
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
    public DbSet<FoodElementary> FoodElementaries { get; private set; }

    /// <inheritdoc/>
    public DbSet<ConsumedElementaryWeight> ConsumedElementaryWeights { get; private set; }

    /// <inheritdoc/>
    public DbSet<FoodRecipe> FoodRecipes { get; private set; }

    /// <inheritdoc/>
    public DbSet<ConsumedRecipeWeight> ConsumedRecipeWeights { get; private set; }

    /// <inheritdoc/>
    public DbSet<FoodElementaryWeight> FoodElementaryWeights { get; private set; }

    /// <inheritdoc/>
    public DbSet<FoodCharacteristic> FoodCharacteristics { get; private set; }

    /// <inheritdoc/>
    public DbSet<FoodCharacteristicType> FoodCharacteristicTypes { get; private set; }

    /// <inheritdoc />
    public DbSet<RecipeCharacteristicSumValue> RecipeCharacteristicSumValues { get; private set; }

    #endregion

    #region Meals

    /// <inheritdoc/>
    public DbSet<CourseMeal> CourseMeals { get; private set; }

    /// <inheritdoc/>
    public DbSet<CourseMealDay> CourseMealDays { get; private set; }

    /// <inheritdoc/>
    public DbSet<MealType> MealTypes { get; private set; }

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

        modelBuilder.Entity<FoodRecipe>()
            .HasMany(p => p.Ingredients)
            .WithMany(p => p.FoodRecipes)
            .UsingEntity(p => p.ToTable(nameof(FoodRecipeFoodElementary)));

        modelBuilder.Entity<RecipeCharacteristicSumValue>()
            .HasOne(p => p.FoodRecipe)
            .WithMany(p => p.CharacteristicValuesSum)
            .HasForeignKey(p => p.FoodRecipeId);

        modelBuilder.Entity<RecipeCharacteristicSumValue>()
            .HasOne(p => p.CharacteristicType)
            .WithMany()
            .HasForeignKey(p => p.CharacteristicTypeId);

        modelBuilder.Entity<CourseMeal>()
            .HasMany(p => p.ConsumedFoodRecipes)
            .WithMany(p => p.CourseMeals)
            .UsingEntity(p => p.ToTable(nameof(CourseMealFoodRecipe)));

        modelBuilder.Entity<CourseMeal>()
            .HasMany(p => p.ConsumedFoodElementaries)
            .WithMany(p => p.CourseMeals)
            .UsingEntity(p => p.ToTable(nameof(CourseMealFoodElementary)));

        modelBuilder.Entity<FoodCharacteristic>()
            .HasIndex(p => p.UserId);

        modelBuilder.Entity<FoodCharacteristic>()
            .HasOne(p=>p.FoodElementary)
            .WithMany(p=>p.Characteristics)
            .HasForeignKey(p=>p.FoodElementaryId);

        modelBuilder.Entity<FoodCharacteristic>()
            .HasOne(p => p.CharacteristicType)
            .WithMany()
            .HasForeignKey(p => p.CharacteristicTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<FoodElementaryWeight>()
            .HasOne(p=>p.FoodRecipe)
            .WithMany(p=>p.IngredientWeights)
            .HasForeignKey(p=>p.FoodRecipeId);

        modelBuilder.Entity<CourseMealDay>()
            .HasMany(p=>p.CourseMeals)
            .WithOne(p=>p.CourseMealDay)
            .HasForeignKey(p=>p.CourseMealDayId);

        modelBuilder.Entity<CourseMeal>()
            .HasOne(p => p.MealType)
            .WithMany()
            .HasForeignKey(p => p.MealTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MealType>().HasData(
                new MealType { Id = CourseMealDefaults.BreakfastId, IsDefault = true, Name = "Завтрак", UserId = null, User = null},
                new MealType { Id = CourseMealDefaults.LunchId, IsDefault = true, Name = "Обед", UserId = null, User = null},
                new MealType { Id = CourseMealDefaults.DinnerId, IsDefault = true, Name = "Ужин", UserId = null, User = null}
            );

        modelBuilder.Entity<FoodCharacteristicType>().HasData(
            new FoodCharacteristicType { Id = FoodCharacteristicDefaults.ProteinId, IsDefault = true, Name = "Белки", UserId = null, CreatedBy = null},
            new FoodCharacteristicType { Id = FoodCharacteristicDefaults.FatId, IsDefault = true, Name = "Жиры", UserId = null, CreatedBy = null},
            new FoodCharacteristicType { Id = FoodCharacteristicDefaults.CarbohydrateId, IsDefault = true, Name = "Углеводы", UserId = null, CreatedBy = null},
            new FoodCharacteristicType { Id = FoodCharacteristicDefaults.CaloriesId, IsDefault = true, Name = "Калории", UserId = null, CreatedBy = null}
        );

        SetupEnum(modelBuilder);
    }

    private void SetupEnum(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum<WorkoutStatus>();
    }
}
