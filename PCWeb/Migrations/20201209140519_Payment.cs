using Microsoft.EntityFrameworkCore.Migrations;

namespace PCWeb.Migrations
{
    public partial class Payment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethodName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.PaymentMethodId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c3a189dd-fb87-42d8-a153-0581121d5fb6", "a9680fc0-d0a8-46d2-9d10-1de24c88dc13", "Customer", "CUSTOMER" },
                    { "4d8a5f6b-1d34-41a0-8382-8d50201b56b2", "ba45e259-af7e-4361-8565-7e98081de934", "Administrator", "ADMINISTRATOR" },
                    { "cf21ef59-b232-45d2-a84c-4e38e18ceaa4", "a0a24131-e022-4271-b359-5971c2c188d8", "Staff", "STAFF" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "PaymentMethodId", "PaymentMethodName" },
                values: new object[,]
                {
                    { 1, "Tiền mặt" },
                    { 2, "Paypal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentMethodId",
                table: "Orders",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_PaymentMethods_PaymentMethodId",
                table: "Orders",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "PaymentMethodId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_PaymentMethods_PaymentMethodId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentMethodId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d8a5f6b-1d34-41a0-8382-8d50201b56b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3a189dd-fb87-42d8-a153-0581121d5fb6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf21ef59-b232-45d2-a84c-4e38e18ceaa4");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                table: "Orders");

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
    }
}
