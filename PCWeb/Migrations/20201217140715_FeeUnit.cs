using Microsoft.EntityFrameworkCore.Migrations;

namespace PCWeb.Migrations
{
    public partial class FeeUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74979050-d53b-43ad-bd22-3f40f946477d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a01f2494-8694-4fc5-9709-819022c8d396");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb09010a-b1e0-4c72-b9f7-cd9448814002");

            migrationBuilder.AddColumn<string>(
                name: "FeeUnit",
                table: "Fees",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "716bb314-ca10-4c6d-9737-eb546348dbdf", "84d75a40-fb5f-4acd-a65a-61fb303567ad", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8c0e6bf7-cc3e-40ae-8e3e-b39614bb5ecd", "cd5b841a-f0db-4a30-8730-d6ec02fb9962", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "00e342fb-3a93-4a47-b3e7-7b5d317ea849", "f4836431-0e79-4a8e-864d-7335a5e7e893", "Staff", "STAFF" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00e342fb-3a93-4a47-b3e7-7b5d317ea849");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "716bb314-ca10-4c6d-9737-eb546348dbdf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c0e6bf7-cc3e-40ae-8e3e-b39614bb5ecd");

            migrationBuilder.DropColumn(
                name: "FeeUnit",
                table: "Fees");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bb09010a-b1e0-4c72-b9f7-cd9448814002", "556723c9-c894-4421-9f07-37bd5a03297e", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "74979050-d53b-43ad-bd22-3f40f946477d", "9d701b29-de55-42ce-9313-9b61301e2778", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a01f2494-8694-4fc5-9709-819022c8d396", "929d75f7-6eb7-4983-9ba4-ab894a12cee3", "Staff", "STAFF" });
        }
    }
}
