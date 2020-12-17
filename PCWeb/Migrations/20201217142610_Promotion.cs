using Microsoft.EntityFrameworkCore.Migrations;

namespace PCWeb.Migrations
{
    public partial class Promotion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "PromotionCodeNeed",
                table: "Promotions");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bb44f738-d3ea-4883-a80c-7ccc69102eb9", "18a919a9-ea53-4249-98d1-22571a5988ec", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2341388a-9d7a-499f-92be-1077c3059d2c", "005642c1-badb-4dc2-a68f-698b50816271", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cee9a515-b909-443b-9f8b-526929c8a678", "1202f039-e42b-45a5-8413-7e0bd07a8d88", "Staff", "STAFF" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2341388a-9d7a-499f-92be-1077c3059d2c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb44f738-d3ea-4883-a80c-7ccc69102eb9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cee9a515-b909-443b-9f8b-526929c8a678");

            migrationBuilder.AddColumn<bool>(
                name: "PromotionCodeNeed",
                table: "Promotions",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
    }
}
