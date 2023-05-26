using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBackend.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ImproveDomainEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutExercises");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndedAt",
                table: "Workouts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ExerciseId",
                table: "Workouts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartedAt",
                table: "Workouts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "Workouts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkoutType",
                table: "Workouts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndedAt",
                table: "TrainSessions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "TrainSessions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartedAt",
                table: "TrainSessions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "TrainSessions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "Sets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Sets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "Sets",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_ExerciseId",
                table: "Workouts",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_Exercises_ExerciseId",
                table: "Workouts",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_Exercises_ExerciseId",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_ExerciseId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "EndedAt",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "StartedAt",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "WorkoutType",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "EndedAt",
                table: "TrainSessions");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "TrainSessions");

            migrationBuilder.DropColumn(
                name: "StartedAt",
                table: "TrainSessions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "TrainSessions");

            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "Sets");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Sets");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Sets");

            migrationBuilder.CreateTable(
                name: "WorkoutExercises",
                columns: table => new
                {
                    ExercisesId = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkoutsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutExercises", x => new { x.ExercisesId, x.WorkoutsId });
                    table.ForeignKey(
                        name: "FK_WorkoutExercises_Exercises_ExercisesId",
                        column: x => x.ExercisesId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutExercises_Workouts_WorkoutsId",
                        column: x => x.WorkoutsId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutExercises_WorkoutsId",
                table: "WorkoutExercises",
                column: "WorkoutsId");
        }
    }
}
