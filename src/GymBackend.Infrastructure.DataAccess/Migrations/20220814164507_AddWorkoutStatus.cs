using GymBackend.Domain.Workouts;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBackend.Infrastructure.DataAccess.Migrations
{
    public partial class AddWorkoutStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:workout_status", "planned,in_progress,is_over");

            migrationBuilder.AddColumn<WorkoutStatus>(
                name: "WorkoutStatus",
                table: "Workouts",
                type: "workout_status",
                nullable: false,
                defaultValue: WorkoutStatus.InProgress);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkoutStatus",
                table: "Workouts");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:workout_status", "planned,in_progress,is_over");
        }
    }
}
