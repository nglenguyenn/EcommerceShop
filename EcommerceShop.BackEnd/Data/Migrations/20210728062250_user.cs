using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EcommerceShop.BackEnd.Migrations
{
    public partial class user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "1",
                column: "CreatedDate",
                value: new DateTime(2021, 7, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "2",
                column: "CreatedDate",
                value: new DateTime(2021, 7, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "3",
                column: "CreatedDate",
                value: new DateTime(2021, 7, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "4",
                column: "CreatedDate",
                value: new DateTime(2021, 7, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "5",
                column: "CreatedDate",
                value: new DateTime(2021, 7, 28, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "6",
                column: "CreatedDate",
                value: new DateTime(2021, 7, 28, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "1",
                column: "CreatedDate",
                value: new DateTime(2021, 7, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "2",
                column: "CreatedDate",
                value: new DateTime(2021, 7, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "3",
                column: "CreatedDate",
                value: new DateTime(2021, 7, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "4",
                column: "CreatedDate",
                value: new DateTime(2021, 7, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "5",
                column: "CreatedDate",
                value: new DateTime(2021, 7, 17, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: "6",
                column: "CreatedDate",
                value: new DateTime(2021, 7, 17, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
