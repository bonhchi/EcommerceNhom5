using Microsoft.EntityFrameworkCore.Migrations;

namespace PCWeb.Migrations
{
    public partial class TestSeason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Products_ProductId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Coolings_Products_ProductId",
                table: "Coolings");

            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_Products_ProductId",
                table: "CPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_Drives_Products_ProductId",
                table: "Drives");

            migrationBuilder.DropForeignKey(
                name: "FK_Graphics_Products_ProductId",
                table: "Graphics");

            migrationBuilder.DropForeignKey(
                name: "FK_Mainboards_Products_ProductId",
                table: "Mainboards");

            migrationBuilder.DropForeignKey(
                name: "FK_Memories_Products_ProductId",
                table: "Memories");

            migrationBuilder.DropForeignKey(
                name: "FK_Powers_Products_ProductId",
                table: "Powers");

            migrationBuilder.DropIndex(
                name: "IX_Powers_ProductId",
                table: "Powers");

            migrationBuilder.DropIndex(
                name: "IX_Memories_ProductId",
                table: "Memories");

            migrationBuilder.DropIndex(
                name: "IX_Mainboards_ProductId",
                table: "Mainboards");

            migrationBuilder.DropIndex(
                name: "IX_Graphics_ProductId",
                table: "Graphics");

            migrationBuilder.DropIndex(
                name: "IX_Drives_ProductId",
                table: "Drives");

            migrationBuilder.DropIndex(
                name: "IX_CPUs_ProductId",
                table: "CPUs");

            migrationBuilder.DropIndex(
                name: "IX_Coolings_ProductId",
                table: "Coolings");

            migrationBuilder.DropIndex(
                name: "IX_Cases_ProductId",
                table: "Cases");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47531ce3-a666-4746-8c8f-b38e1fa6df6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6037e2e9-6217-4744-ad63-335fd2aa11cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5e8ef52-f434-43e0-9172-53b86b489f58");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Powers");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Memories");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Mainboards");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Graphics");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Drives");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "CPUs");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Coolings");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Cases");

            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "Powers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PCComponentId",
                table: "Powers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "Memories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PCComponentId",
                table: "Memories",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "Mainboards",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PCComponentId",
                table: "Mainboards",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "Graphics",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PCComponentId",
                table: "Graphics",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "Drives",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PCComponentId",
                table: "Drives",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "CPUs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PCComponentId",
                table: "CPUs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "Coolings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PCComponentId",
                table: "Coolings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "Cases",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PCComponentId",
                table: "Cases",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PCComponents",
                columns: table => new
                {
                    PCComponentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ComponentCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCComponents", x => x.PCComponentId);
                    table.ForeignKey(
                        name: "FK_PCComponents_ComponentCategories_ComponentCategoryId",
                        column: x => x.ComponentCategoryId,
                        principalTable: "ComponentCategories",
                        principalColumn: "ComponentCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PCComponents_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "83ce7762-1055-4756-927e-75b7bc30eec1", "3cfe1db6-7515-4dd5-992f-407d2d0ba019", "Customer", "CUSTOMER" },
                    { "de94e868-6905-4411-b746-a7d23be75a57", "e69260d5-6c5e-4860-9387-4b8e7a417c78", "Administrator", "ADMINISTRATOR" },
                    { "d9870234-ae8e-4a43-8c16-dce5754888d8", "0aae9a07-c7aa-45c3-bb2b-fb401666aad2", "Staff", "STAFF" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Linh kiện máy tính" });

            migrationBuilder.CreateIndex(
                name: "IX_Powers_PCComponentId",
                table: "Powers",
                column: "PCComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Memories_PCComponentId",
                table: "Memories",
                column: "PCComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Mainboards_PCComponentId",
                table: "Mainboards",
                column: "PCComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Graphics_PCComponentId",
                table: "Graphics",
                column: "PCComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Drives_PCComponentId",
                table: "Drives",
                column: "PCComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_PCComponentId",
                table: "CPUs",
                column: "PCComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Coolings_PCComponentId",
                table: "Coolings",
                column: "PCComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_PCComponentId",
                table: "Cases",
                column: "PCComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_PCComponents_ComponentCategoryId",
                table: "PCComponents",
                column: "ComponentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PCComponents_ProductId",
                table: "PCComponents",
                column: "ProductId");

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
                name: "FK_CPUs_PCComponents_PCComponentId",
                table: "CPUs",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_PCComponents_PCComponentId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_Coolings_PCComponents_PCComponentId",
                table: "Coolings");

            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_PCComponents_PCComponentId",
                table: "CPUs");

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

            migrationBuilder.DropTable(
                name: "PCComponents");

            migrationBuilder.DropIndex(
                name: "IX_Powers_PCComponentId",
                table: "Powers");

            migrationBuilder.DropIndex(
                name: "IX_Memories_PCComponentId",
                table: "Memories");

            migrationBuilder.DropIndex(
                name: "IX_Mainboards_PCComponentId",
                table: "Mainboards");

            migrationBuilder.DropIndex(
                name: "IX_Graphics_PCComponentId",
                table: "Graphics");

            migrationBuilder.DropIndex(
                name: "IX_Drives_PCComponentId",
                table: "Drives");

            migrationBuilder.DropIndex(
                name: "IX_CPUs_PCComponentId",
                table: "CPUs");

            migrationBuilder.DropIndex(
                name: "IX_Coolings_PCComponentId",
                table: "Coolings");

            migrationBuilder.DropIndex(
                name: "IX_Cases_PCComponentId",
                table: "Cases");

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

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "Powers");

            migrationBuilder.DropColumn(
                name: "PCComponentId",
                table: "Powers");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "Memories");

            migrationBuilder.DropColumn(
                name: "PCComponentId",
                table: "Memories");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "Mainboards");

            migrationBuilder.DropColumn(
                name: "PCComponentId",
                table: "Mainboards");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "Graphics");

            migrationBuilder.DropColumn(
                name: "PCComponentId",
                table: "Graphics");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "Drives");

            migrationBuilder.DropColumn(
                name: "PCComponentId",
                table: "Drives");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "CPUs");

            migrationBuilder.DropColumn(
                name: "PCComponentId",
                table: "CPUs");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "Coolings");

            migrationBuilder.DropColumn(
                name: "PCComponentId",
                table: "Coolings");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "PCComponentId",
                table: "Cases");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Powers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Memories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Mainboards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Graphics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Drives",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "CPUs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Coolings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Cases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6037e2e9-6217-4744-ad63-335fd2aa11cf", "fc051f17-1b13-4d1d-bfa9-1c3dfc6b280f", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a5e8ef52-f434-43e0-9172-53b86b489f58", "fc9a9d03-74df-40fb-a421-51c8f91e01eb", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "47531ce3-a666-4746-8c8f-b38e1fa6df6b", "8cdda386-5b73-410a-b241-529fbfac39b6", "Staff", "STAFF" });

            migrationBuilder.CreateIndex(
                name: "IX_Powers_ProductId",
                table: "Powers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Memories_ProductId",
                table: "Memories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Mainboards_ProductId",
                table: "Mainboards",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Graphics_ProductId",
                table: "Graphics",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Drives_ProductId",
                table: "Drives",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_ProductId",
                table: "CPUs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Coolings_ProductId",
                table: "Coolings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ProductId",
                table: "Cases",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Products_ProductId",
                table: "Cases",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Coolings_Products_ProductId",
                table: "Coolings",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CPUs_Products_ProductId",
                table: "CPUs",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drives_Products_ProductId",
                table: "Drives",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Graphics_Products_ProductId",
                table: "Graphics",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mainboards_Products_ProductId",
                table: "Mainboards",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Memories_Products_ProductId",
                table: "Memories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Powers_Products_ProductId",
                table: "Powers",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
