using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceShop.BackEnd.Migrations
{
    public partial class product7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "CreatedDate", "Description", "Images", "Name", "Price", "UpdatedDate" },
                values: new object[] { "7a", "4", new DateTime(2021, 7, 17, 0, 0, 0, 0, DateTimeKind.Local), "Xiaomi Poco M3", "Pocom3.png", "Xiaomi Poco M3", 15000000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "7a");
        }
    }
}
