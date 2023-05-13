using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBackend.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixedIsDefaultTypeFoodCharacteristic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "FoodCharacteristics",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "FoodCharacteristics");
        }
    }
}
