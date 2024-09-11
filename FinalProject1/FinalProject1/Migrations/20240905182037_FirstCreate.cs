using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinalProject1.Migrations
{
    /// <inheritdoc />
    public partial class FirstCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Devices, gadgets, and accessories", "Electronics" },
                    { 2, "Fiction, non-fiction, and more", "Books" },
                    { 3, "Appliances for home use", "Home Appliances" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[,]
                {
                    { 1, "Ahmed@Gmail.com", "Ahmed", "Ali", "Password123" },
                    { 2, "B@Gmail.com", "Samy", "Zain", "Password123" },
                    { 3, "C@Gmail.com", "Ali", "Marwan", "Password123" },
                    { 4, "D@Gmail.com", "Samer", "Mohamed", "Password123" },
                    { 5, "E@Gmail.com", "Mayar", "Shrif", "Password123" },
                    { 6, "F@Gmail.com", "osama", "Adly", "Password123" },
                    { 7, "G@Gmail.com", "Sara", "Salem", "Password123" },
                    { 8, "H@Gmail.com", "zain", "Ali", "Password123" },
                    { 9, "I@Gmail.com", "Mahmoud", "Salah", "Password123" },
                    { 10, "J@Gmail.com", "yahia", "Azmey", "Password123" },
                    { 11, "K@Gmail.com", "tarek", "Ahmed", "Password123" },
                    { 12, "L@Gmail.com", "mansour", "Ahmed", "Password123" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImagePath", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Latest smartphone with advanced features", "/images/smartphone.jpg", 699.99m, 50, "Smartphone X1" },
                    { 2, 1, "High-definition 4K television", "/images/tv.jpg", 999.99m, 30, "4K Ultra HD TV" },
                    { 3, 2, "A thrilling fiction novel", "/images/book.jpg", 19.99m, 100, "The Great Adventure Book" },
                    { 4, 3, "High-speed blender with multiple settings", "/images/blender.jpg", 59.99m, 20, "Blender Pro" },
                    { 5, 1, "Headphones with active noise cancellation", "/images/headphones.jpg", 199.99m, 80, "Noise-Cancelling Headphones" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
