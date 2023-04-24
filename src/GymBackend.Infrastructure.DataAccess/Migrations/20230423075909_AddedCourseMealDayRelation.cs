using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBackend.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedCourseMealDayRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMeals_CourseMealDays_CourseMealDayId",
                table: "CourseMeals");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseMealDayId",
                table: "CourseMeals",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMeals_CourseMealDays_CourseMealDayId",
                table: "CourseMeals",
                column: "CourseMealDayId",
                principalTable: "CourseMealDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMeals_CourseMealDays_CourseMealDayId",
                table: "CourseMeals");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseMealDayId",
                table: "CourseMeals",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMeals_CourseMealDays_CourseMealDayId",
                table: "CourseMeals",
                column: "CourseMealDayId",
                principalTable: "CourseMealDays",
                principalColumn: "Id");
        }
    }
}
