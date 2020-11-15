using Microsoft.EntityFrameworkCore.Migrations;

namespace PCWeb.Migrations
{
    public partial class TestSeason22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e381881-a43a-4c3a-9b64-4e25ff637b55");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4da88d75-303e-4f92-b75a-f43426620ec6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdc6787d-5e7b-4009-a7b4-50ba9615cab0");

            migrationBuilder.AddColumn<string>(
                name: "PCComponentName",
                table: "PCComponents",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c50cbe1c-5608-48c7-8c66-31183c08ae4c", "fea4ae9e-e180-4b42-968e-42a507efd5b1", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "156012f9-afe7-406f-ab36-38bb8617a51d", "59864df5-4aeb-4541-b769-c9d1570f66a0", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b91982ac-32b2-4535-960a-b21bf65e95c6", "a0d5fbe3-9cc1-4c7a-9b8b-6115d09158bc", "Staff", "STAFF" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "156012f9-afe7-406f-ab36-38bb8617a51d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b91982ac-32b2-4535-960a-b21bf65e95c6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c50cbe1c-5608-48c7-8c66-31183c08ae4c");

            migrationBuilder.DropColumn(
                name: "PCComponentName",
                table: "PCComponents");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4da88d75-303e-4f92-b75a-f43426620ec6", "30dc06ad-9fab-45bd-93df-e9ebf4dce6c3", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bdc6787d-5e7b-4009-a7b4-50ba9615cab0", "bc690737-b086-470b-bb8e-a9c425c1f30d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1e381881-a43a-4c3a-9b64-4e25ff637b55", "e5427b2f-b748-470f-82be-80705ea74bfb", "Staff", "STAFF" });
        }
    }
}
