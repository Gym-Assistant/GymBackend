using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBackend.Infrastructure.DataAccess.Migrations
{
    public partial class CreatedFoodsMealsWeights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodCharacteristics_Foods_FoodId",
                table: "FoodCharacteristics");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_FoodCharacteristicTypes_UserId",
                table: "FoodCharacteristicTypes");

            migrationBuilder.DropIndex(
                name: "IX_FoodCharacteristics_CharacteristicTypeId",
                table: "FoodCharacteristics");

            migrationBuilder.RenameColumn(
                name: "FoodId",
                table: "FoodCharacteristics",
                newName: "FoodElementaryId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodCharacteristics_FoodId",
                table: "FoodCharacteristics",
                newName: "IX_FoodCharacteristics_FoodElementaryId");

            migrationBuilder.AddColumn<double>(
                name: "IsDefault",
                table: "FoodCharacteristics",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "FoodCharacteristics",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MealTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealTypes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseMeals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MealTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseMeals_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseMeals_MealTypes_MealTypeId",
                        column: x => x.MealTypeId,
                        principalTable: "MealTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodRecipes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    CourseMealId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodRecipes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FoodRecipes_CourseMeals_CourseMealId",
                        column: x => x.CourseMealId,
                        principalTable: "CourseMeals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConsumedRecipeWeights",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FoodRecipeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseMealId = table.Column<Guid>(type: "uuid", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumedRecipeWeights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumedRecipeWeights_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsumedRecipeWeights_CourseMeals_CourseMealId",
                        column: x => x.CourseMealId,
                        principalTable: "CourseMeals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsumedRecipeWeights_FoodRecipes_FoodRecipeId",
                        column: x => x.FoodRecipeId,
                        principalTable: "FoodRecipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodElementaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    CourseMealId = table.Column<Guid>(type: "uuid", nullable: true),
                    FoodRecipeId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodElementaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodElementaries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FoodElementaries_CourseMeals_CourseMealId",
                        column: x => x.CourseMealId,
                        principalTable: "CourseMeals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FoodElementaries_FoodRecipes_FoodRecipeId",
                        column: x => x.FoodRecipeId,
                        principalTable: "FoodRecipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConsumedElementaryWeights",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FoodElementaryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourseMealId = table.Column<Guid>(type: "uuid", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumedElementaryWeights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumedElementaryWeights_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsumedElementaryWeights_CourseMeals_CourseMealId",
                        column: x => x.CourseMealId,
                        principalTable: "CourseMeals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsumedElementaryWeights_FoodElementaries_FoodElementaryId",
                        column: x => x.FoodElementaryId,
                        principalTable: "FoodElementaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodElementaryWeights",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FoodRecipeId = table.Column<Guid>(type: "uuid", nullable: false),
                    FoodElementaryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodElementaryWeights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodElementaryWeights_FoodElementaries_FoodElementaryId",
                        column: x => x.FoodElementaryId,
                        principalTable: "FoodElementaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodElementaryWeights_FoodRecipes_FoodRecipeId",
                        column: x => x.FoodRecipeId,
                        principalTable: "FoodRecipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodCharacteristicTypes_UserId",
                table: "FoodCharacteristicTypes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCharacteristics_CharacteristicTypeId",
                table: "FoodCharacteristics",
                column: "CharacteristicTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCharacteristics_UserId",
                table: "FoodCharacteristics",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumedElementaryWeights_CourseMealId",
                table: "ConsumedElementaryWeights",
                column: "CourseMealId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumedElementaryWeights_FoodElementaryId",
                table: "ConsumedElementaryWeights",
                column: "FoodElementaryId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumedElementaryWeights_UserId",
                table: "ConsumedElementaryWeights",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumedRecipeWeights_CourseMealId",
                table: "ConsumedRecipeWeights",
                column: "CourseMealId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumedRecipeWeights_FoodRecipeId",
                table: "ConsumedRecipeWeights",
                column: "FoodRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumedRecipeWeights_UserId",
                table: "ConsumedRecipeWeights",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeals_MealTypeId",
                table: "CourseMeals",
                column: "MealTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMeals_UserId",
                table: "CourseMeals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodElementaries_CourseMealId",
                table: "FoodElementaries",
                column: "CourseMealId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodElementaries_FoodRecipeId",
                table: "FoodElementaries",
                column: "FoodRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodElementaries_UserId",
                table: "FoodElementaries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodElementaryWeights_FoodElementaryId",
                table: "FoodElementaryWeights",
                column: "FoodElementaryId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodElementaryWeights_FoodRecipeId",
                table: "FoodElementaryWeights",
                column: "FoodRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodRecipes_CourseMealId",
                table: "FoodRecipes",
                column: "CourseMealId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodRecipes_UserId",
                table: "FoodRecipes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MealTypes_UserId",
                table: "MealTypes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCharacteristics_AspNetUsers_UserId",
                table: "FoodCharacteristics",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCharacteristics_FoodElementaries_FoodElementaryId",
                table: "FoodCharacteristics",
                column: "FoodElementaryId",
                principalTable: "FoodElementaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodCharacteristics_AspNetUsers_UserId",
                table: "FoodCharacteristics");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodCharacteristics_FoodElementaries_FoodElementaryId",
                table: "FoodCharacteristics");

            migrationBuilder.DropTable(
                name: "ConsumedElementaryWeights");

            migrationBuilder.DropTable(
                name: "ConsumedRecipeWeights");

            migrationBuilder.DropTable(
                name: "FoodElementaryWeights");

            migrationBuilder.DropTable(
                name: "FoodElementaries");

            migrationBuilder.DropTable(
                name: "FoodRecipes");

            migrationBuilder.DropTable(
                name: "CourseMeals");

            migrationBuilder.DropTable(
                name: "MealTypes");

            migrationBuilder.DropIndex(
                name: "IX_FoodCharacteristicTypes_UserId",
                table: "FoodCharacteristicTypes");

            migrationBuilder.DropIndex(
                name: "IX_FoodCharacteristics_CharacteristicTypeId",
                table: "FoodCharacteristics");

            migrationBuilder.DropIndex(
                name: "IX_FoodCharacteristics_UserId",
                table: "FoodCharacteristics");

            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "FoodCharacteristics");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FoodCharacteristics");

            migrationBuilder.RenameColumn(
                name: "FoodElementaryId",
                table: "FoodCharacteristics",
                newName: "FoodId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodCharacteristics_FoodElementaryId",
                table: "FoodCharacteristics",
                newName: "IX_FoodCharacteristics_FoodId");

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodCharacteristicTypes_UserId",
                table: "FoodCharacteristicTypes",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodCharacteristics_CharacteristicTypeId",
                table: "FoodCharacteristics",
                column: "CharacteristicTypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCharacteristics_Foods_FoodId",
                table: "FoodCharacteristics",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
