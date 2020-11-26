using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PCWeb.Migrations
{
    public partial class Change3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Revenues_Products_ProductId",
                table: "Revenues");

            migrationBuilder.DropIndex(
                name: "IX_Revenues_ProductId",
                table: "Revenues");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f979824-21cc-42f5-b348-ec14dda64d91");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63884713-8a78-43c1-b542-5ab1d3ac999d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e757e85f-cff1-4d1d-8711-20d354015f99");

            migrationBuilder.AddColumn<DateTime>(
                name: "DayCreate",
                table: "Revenues",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ProductCode",
                table: "Revenues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "Revenues",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Revenues",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ProductPrice",
                table: "Revenues",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ProductSeries",
                table: "Revenues",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PriceReality",
                table: "RevenueDetails",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e7136d9-4928-43f9-b82d-f69280437c5b", "463f4e01-b257-4463-b151-f5d642ced194", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1c8a5e58-0ad3-4d42-b419-ad19d3b52969", "61d2350e-bfff-45a8-aca3-a8e761b5e480", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "317effc4-2c1a-4180-baa4-6a9a5cb86b98", "a8614bf1-2a42-47ec-8248-9776870d4a18", "Staff", "STAFF" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c8a5e58-0ad3-4d42-b419-ad19d3b52969");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e7136d9-4928-43f9-b82d-f69280437c5b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "317effc4-2c1a-4180-baa4-6a9a5cb86b98");

            migrationBuilder.DropColumn(
                name: "DayCreate",
                table: "Revenues");

            migrationBuilder.DropColumn(
                name: "ProductCode",
                table: "Revenues");

            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "Revenues");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Revenues");

            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "Revenues");

            migrationBuilder.DropColumn(
                name: "ProductSeries",
                table: "Revenues");

            migrationBuilder.DropColumn(
                name: "PriceReality",
                table: "RevenueDetails");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "63884713-8a78-43c1-b542-5ab1d3ac999d", "495dcbcd-5178-4995-8d35-ba04d6a9961a", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e757e85f-cff1-4d1d-8711-20d354015f99", "be4d3a16-c31b-4377-a218-b591019f4ede", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1f979824-21cc-42f5-b348-ec14dda64d91", "1446b556-9c80-4e60-ba9b-5423e613312b", "Staff", "STAFF" });

            migrationBuilder.CreateIndex(
                name: "IX_Revenues_ProductId",
                table: "Revenues",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Revenues_Products_ProductId",
                table: "Revenues",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
