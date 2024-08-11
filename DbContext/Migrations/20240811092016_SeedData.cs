using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CafeteriaWebsite.dbContext.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Description 1", "Category 1" },
                    { 2, "Description 2", "Category 2" },
                    { 3, null, "Category 3" }
                });

            migrationBuilder.InsertData(
                table: "Food",
                columns: new[] { "Id", "CategoryId", "Description", "FoodImageId", "ImageId", "Name", "Tags" },
                values: new object[,]
                {
                    { 1, 1, "Food description 1", null, null, "Food1", "[2]" },
                    { 2, 2, "Food description 2", null, null, "Food2", "[0]" },
                    { 3, 2, "Food description 3", null, null, "Food3", null },
                    { 4, 3, "Food description 4", null, null, "Food4", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
