using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CafeteriaWebsite.DatabaseContext.Migrations
{
    /// <inheritdoc />
    public partial class firstMigrationFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodImage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodImageId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Food_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Food_FoodImage_FoodImageId",
                        column: x => x.FoodImageId,
                        principalTable: "FoodImage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "Id", "CategoryId", "Description", "FoodImageId", "Name", "Tags" },
                values: new object[,]
                {
                    { 1, 1, "Food description 1", null, "Food1", "[2]" },
                    { 2, 2, "Food description 2", null, "Food2", "[0]" },
                    { 3, 2, "Food description 3", null, "Food3", null },
                    { 4, 3, "Food description 4", null, "Food4", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Food_CategoryId",
                table: "Food",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Food_FoodImageId",
                table: "Food",
                column: "FoodImageId",
                unique: true,
                filter: "[FoodImageId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "FoodImage");
        }
    }
}
