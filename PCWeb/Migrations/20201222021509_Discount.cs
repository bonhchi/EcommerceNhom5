using Microsoft.EntityFrameworkCore.Migrations;

namespace PCWeb.Migrations
{
    public partial class Discount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromotionDetail_Products_ProductId",
                table: "PromotionDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_PromotionDetail_Promotions_PromotionId",
                table: "PromotionDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PromotionDetail",
                table: "PromotionDetail");

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
                name: "PromotionApply",
                table: "Promotions");

            migrationBuilder.RenameTable(
                name: "PromotionDetail",
                newName: "PromotionDetails");

            migrationBuilder.RenameIndex(
                name: "IX_PromotionDetail_PromotionId",
                table: "PromotionDetails",
                newName: "IX_PromotionDetails_PromotionId");

            migrationBuilder.RenameIndex(
                name: "IX_PromotionDetail_ProductId",
                table: "PromotionDetails",
                newName: "IX_PromotionDetails_ProductId");

            migrationBuilder.AddColumn<double>(
                name: "PromotionDiscount",
                table: "Promotions",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PromotionDetails",
                table: "PromotionDetails",
                column: "PromotionDetailId");

            migrationBuilder.CreateTable(
                name: "Gifts",
                columns: table => new
                {
                    GiftId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiftName = table.Column<string>(nullable: true),
                    PromotionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gifts", x => x.GiftId);
                    table.ForeignKey(
                        name: "FK_Gifts_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "PromotionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5502be66-a9e2-4a93-adea-2667e0e80919", "a428a566-d1ef-4868-ab62-809dc73e835b", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "221eaac1-863c-4b28-ae35-1fd34d72be9d", "a182775f-a2cf-4b82-8e7e-468aeaa99419", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5c73a77d-23b6-416e-84e5-a0e870d8e111", "ed397193-d30f-47a2-a5bd-24bd35a26ce5", "Staff", "STAFF" });

            migrationBuilder.CreateIndex(
                name: "IX_Gifts_PromotionId",
                table: "Gifts",
                column: "PromotionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionDetails_Products_ProductId",
                table: "PromotionDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionDetails_Promotions_PromotionId",
                table: "PromotionDetails",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "PromotionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromotionDetails_Products_ProductId",
                table: "PromotionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PromotionDetails_Promotions_PromotionId",
                table: "PromotionDetails");

            migrationBuilder.DropTable(
                name: "Gifts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PromotionDetails",
                table: "PromotionDetails");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "221eaac1-863c-4b28-ae35-1fd34d72be9d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5502be66-a9e2-4a93-adea-2667e0e80919");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c73a77d-23b6-416e-84e5-a0e870d8e111");

            migrationBuilder.DropColumn(
                name: "PromotionDiscount",
                table: "Promotions");

            migrationBuilder.RenameTable(
                name: "PromotionDetails",
                newName: "PromotionDetail");

            migrationBuilder.RenameIndex(
                name: "IX_PromotionDetails_PromotionId",
                table: "PromotionDetail",
                newName: "IX_PromotionDetail_PromotionId");

            migrationBuilder.RenameIndex(
                name: "IX_PromotionDetails_ProductId",
                table: "PromotionDetail",
                newName: "IX_PromotionDetail_ProductId");

            migrationBuilder.AddColumn<string>(
                name: "PromotionApply",
                table: "Promotions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PromotionDetail",
                table: "PromotionDetail",
                column: "PromotionDetailId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionDetail_Products_ProductId",
                table: "PromotionDetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionDetail_Promotions_PromotionId",
                table: "PromotionDetail",
                column: "PromotionId",
                principalTable: "Promotions",
                principalColumn: "PromotionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
