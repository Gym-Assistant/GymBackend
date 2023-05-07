using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBackend.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddRestrictMealType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMeals_MealTypes_MealTypeId",
                table: "CourseMeals");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMeals_MealTypes_MealTypeId",
                table: "CourseMeals",
                column: "MealTypeId",
                principalTable: "MealTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMeals_MealTypes_MealTypeId",
                table: "CourseMeals");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMeals_MealTypes_MealTypeId",
                table: "CourseMeals",
                column: "MealTypeId",
                principalTable: "MealTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
