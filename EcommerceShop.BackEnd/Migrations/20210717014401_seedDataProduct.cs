using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceShop.BackEnd.Migrations
{
    public partial class seedDataProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CreatedDate", "Description", "Images", "Name", "Price", "UpdatedDate" },
                values: new object[,]
                {
                    { "1", "1", new DateTime(2021, 7, 17, 0, 0, 0, 0, DateTimeKind.Local), "Test Product 1", null, "Test Product 1", 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2", "2", new DateTime(2021, 7, 17, 0, 0, 0, 0, DateTimeKind.Local), "Test Product 2", null, "Test Product 2", 200m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "3", "3", new DateTime(2021, 7, 17, 0, 0, 0, 0, DateTimeKind.Local), "Test Product 3", null, "Test Product 3", 500m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "4", "4", new DateTime(2021, 7, 17, 0, 0, 0, 0, DateTimeKind.Local), "Test Product 4", null, "Test Product 4", 150m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "5", "5", new DateTime(2021, 7, 17, 0, 0, 0, 0, DateTimeKind.Local), "Test Product 5", null, "Test Product 5", 700m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "6", "1", new DateTime(2021, 7, 17, 0, 0, 0, 0, DateTimeKind.Local), "Test Product 6", null, "Test Product 6", 200m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "6");
        }
    }
}
