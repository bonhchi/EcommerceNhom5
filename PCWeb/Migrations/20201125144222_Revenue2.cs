using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PCWeb.Migrations
{
    public partial class Revenue2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46fbb388-f142-4149-9736-a5231743e047");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9676a9a8-6362-4240-bee8-b36e601b1972");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "996150a2-45cf-43bd-a04d-5a8134b30b6f");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateExpired",
                table: "Revenues",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "RevenueDetails",
                nullable: false,
                defaultValue: 0);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "DateExpired",
                table: "Revenues");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "RevenueDetails");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "46fbb388-f142-4149-9736-a5231743e047", "c8c1a9ed-53d6-4f40-8cb5-a56c4fbebd0a", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "996150a2-45cf-43bd-a04d-5a8134b30b6f", "79dc6069-823a-42d1-97fe-8ec04d4bf95d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9676a9a8-6362-4240-bee8-b36e601b1972", "67c1bd0c-d2a0-44de-ab5d-d3902e660bd5", "Staff", "STAFF" });
        }
    }
}
