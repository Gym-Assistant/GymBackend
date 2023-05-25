using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBackend.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddFoodRecipeCharacteristicSumTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeCharacteristicSumValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FoodRecipeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CharacteristicTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeCharacteristicSumValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeCharacteristicSumValues_FoodCharacteristicTypes_Chara~",
                        column: x => x.CharacteristicTypeId,
                        principalTable: "FoodCharacteristicTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeCharacteristicSumValues_FoodRecipes_FoodRecipeId",
                        column: x => x.FoodRecipeId,
                        principalTable: "FoodRecipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeCharacteristicSumValues_CharacteristicTypeId",
                table: "RecipeCharacteristicSumValues",
                column: "CharacteristicTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeCharacteristicSumValues_FoodRecipeId",
                table: "RecipeCharacteristicSumValues",
                column: "FoodRecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeCharacteristicSumValues");
        }
    }
}
