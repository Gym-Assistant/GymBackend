using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymBackend.Infrastructure.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FoodCharacteristicTypes",
                columns: new[] { "Id", "IsDefault", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("0141a646-e0ce-4f7a-9433-97112f05db0f"), true, "Белки", null },
                    { new Guid("cdcc58c7-5c5f-454a-9728-0643afccf491"), true, "Калории", null },
                    { new Guid("d126d15b-853a-4b7e-b122-af811a160609"), true, "Жиры", null },
                    { new Guid("e3c6d689-4f63-44ff-8844-5bd11e4ed5af"), true, "Углеводы", null }
                });

            migrationBuilder.InsertData(
                table: "MealTypes",
                columns: new[] { "Id", "IsDefault", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("78f0b796-31f9-4b37-ad80-8ceed73978b2"), true, "Обед", null },
                    { new Guid("7d0b4a4f-aa3f-464c-94b5-6f0a16e4e340"), true, "Завтрак", null },
                    { new Guid("82ed6910-2828-4631-bd09-bfb3a29e27b3"), true, "Ужин", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FoodCharacteristicTypes",
                keyColumn: "Id",
                keyValue: new Guid("0141a646-e0ce-4f7a-9433-97112f05db0f"));

            migrationBuilder.DeleteData(
                table: "FoodCharacteristicTypes",
                keyColumn: "Id",
                keyValue: new Guid("cdcc58c7-5c5f-454a-9728-0643afccf491"));

            migrationBuilder.DeleteData(
                table: "FoodCharacteristicTypes",
                keyColumn: "Id",
                keyValue: new Guid("d126d15b-853a-4b7e-b122-af811a160609"));

            migrationBuilder.DeleteData(
                table: "FoodCharacteristicTypes",
                keyColumn: "Id",
                keyValue: new Guid("e3c6d689-4f63-44ff-8844-5bd11e4ed5af"));

            migrationBuilder.DeleteData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("78f0b796-31f9-4b37-ad80-8ceed73978b2"));

            migrationBuilder.DeleteData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("7d0b4a4f-aa3f-464c-94b5-6f0a16e4e340"));

            migrationBuilder.DeleteData(
                table: "MealTypes",
                keyColumn: "Id",
                keyValue: new Guid("82ed6910-2828-4631-bd09-bfb3a29e27b3"));
        }
    }
}
