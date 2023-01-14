using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymBackend.Infrastructure.DataAccess.Migrations
{
    public partial class AddedFoodEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodCharacteristicTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCharacteristicTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodCharacteristicTypes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateTable(
                name: "FoodCharacteristics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FoodId = table.Column<Guid>(type: "uuid", nullable: false),
                    CharacteristicTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodCharacteristics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodCharacteristics_FoodCharacteristicTypes_CharacteristicT~",
                        column: x => x.CharacteristicTypeId,
                        principalTable: "FoodCharacteristicTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodCharacteristics_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodCharacteristics_CharacteristicTypeId",
                table: "FoodCharacteristics",
                column: "CharacteristicTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodCharacteristics_FoodId",
                table: "FoodCharacteristics",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodCharacteristicTypes_UserId",
                table: "FoodCharacteristicTypes",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodCharacteristics");

            migrationBuilder.DropTable(
                name: "FoodCharacteristicTypes");

            migrationBuilder.DropTable(
                name: "Foods");
        }
    }
}
