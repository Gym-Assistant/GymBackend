using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBackend.Infrastructure.DataAccess.Migrations
{
    public partial class AddedCourseMealDayAndRelationTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodElementaries_CourseMeals_CourseMealId",
                table: "FoodElementaries");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodElementaries_FoodRecipes_FoodRecipeId",
                table: "FoodElementaries");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodRecipes_CourseMeals_CourseMealId",
                table: "FoodRecipes");

            migrationBuilder.DropIndex(
                name: "IX_FoodRecipes_CourseMealId",
                table: "FoodRecipes");

            migrationBuilder.DropIndex(
                name: "IX_FoodElementaries_CourseMealId",
                table: "FoodElementaries");

            migrationBuilder.DropIndex(
                name: "IX_FoodElementaries_FoodRecipeId",
                table: "FoodElementaries");

            migrationBuilder.DropColumn(
                name: "CourseMealId",
                table: "FoodRecipes");

            migrationBuilder.DropColumn(
                name: "CourseMealId",
                table: "FoodElementaries");

            migrationBuilder.DropColumn(
                name: "FoodRecipeId",
                table: "FoodElementaries");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "CourseMeals");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseMealDayId",
                table: "CourseMeals",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "CreatedAt",
                table: "CourseMeals",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.CreateTable(
                name: "CourseMealDays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseMealDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMealDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseMealDays_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseMealFoodElementary",
                columns: table => new
                {
                    ConsumedFoodElementariesId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseMealsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMealFoodElementary", x => new { x.ConsumedFoodElementariesId, x.CourseMealsId });
                    table.ForeignKey(
                        name: "FK_CourseMealFoodElementary_CourseMeals_CourseMealsId",
                        column: x => x.CourseMealsId,
                        principalTable: "CourseMeals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseMealFoodElementary_FoodElementaries_ConsumedFoodEleme~",
                        column: x => x.ConsumedFoodElementariesId,
                        principalTable: "FoodElementaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseMealFoodRecipe",
                columns: table => new
                {
                    ConsumedFoodRecipesId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseMealsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMealFoodRecipe", x => new { x.ConsumedFoodRecipesId, x.CourseMealsId });
                    table.ForeignKey(
                        name: "FK_CourseMealFoodRecipe_CourseMeals_CourseMealsId",
                        column: x => x.CourseMealsId,
                        principalTable: "CourseMeals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseMealFoodRecipe_FoodRecipes_ConsumedFoodRecipesId",
                        column: x => x.ConsumedFoodRecipesId,
                        principalTable: "FoodRecipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodRecipeFoodElementary",
                columns: table => new
                {
                    FoodRecipesId = table.Column<Guid>(type: "uuid", nullable: false),
                    IngredientsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodRecipeFoodElementary", x => new { x.FoodRecipesId, x.IngredientsId });
                    table.ForeignKey(
                        name: "FK_FoodRecipeFoodElementary_FoodElementaries_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "FoodElementaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodRecipeFoodElementary_FoodRecipes_FoodRecipesId",
                        column: x => x.FoodRecipesId,
                        principalTable: "FoodRecipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeals_CourseMealDayId",
                table: "CourseMeals",
                column: "CourseMealDayId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMealDays_UserId",
                table: "CourseMealDays",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMealFoodElementary_CourseMealsId",
                table: "CourseMealFoodElementary",
                column: "CourseMealsId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMealFoodRecipe_CourseMealsId",
                table: "CourseMealFoodRecipe",
                column: "CourseMealsId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodRecipeFoodElementary_IngredientsId",
                table: "FoodRecipeFoodElementary",
                column: "IngredientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseMeals_CourseMealDays_CourseMealDayId",
                table: "CourseMeals",
                column: "CourseMealDayId",
                principalTable: "CourseMealDays",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseMeals_CourseMealDays_CourseMealDayId",
                table: "CourseMeals");

            migrationBuilder.DropTable(
                name: "CourseMealDays");

            migrationBuilder.DropTable(
                name: "CourseMealFoodElementary");

            migrationBuilder.DropTable(
                name: "CourseMealFoodRecipe");

            migrationBuilder.DropTable(
                name: "FoodRecipeFoodElementary");

            migrationBuilder.DropIndex(
                name: "IX_CourseMeals_CourseMealDayId",
                table: "CourseMeals");

            migrationBuilder.DropColumn(
                name: "CourseMealDayId",
                table: "CourseMeals");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CourseMeals");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseMealId",
                table: "FoodRecipes",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CourseMealId",
                table: "FoodElementaries",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FoodRecipeId",
                table: "FoodElementaries",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "CourseMeals",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_FoodRecipes_CourseMealId",
                table: "FoodRecipes",
                column: "CourseMealId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodElementaries_CourseMealId",
                table: "FoodElementaries",
                column: "CourseMealId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodElementaries_FoodRecipeId",
                table: "FoodElementaries",
                column: "FoodRecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodElementaries_CourseMeals_CourseMealId",
                table: "FoodElementaries",
                column: "CourseMealId",
                principalTable: "CourseMeals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodElementaries_FoodRecipes_FoodRecipeId",
                table: "FoodElementaries",
                column: "FoodRecipeId",
                principalTable: "FoodRecipes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodRecipes_CourseMeals_CourseMealId",
                table: "FoodRecipes",
                column: "CourseMealId",
                principalTable: "CourseMeals",
                principalColumn: "Id");
        }
    }
}
