using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PCWeb.Migrations
{
    public partial class Revenue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1477a19d-b174-4235-98c6-58e877e2a822");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "311d515c-88ec-4ed6-9d28-18b83ef0f571");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c0699e2-7d0a-4ae2-abbf-362e34d701d2");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Revenues");

            migrationBuilder.DropColumn(
                name: "RevenueReality",
                table: "Revenues");

            migrationBuilder.DropColumn(
                name: "RevenueTotal",
                table: "Revenues");

            migrationBuilder.AddColumn<int>(
                name: "RevenueDetailId",
                table: "Revenues",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RevenueDetails",
                columns: table => new
                {
                    RevenueDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RevenueId = table.Column<int>(nullable: false),
                    DateIssue = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevenueDetails", x => x.RevenueDetailId);
                    table.ForeignKey(
                        name: "FK_RevenueDetails_Revenues_RevenueId",
                        column: x => x.RevenueId,
                        principalTable: "Revenues",
                        principalColumn: "RevenueId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_RevenueDetails_RevenueId",
                table: "RevenueDetails",
                column: "RevenueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RevenueDetails");

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

            migrationBuilder.DropColumn(
                name: "RevenueDetailId",
                table: "Revenues");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Revenues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "RevenueReality",
                table: "Revenues",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "RevenueTotal",
                table: "Revenues",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1477a19d-b174-4235-98c6-58e877e2a822", "647dac87-60f8-44a2-b792-1bbcdc0f97bf", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "311d515c-88ec-4ed6-9d28-18b83ef0f571", "49e33b40-30d3-492a-9965-268d619cd534", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7c0699e2-7d0a-4ae2-abbf-362e34d701d2", "a2a998a5-7674-4c97-b9db-d2cb29f2c24f", "Staff", "STAFF" });
        }
    }
}
