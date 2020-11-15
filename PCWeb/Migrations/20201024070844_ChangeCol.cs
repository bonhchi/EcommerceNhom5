using Microsoft.EntityFrameworkCore.Migrations;

namespace PCWeb.Migrations
{
    public partial class ChangeCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_PCComponents_PCComponentId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Coolings_PCComponents_PCComponentId",
                table: "Coolings");

            migrationBuilder.DropForeignKey(
                name: "FK_Drives_PCComponents_PCComponentId",
                table: "Drives");

            migrationBuilder.DropForeignKey(
                name: "FK_Graphics_PCComponents_PCComponentId",
                table: "Graphics");

            migrationBuilder.DropForeignKey(
                name: "FK_Mainboards_PCComponents_PCComponentId",
                table: "Mainboards");

            migrationBuilder.DropForeignKey(
                name: "FK_Memories_PCComponents_PCComponentId",
                table: "Memories");

            migrationBuilder.DropForeignKey(
                name: "FK_Powers_PCComponents_PCComponentId",
                table: "Powers");

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
                name: "ComponentId",
                table: "Powers");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "Memories");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "Mainboards");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "Graphics");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "Drives");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "Coolings");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "Cases");

            migrationBuilder.AlterColumn<int>(
                name: "PCComponentId",
                table: "Powers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PCComponentId",
                table: "Memories",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PCComponentId",
                table: "Mainboards",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PCComponentId",
                table: "Graphics",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PCComponentId",
                table: "Drives",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PCComponentId",
                table: "Coolings",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PCComponentId",
                table: "Cases",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_PCComponents_PCComponentId",
                table: "Cases",
                column: "PCComponentId",
                principalTable: "PCComponents",
                principalColumn: "PCComponentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Coolings_PCComponents_PCComponentId",
                table: "Coolings",
                column: "PCComponentId",
                principalTable: "PCComponents",
                principalColumn: "PCComponentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drives_PCComponents_PCComponentId",
                table: "Drives",
                column: "PCComponentId",
                principalTable: "PCComponents",
                principalColumn: "PCComponentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Graphics_PCComponents_PCComponentId",
                table: "Graphics",
                column: "PCComponentId",
                principalTable: "PCComponents",
                principalColumn: "PCComponentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mainboards_PCComponents_PCComponentId",
                table: "Mainboards",
                column: "PCComponentId",
                principalTable: "PCComponents",
                principalColumn: "PCComponentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Memories_PCComponents_PCComponentId",
                table: "Memories",
                column: "PCComponentId",
                principalTable: "PCComponents",
                principalColumn: "PCComponentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Powers_PCComponents_PCComponentId",
                table: "Powers",
                column: "PCComponentId",
                principalTable: "PCComponents",
                principalColumn: "PCComponentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_PCComponents_PCComponentId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Coolings_PCComponents_PCComponentId",
                table: "Coolings");

            migrationBuilder.DropForeignKey(
                name: "FK_Drives_PCComponents_PCComponentId",
                table: "Drives");

            migrationBuilder.DropForeignKey(
                name: "FK_Graphics_PCComponents_PCComponentId",
                table: "Graphics");

            migrationBuilder.DropForeignKey(
                name: "FK_Mainboards_PCComponents_PCComponentId",
                table: "Mainboards");

            migrationBuilder.DropForeignKey(
                name: "FK_Memories_PCComponents_PCComponentId",
                table: "Memories");

            migrationBuilder.DropForeignKey(
                name: "FK_Powers_PCComponents_PCComponentId",
                table: "Powers");

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

            migrationBuilder.AlterColumn<int>(
                name: "PCComponentId",
                table: "Powers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "Powers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PCComponentId",
                table: "Memories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "Memories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PCComponentId",
                table: "Mainboards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "Mainboards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PCComponentId",
                table: "Graphics",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "Graphics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PCComponentId",
                table: "Drives",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "Drives",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PCComponentId",
                table: "Coolings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "Coolings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PCComponentId",
                table: "Cases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "Cases",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_PCComponents_PCComponentId",
                table: "Cases",
                column: "PCComponentId",
                principalTable: "PCComponents",
                principalColumn: "PCComponentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coolings_PCComponents_PCComponentId",
                table: "Coolings",
                column: "PCComponentId",
                principalTable: "PCComponents",
                principalColumn: "PCComponentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Drives_PCComponents_PCComponentId",
                table: "Drives",
                column: "PCComponentId",
                principalTable: "PCComponents",
                principalColumn: "PCComponentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Graphics_PCComponents_PCComponentId",
                table: "Graphics",
                column: "PCComponentId",
                principalTable: "PCComponents",
                principalColumn: "PCComponentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Mainboards_PCComponents_PCComponentId",
                table: "Mainboards",
                column: "PCComponentId",
                principalTable: "PCComponents",
                principalColumn: "PCComponentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Memories_PCComponents_PCComponentId",
                table: "Memories",
                column: "PCComponentId",
                principalTable: "PCComponents",
                principalColumn: "PCComponentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Powers_PCComponents_PCComponentId",
                table: "Powers",
                column: "PCComponentId",
                principalTable: "PCComponents",
                principalColumn: "PCComponentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
