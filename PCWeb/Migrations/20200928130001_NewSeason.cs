using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PCWeb.Migrations
{
    public partial class NewSeason : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    DayOfBirth = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ComponentCategories",
                columns: table => new
                {
                    ComponentCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentCategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentCategories", x => x.ComponentCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(nullable: false),
                    ContactPhone = table.Column<string>(nullable: false),
                    ContactAddress = table.Column<string>(nullable: false),
                    ContactEmail = table.Column<string>(nullable: false),
                    ContactNote = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "LaptopCategories",
                columns: table => new
                {
                    LaptopCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaptopCategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaptopCategories", x => x.LaptopCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "OrderConditions",
                columns: table => new
                {
                    OrderConditionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderConditionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderConditions", x => x.OrderConditionId);
                });

            migrationBuilder.CreateTable(
                name: "PCCategories",
                columns: table => new
                {
                    PCCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PCCategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCCategories", x => x.PCCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(nullable: true),
                    ProductSeries = table.Column<string>(nullable: false),
                    ProductName = table.Column<string>(nullable: false),
                    ProductImage = table.Column<string>(nullable: true),
                    ProductPrice = table.Column<double>(nullable: false),
                    ProductDescription = table.Column<string>(nullable: true),
                    DayCreate = table.Column<DateTime>(nullable: false),
                    ProductWarranty = table.Column<int>(nullable: false),
                    ProductQuantity = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    BrandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CusName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    OrderConditionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_OrderConditions_OrderConditionId",
                        column: x => x.OrderConditionId,
                        principalTable: "OrderConditions",
                        principalColumn: "OrderConditionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    CaseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseSpec = table.Column<string>(nullable: false),
                    CaseSupport = table.Column<string>(nullable: false),
                    CaseDrive = table.Column<string>(nullable: false),
                    CasePort = table.Column<string>(nullable: false),
                    CaseColor = table.Column<string>(nullable: false),
                    CaseMaterial = table.Column<string>(nullable: false),
                    CaseDimension = table.Column<string>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.CaseId);
                    table.ForeignKey(
                        name: "FK_Cases_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Coolings",
                columns: table => new
                {
                    CoolingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    CoolingSpec = table.Column<string>(nullable: false),
                    CoolingSocket = table.Column<string>(nullable: false),
                    CoolingMaterial = table.Column<string>(nullable: false),
                    CoolingLED = table.Column<string>(nullable: false),
                    CoolingDimension = table.Column<string>(nullable: false),
                    CoolingRPM = table.Column<string>(nullable: false),
                    CoolingColor = table.Column<string>(nullable: false),
                    CoolingNoise = table.Column<string>(nullable: false),
                    CoolingWeight = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coolings", x => x.CoolingId);
                    table.ForeignKey(
                        name: "FK_Coolings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CPUs",
                columns: table => new
                {
                    CPUId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    CPUCode = table.Column<string>(nullable: true),
                    CPUModel = table.Column<string>(nullable: true),
                    CPUSocket = table.Column<string>(nullable: true),
                    CPUSpeed = table.Column<double>(nullable: false),
                    CPUTurbo = table.Column<double>(nullable: false),
                    CPUCache = table.Column<double>(nullable: false),
                    CPUCore = table.Column<int>(nullable: false),
                    CPUThread = table.Column<int>(nullable: false),
                    CPUProcess = table.Column<int>(nullable: false),
                    CPUPower = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUs", x => x.CPUId);
                    table.ForeignKey(
                        name: "FK_CPUs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drives",
                columns: table => new
                {
                    DriveId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    DriveSpec = table.Column<string>(nullable: false),
                    DriveCapacity = table.Column<string>(nullable: false),
                    DriveSize = table.Column<string>(nullable: false),
                    DriveConnectivity = table.Column<string>(nullable: false),
                    DriveRead = table.Column<string>(nullable: false),
                    DriveWrite = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drives", x => x.DriveId);
                    table.ForeignKey(
                        name: "FK_Drives_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Graphics",
                columns: table => new
                {
                    GraphicId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    GraphicGPU = table.Column<string>(nullable: false),
                    GraphicSeries = table.Column<string>(nullable: false),
                    GraphicMemory = table.Column<string>(nullable: false),
                    GraphicBus = table.Column<string>(nullable: false),
                    GraphicConnector = table.Column<string>(nullable: false),
                    GraphicMemFrequency = table.Column<string>(nullable: false),
                    GraphicGPUBoost = table.Column<string>(nullable: false),
                    GraphicPCI = table.Column<string>(nullable: false),
                    GraphicCore = table.Column<int>(nullable: false),
                    GraphicMaxMonitor = table.Column<string>(nullable: false),
                    GraphicResolution = table.Column<string>(nullable: false),
                    GraphicPower = table.Column<int>(nullable: false),
                    GraphicMinPower = table.Column<int>(nullable: false),
                    GraphicPort = table.Column<string>(nullable: false),
                    GraphicDimension = table.Column<string>(nullable: false),
                    GraphicCooling = table.Column<string>(nullable: false),
                    GraphicLED = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Graphics", x => x.GraphicId);
                    table.ForeignKey(
                        name: "FK_Graphics_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    LaptopId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    LaptopSeries = table.Column<string>(nullable: false),
                    LaptopCPU = table.Column<string>(nullable: false),
                    LaptopScreen = table.Column<string>(nullable: false),
                    LaptopGPU = table.Column<string>(nullable: false),
                    LaptopRAM = table.Column<string>(nullable: false),
                    LaptopWebcam = table.Column<string>(nullable: false),
                    LaptopStorage = table.Column<string>(nullable: false),
                    LaptopPort = table.Column<string>(nullable: false),
                    LaptopConnectivity = table.Column<string>(nullable: false),
                    LaptopKeyboard = table.Column<string>(nullable: false),
                    LaptopOS = table.Column<string>(nullable: false),
                    LaptopDimension = table.Column<string>(nullable: false),
                    LaptopBattery = table.Column<string>(nullable: false),
                    LaptopWeight = table.Column<string>(nullable: false),
                    LaptopColor = table.Column<string>(nullable: false),
                    LaptopCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.LaptopId);
                    table.ForeignKey(
                        name: "FK_Laptops_LaptopCategories_LaptopCategoryId",
                        column: x => x.LaptopCategoryId,
                        principalTable: "LaptopCategories",
                        principalColumn: "LaptopCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Laptops_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mainboards",
                columns: table => new
                {
                    MainboardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    MainboardModel = table.Column<string>(nullable: false),
                    MainboardCPU = table.Column<string>(nullable: false),
                    MainboardChipset = table.Column<string>(nullable: false),
                    MainboardRAMSupport = table.Column<string>(nullable: false),
                    MainboardBusRAM = table.Column<string>(nullable: false),
                    MainboardSODIMM = table.Column<string>(nullable: false),
                    MainboardRAMStorage = table.Column<string>(nullable: false),
                    MainboardStorage = table.Column<string>(nullable: false),
                    MainboardM2Support = table.Column<string>(nullable: false),
                    MainboardConnection = table.Column<string>(nullable: false),
                    MainboardDisplayPort = table.Column<string>(nullable: false),
                    MainboardPort = table.Column<string>(nullable: false),
                    MainboardPCI = table.Column<string>(nullable: false),
                    MainboardSize = table.Column<string>(nullable: false),
                    MainboardMultiGPU = table.Column<string>(nullable: false),
                    MainboardSoundCard = table.Column<string>(nullable: false),
                    MainboardLED = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mainboards", x => x.MainboardId);
                    table.ForeignKey(
                        name: "FK_Mainboards_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Memories",
                columns: table => new
                {
                    MemoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    MemoryCapacity = table.Column<string>(nullable: false),
                    MemoryBus = table.Column<string>(nullable: false),
                    MemoryGen = table.Column<string>(nullable: false),
                    MemoryLED = table.Column<string>(nullable: false),
                    MemoryColor = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memories", x => x.MemoryId);
                    table.ForeignKey(
                        name: "FK_Memories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PCs",
                columns: table => new
                {
                    PCId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    PCCpu = table.Column<string>(nullable: false),
                    PCMainboard = table.Column<string>(nullable: false),
                    PCRam = table.Column<string>(nullable: false),
                    PCGpu = table.Column<string>(nullable: false),
                    PCStorage = table.Column<string>(nullable: false),
                    PCPsu = table.Column<string>(nullable: false),
                    PCCase = table.Column<string>(nullable: false),
                    PCCooling = table.Column<string>(nullable: false),
                    PCCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCs", x => x.PCId);
                    table.ForeignKey(
                        name: "FK_PCs_PCCategories_PCCategoryId",
                        column: x => x.PCCategoryId,
                        principalTable: "PCCategories",
                        principalColumn: "PCCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PCs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Powers",
                columns: table => new
                {
                    PowerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    PowerCapacity = table.Column<int>(nullable: false),
                    PowerPort = table.Column<string>(nullable: false),
                    PowerEfficiency = table.Column<string>(nullable: false),
                    PowerDimension = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Powers", x => x.PowerId);
                    table.ForeignKey(
                        name: "FK_Powers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    PromotionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    PromotionName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.PromotionId);
                    table.ForeignKey(
                        name: "FK_Promotions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Revenues",
                columns: table => new
                {
                    RevenueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    RevenueTotal = table.Column<double>(nullable: false),
                    RevenueReality = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revenues", x => x.RevenueId);
                    table.ForeignKey(
                        name: "FK_Revenues_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
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
                    { "6037e2e9-6217-4744-ad63-335fd2aa11cf", "fc051f17-1b13-4d1d-bfa9-1c3dfc6b280f", "Customer", "CUSTOMER" },
                    { "a5e8ef52-f434-43e0-9172-53b86b489f58", "fc9a9d03-74df-40fb-a421-51c8f91e01eb", "Administrator", "ADMINISTRATOR" },
                    { "47531ce3-a666-4746-8c8f-b38e1fa6df6b", "8cdda386-5b73-410a-b241-529fbfac39b6", "Staff", "STAFF" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "BrandName" },
                values: new object[,]
                {
                    { 1, "PCBang" },
                    { 2, "PCWorld" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 2, "PC" },
                    { 1, "Laptop" }
                });

            migrationBuilder.InsertData(
                table: "ComponentCategories",
                columns: new[] { "ComponentCategoryId", "ComponentCategoryName" },
                values: new object[,]
                {
                    { 1, "CPU" },
                    { 2, "Card đồ họa" },
                    { 3, "Lưu trữ" },
                    { 4, "Mainboard" },
                    { 5, "Tản nhiệt" },
                    { 6, "RAM" },
                    { 7, "Nguồn" },
                    { 8, "Case Máy tính" }
                });

            migrationBuilder.InsertData(
                table: "LaptopCategories",
                columns: new[] { "LaptopCategoryId", "LaptopCategoryName" },
                values: new object[,]
                {
                    { 4, "Laptop Workstation" },
                    { 5, "Laptop Cũ" },
                    { 1, "Laptop Phổ Thông" },
                    { 2, "Laptop Gaming" },
                    { 3, "Laptop Doanh Nhân" }
                });

            migrationBuilder.InsertData(
                table: "OrderConditions",
                columns: new[] { "OrderConditionId", "OrderConditionName" },
                values: new object[,]
                {
                    { 1, "Đã nhận đơn hàng" },
                    { 2, "Đã xem đơn hàng" },
                    { 3, "Đang đóng gói" },
                    { 4, "Đang vận chuyển" },
                    { 5, "Giao hàng thành công" },
                    { 6, "Đã hủy đơn" }
                });

            migrationBuilder.InsertData(
                table: "PCCategories",
                columns: new[] { "PCCategoryId", "PCCategoryName" },
                values: new object[,]
                {
                    { 1, "PC Văn Phòng" },
                    { 2, "PC Gaming" },
                    { 3, "PC Workstation" },
                    { 4, "PC Đồng bộ" },
                    { 5, "PC Cũ" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ProductId",
                table: "Cases",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Coolings_ProductId",
                table: "Coolings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_ProductId",
                table: "CPUs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Drives_ProductId",
                table: "Drives",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Graphics_ProductId",
                table: "Graphics",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_LaptopCategoryId",
                table: "Laptops",
                column: "LaptopCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_ProductId",
                table: "Laptops",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Mainboards_ProductId",
                table: "Mainboards",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Memories_ProductId",
                table: "Memories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderConditionId",
                table: "Orders",
                column: "OrderConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_PCs_PCCategoryId",
                table: "PCs",
                column: "PCCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PCs_ProductId",
                table: "PCs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Powers_ProductId",
                table: "Powers",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_ProductId",
                table: "Promotions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Revenues_ProductId",
                table: "Revenues",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "ComponentCategories");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Coolings");

            migrationBuilder.DropTable(
                name: "CPUs");

            migrationBuilder.DropTable(
                name: "Drives");

            migrationBuilder.DropTable(
                name: "Graphics");

            migrationBuilder.DropTable(
                name: "Laptops");

            migrationBuilder.DropTable(
                name: "Mainboards");

            migrationBuilder.DropTable(
                name: "Memories");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "PCs");

            migrationBuilder.DropTable(
                name: "Powers");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Revenues");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "LaptopCategories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PCCategories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "OrderConditions");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
