using Microsoft.EntityFrameworkCore.Migrations;

namespace PCWeb.Migrations
{
    public partial class TestSeason2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_PCComponents_PCComponentId",
                table: "CPUs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83ce7762-1055-4756-927e-75b7bc30eec1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9870234-ae8e-4a43-8c16-dce5754888d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de94e868-6905-4411-b746-a7d23be75a57");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "CPUs");

            migrationBuilder.AlterColumn<int>(
                name: "PCComponentId",
                table: "CPUs",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CPUSocket",
                table: "CPUs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CPUModel",
                table: "CPUs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CPUCode",
                table: "CPUs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_CPUs_PCComponents_PCComponentId",
                table: "CPUs",
                column: "PCComponentId",
                principalTable: "PCComponents",
                principalColumn: "PCComponentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_PCComponents_PCComponentId",
                table: "CPUs");

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

            migrationBuilder.AlterColumn<int>(
                name: "PCComponentId",
                table: "CPUs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "CPUSocket",
                table: "CPUs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CPUModel",
                table: "CPUs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CPUCode",
                table: "CPUs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "CPUs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "83ce7762-1055-4756-927e-75b7bc30eec1", "3cfe1db6-7515-4dd5-992f-407d2d0ba019", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "de94e868-6905-4411-b746-a7d23be75a57", "e69260d5-6c5e-4860-9387-4b8e7a417c78", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d9870234-ae8e-4a43-8c16-dce5754888d8", "0aae9a07-c7aa-45c3-bb2b-fb401666aad2", "Staff", "STAFF" });

            migrationBuilder.AddForeignKey(
                name: "FK_CPUs_PCComponents_PCComponentId",
                table: "CPUs",
                column: "PCComponentId",
                principalTable: "PCComponents",
                principalColumn: "PCComponentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
