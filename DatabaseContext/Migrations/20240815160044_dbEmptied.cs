using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CafeteriaWebsite.DatabaseContext.Migrations
{
    /// <inheritdoc />
    public partial class dbEmptied : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Food",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Food");

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
                columns: new[] { "Id", "CategoryId", "Description", "FoodImageId", "Name", "Price", "Tags" },
                values: new object[,]
                {
                    { 1, 1, "Food description 1", null, "Food1", 0f, "[2]" },
                    { 2, 2, "Food description 2", null, "Food2", 0f, "[0]" },
                    { 3, 2, "Food description 3", null, "Food3", 0f, null },
                    { 4, 3, "Food description 4", null, "Food4", 0f, null }
                });
        }
    }
}
