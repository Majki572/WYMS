using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WYMS_Zaliczenie_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Surface = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Warehouses_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Warehouses_Warehouses_ID",
                        column: x => x.Warehouses_ID,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Warehouses_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    DateFrom = table.Column<string>(type: "TEXT", nullable: false),
                    DateTo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                    table.ForeignKey(
                        name: "FK_Schedules_Warehouses_Warehouses_ID",
                        column: x => x.Warehouses_ID,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    ShopId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Schedules_ID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.ShopId);
                    table.ForeignKey(
                        name: "FK_Shops_Schedules_Schedules_ID",
                        column: x => x.Schedules_ID,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Capacity = table.Column<double>(type: "REAL", nullable: false),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false),
                    Warehouses_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Schedules_ID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicles_Schedules_Schedules_ID",
                        column: x => x.Schedules_ID,
                        principalTable: "Schedules",
                        principalColumn: "ScheduleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Warehouses_Warehouses_ID",
                        column: x => x.Warehouses_ID,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Shops_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Warehouses_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    PaymentValue = table.Column<double>(type: "REAL", nullable: false),
                    DateFrom = table.Column<string>(type: "TEXT", nullable: true),
                    DateTo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_Shops_Shops_ID",
                        column: x => x.Shops_ID,
                        principalTable: "Shops",
                        principalColumn: "ShopId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Warehouses_Warehouses_ID",
                        column: x => x.Warehouses_ID,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    WorkerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    Warehouses_ID = table.Column<int>(type: "INTEGER", nullable: false),
                    Vehicles_ID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.WorkerId);
                    table.ForeignKey(
                        name: "FK_Workers_Vehicles_Vehicles_ID",
                        column: x => x.Vehicles_ID,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Workers_Warehouses_Warehouses_ID",
                        column: x => x.Warehouses_ID,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Shops_ID",
                table: "Payments",
                column: "Shops_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Warehouses_ID",
                table: "Payments",
                column: "Warehouses_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Warehouses_ID",
                table: "Products",
                column: "Warehouses_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_Warehouses_ID",
                table: "Schedules",
                column: "Warehouses_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_Schedules_ID",
                table: "Shops",
                column: "Schedules_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Schedules_ID",
                table: "Vehicles",
                column: "Schedules_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_Warehouses_ID",
                table: "Vehicles",
                column: "Warehouses_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_Vehicles_ID",
                table: "Workers",
                column: "Vehicles_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Workers_Warehouses_ID",
                table: "Workers",
                column: "Warehouses_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
