using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBackend.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddRestrictCharacteristicType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodCharacteristics_FoodCharacteristicTypes_CharacteristicT~",
                table: "FoodCharacteristics");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCharacteristics_FoodCharacteristicTypes_CharacteristicT~",
                table: "FoodCharacteristics",
                column: "CharacteristicTypeId",
                principalTable: "FoodCharacteristicTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodCharacteristics_FoodCharacteristicTypes_CharacteristicT~",
                table: "FoodCharacteristics");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodCharacteristics_FoodCharacteristicTypes_CharacteristicT~",
                table: "FoodCharacteristics",
                column: "CharacteristicTypeId",
                principalTable: "FoodCharacteristicTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
