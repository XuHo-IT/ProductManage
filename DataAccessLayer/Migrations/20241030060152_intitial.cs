using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class intitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountMembers",
                columns: table => new
                {
                    MemberID = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MemberPassword = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    MemberName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MemberRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountMembers", x => x.MemberID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    UnitsInStock = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccountMembers",
                columns: new[] { "MemberID", "EmailAddress", "MemberName", "MemberPassword", "MemberRole" },
                values: new object[,]
                {
                    { "PS1001", "admin@newstore.com", "Admin User", "@admin01", 1 },
                    { "PS1002", "john.staff@newstore.com", "John Staff", "@staff02", 2 },
                    { "PS1003", "alice.member@newstore.com", "Alice Member", "@member03", 3 },
                    { "PS1004", "bob.member@newstore.com", "Bob Member", "@member04", 3 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Snacks" },
                    { 2, "Beverages" },
                    { 3, "Bakery" },
                    { 4, "Frozen Foods" },
                    { 5, "Fresh Produce" },
                    { 6, "Meat" },
                    { 7, "Seafood" },
                    { 8, "Dairy" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryID", "Price", "ProductName", "UnitsInStock" },
                values: new object[,]
                {
                    { 1, 1, 2.50m, "Potato Chips", 50 },
                    { 2, 2, 3.00m, "Orange Juice", 30 },
                    { 3, 3, 1.75m, "Croissant", 15 },
                    { 4, 4, 5.00m, "Frozen Pizza", 25 },
                    { 5, 5, 0.50m, "Bananas", 40 },
                    { 6, 6, 6.50m, "Chicken Breast", 20 },
                    { 7, 7, 9.00m, "Salmon Fillet", 15 },
                    { 8, 8, 1.00m, "Greek Yogurt", 35 },
                    { 9, 3, 1.25m, "Bagel", 20 },
                    { 10, 2, 2.00m, "Lemonade", 25 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountMembers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
