﻿// <auto-generated />
using System;
using GymBackend.Domain.Workouts;
using GymBackend.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GymBackend.Infrastructure.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "workout_status", new[] { "planned", "in_progress", "is_over" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ExerciseWorkout", b =>
                {
                    b.Property<Guid>("ExercisesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WorkoutsId")
                        .HasColumnType("uuid");

                    b.HasKey("ExercisesId", "WorkoutsId");

                    b.HasIndex("WorkoutsId");

                    b.ToTable("WorkoutExercises", (string)null);
                });

            modelBuilder.Entity("FoodBackend.Domain.Foodstuffs.Food", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("FoodBackend.Domain.Foodstuffs.FoodCharacteristic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CharacteristicTypeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("FoodId")
                        .HasColumnType("uuid");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CharacteristicTypeId")
                        .IsUnique();

                    b.HasIndex("FoodId");

                    b.ToTable("FoodCharacteristics");
                });

            modelBuilder.Entity("FoodBackend.Domain.Foodstuffs.FoodCharacteristicType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("FoodCharacteristicTypes");
                });

            modelBuilder.Entity("GymBackend.Domain.Users.AppIdentityRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("GymBackend.Domain.Users.CharacteristicStamp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserCharacteristicId")
                        .HasColumnType("uuid");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("UserCharacteristicId");

                    b.ToTable("CharacteristicStamps");
                });

            modelBuilder.Entity("GymBackend.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<DateTime>("LastTokenResetAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("GymBackend.Domain.Users.UserCharacteristic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserCharacteristics");
                });

            modelBuilder.Entity("GymBackend.Domain.Workouts.Exercise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("WorkoutTemplateId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("WorkoutTemplateId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("GymBackend.Domain.Workouts.Sets", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<int>("Reps")
                        .HasColumnType("integer");

                    b.Property<Guid>("TrainSessionId")
                        .HasColumnType("uuid");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("TrainSessionId");

                    b.ToTable("Sets");
                });

            modelBuilder.Entity("GymBackend.Domain.Workouts.TrainSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ExerciseId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("WorkoutId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("TrainSessions");
                });

            modelBuilder.Entity("GymBackend.Domain.Workouts.Workout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<WorkoutStatus>("WorkoutStatus")
                        .HasColumnType("workout_status");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("GymBackend.Domain.Workouts.WorkoutPackage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("WorkoutPackages");
                });

            modelBuilder.Entity("GymBackend.Domain.Workouts.WorkoutTemplate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid?>("WorkoutPackageId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("WorkoutPackageId");

                    b.ToTable("WorkoutTemplates");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ExerciseWorkout", b =>
                {
                    b.HasOne("GymBackend.Domain.Workouts.Exercise", null)
                        .WithMany()
                        .HasForeignKey("ExercisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymBackend.Domain.Workouts.Workout", null)
                        .WithMany()
                        .HasForeignKey("WorkoutsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodBackend.Domain.Foodstuffs.FoodCharacteristic", b =>
                {
                    b.HasOne("FoodBackend.Domain.Foodstuffs.FoodCharacteristicType", "CharacteristicType")
                        .WithOne()
                        .HasForeignKey("FoodBackend.Domain.Foodstuffs.FoodCharacteristic", "CharacteristicTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodBackend.Domain.Foodstuffs.Food", "Food")
                        .WithMany("Characteristics")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CharacteristicType");

                    b.Navigation("Food");
                });

            modelBuilder.Entity("FoodBackend.Domain.Foodstuffs.FoodCharacteristicType", b =>
                {
                    b.HasOne("GymBackend.Domain.Users.User", "CreatedBy")
                        .WithOne()
                        .HasForeignKey("FoodBackend.Domain.Foodstuffs.FoodCharacteristicType", "UserId");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("GymBackend.Domain.Users.CharacteristicStamp", b =>
                {
                    b.HasOne("GymBackend.Domain.Users.UserCharacteristic", "UserCharacteristic")
                        .WithMany("Values")
                        .HasForeignKey("UserCharacteristicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserCharacteristic");
                });

            modelBuilder.Entity("GymBackend.Domain.Users.UserCharacteristic", b =>
                {
                    b.HasOne("GymBackend.Domain.Users.User", "User")
                        .WithMany("Characteristics")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GymBackend.Domain.Workouts.Exercise", b =>
                {
                    b.HasOne("GymBackend.Domain.Users.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymBackend.Domain.Workouts.WorkoutTemplate", null)
                        .WithMany("Exercises")
                        .HasForeignKey("WorkoutTemplateId");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("GymBackend.Domain.Workouts.Sets", b =>
                {
                    b.HasOne("GymBackend.Domain.Users.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymBackend.Domain.Workouts.TrainSession", "TrainSession")
                        .WithMany("Sets")
                        .HasForeignKey("TrainSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("TrainSession");
                });

            modelBuilder.Entity("GymBackend.Domain.Workouts.TrainSession", b =>
                {
                    b.HasOne("GymBackend.Domain.Users.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymBackend.Domain.Workouts.Exercise", "Exercise")
                        .WithMany("TrainSessions")
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymBackend.Domain.Workouts.Workout", "Workout")
                        .WithMany("TrainSessions")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");

                    b.Navigation("Exercise");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("GymBackend.Domain.Workouts.Workout", b =>
                {
                    b.HasOne("GymBackend.Domain.Users.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("GymBackend.Domain.Workouts.WorkoutPackage", b =>
                {
                    b.HasOne("GymBackend.Domain.Users.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("GymBackend.Domain.Workouts.WorkoutTemplate", b =>
                {
                    b.HasOne("GymBackend.Domain.Users.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymBackend.Domain.Workouts.WorkoutPackage", null)
                        .WithMany("WorkoutTemplates")
                        .HasForeignKey("WorkoutPackageId");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("GymBackend.Domain.Users.AppIdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("GymBackend.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("GymBackend.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("GymBackend.Domain.Users.AppIdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GymBackend.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("GymBackend.Domain.Users.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodBackend.Domain.Foodstuffs.Food", b =>
                {
                    b.Navigation("Characteristics");
                });

            modelBuilder.Entity("GymBackend.Domain.Users.User", b =>
                {
                    b.Navigation("Characteristics");
                });

            modelBuilder.Entity("GymBackend.Domain.Users.UserCharacteristic", b =>
                {
                    b.Navigation("Values");
                });

            modelBuilder.Entity("GymBackend.Domain.Workouts.Exercise", b =>
                {
                    b.Navigation("TrainSessions");
                });

            modelBuilder.Entity("GymBackend.Domain.Workouts.TrainSession", b =>
                {
                    b.Navigation("Sets");
                });

            modelBuilder.Entity("GymBackend.Domain.Workouts.Workout", b =>
                {
                    b.Navigation("TrainSessions");
                });

            modelBuilder.Entity("GymBackend.Domain.Workouts.WorkoutPackage", b =>
                {
                    b.Navigation("WorkoutTemplates");
                });

            modelBuilder.Entity("GymBackend.Domain.Workouts.WorkoutTemplate", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
