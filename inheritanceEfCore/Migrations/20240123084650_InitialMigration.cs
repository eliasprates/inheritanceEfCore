using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inheritanceEfCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarsTpc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfDoors = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarsTpc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotorcyclesTpc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasFairing = table.Column<bool>(type: "bit", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorcyclesTpc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiclesTph",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    NumberOfDoors = table.Column<int>(type: "int", nullable: true),
                    HasFairing = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesTph", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiclesTpt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesTpt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarsTpt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NumberOfDoors = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarsTpt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarsTpt_VehiclesTpt_Id",
                        column: x => x.Id,
                        principalTable: "VehiclesTpt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarsTpt_VehiclesTpt_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VehiclesTpt",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MotorcyclesTpt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    HasFairing = table.Column<bool>(type: "bit", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotorcyclesTpt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotorcyclesTpt_VehiclesTpt_Id",
                        column: x => x.Id,
                        principalTable: "VehiclesTpt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MotorcyclesTpt_VehiclesTpt_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VehiclesTpt",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarsTpt_VehicleId",
                table: "CarsTpt",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_MotorcyclesTpt_VehicleId",
                table: "MotorcyclesTpt",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarsTpc");

            migrationBuilder.DropTable(
                name: "CarsTpt");

            migrationBuilder.DropTable(
                name: "MotorcyclesTpc");

            migrationBuilder.DropTable(
                name: "MotorcyclesTpt");

            migrationBuilder.DropTable(
                name: "VehiclesTph");

            migrationBuilder.DropTable(
                name: "VehiclesTpt");
        }
    }
}
