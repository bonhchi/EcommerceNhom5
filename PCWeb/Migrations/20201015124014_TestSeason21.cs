using Microsoft.EntityFrameworkCore.Migrations;

namespace PCWeb.Migrations
{
    public partial class TestSeason21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a489f8c-7306-40b8-9083-6cc27fa98b12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b2da166-46be-4558-9e34-120417daf89e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1617375-99c6-4032-9c74-0533d769d5b1");

            migrationBuilder.AlterColumn<string>(
                name: "CPUProcess",
                table: "CPUs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CPUCache",
                table: "CPUs",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "CPUProcess",
                table: "CPUs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<double>(
                name: "CPUCache",
                table: "CPUs",
                type: "float",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c1617375-99c6-4032-9c74-0533d769d5b1", "01624e28-1b42-40a6-bac1-2404bfb207a6", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6a489f8c-7306-40b8-9083-6cc27fa98b12", "3ff35cbb-6d46-444a-ab7d-cd6db3a07ffa", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7b2da166-46be-4558-9e34-120417daf89e", "f6b4e6cc-a59b-4a99-9832-3642d9997d72", "Staff", "STAFF" });
        }
    }
}
