using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceShop.BackEnd.Migrations
{
    public partial class SeedProduct_CategoryData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Images", "NameCategory" },
                values: new object[,]
                {
                    { "1", "Test Category 1", "", "Test Category 1" },
                    { "2", "Test Category 2", "", "Test Category 2" },
                    { "3", "Test Category 3", "", "Test Category 3" },
                    { "4", "Test Category 4", "", "Test Category 4" },
                    { "5", "Test Category 5", "", "Test Category 5" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: "5");
        }
    }
}
