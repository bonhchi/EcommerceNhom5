using Microsoft.EntityFrameworkCore.Migrations;

namespace PCWeb.Migrations
{
    public partial class Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<double>(
                name: "ProductPriceReality",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "PromotionDetail",
                columns: table => new
                {
                    PromotionDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    PromotionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionDetail", x => x.PromotionDetailId);
                    table.ForeignKey(
                        name: "FK_PromotionDetail_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromotionDetail_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "PromotionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9b6dc0e2-80c3-41f5-88bb-637c8235d5a5", "d32640a5-bb6c-4194-b754-5569e53e751a", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5b9498a4-2ea0-4b4f-b158-61bf8a19d40a", "5f1a6fe4-e7ea-4322-8954-3576835037c9", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fbce578a-aec7-47a2-9798-acd998309e9e", "387fb3ef-71ab-400d-ba7c-fb0221694c19", "Staff", "STAFF" });

            migrationBuilder.CreateIndex(
                name: "IX_PromotionDetail_ProductId",
                table: "PromotionDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionDetail_PromotionId",
                table: "PromotionDetail",
                column: "PromotionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromotionDetail");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b9498a4-2ea0-4b4f-b158-61bf8a19d40a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b6dc0e2-80c3-41f5-88bb-637c8235d5a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbce578a-aec7-47a2-9798-acd998309e9e");

            migrationBuilder.DropColumn(
                name: "ProductPriceReality",
                table: "Products");

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
    }
}
