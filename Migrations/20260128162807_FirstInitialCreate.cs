using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnginePerformance.Migrations
{
    /// <inheritdoc />
    public partial class FirstInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    EngineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cylinders = table.Column<int>(type: "int", nullable: false),
                    Displacement = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxRPM = table.Column<int>(type: "int", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasePower = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BaseTorque = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.EngineId);
                });

            migrationBuilder.CreateTable(
                name: "Turbochargers",
                columns: table => new
                {
                    TurboId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxFlow = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PressureRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turbochargers", x => x.TurboId);
                });

            migrationBuilder.CreateTable(
                name: "EngineTestParameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EngineId = table.Column<int>(type: "int", nullable: false),
                    TestRPM = table.Column<int>(type: "int", nullable: false),
                    LoadPercentage = table.Column<double>(type: "float", nullable: false),
                    FuelConsumption = table.Column<double>(type: "float", nullable: false),
                    ExhaustTemp = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineTestParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EngineTestParameters_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "EngineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TurboSelectionResults",
                columns: table => new
                {
                    ResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EngineId = table.Column<int>(type: "int", nullable: false),
                    TurboId = table.Column<int>(type: "int", nullable: false),
                    CalculatedFlow = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CalculatedPressure = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurboSelectionResults", x => x.ResultId);
                    table.ForeignKey(
                        name: "FK_TurboSelectionResults_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "EngineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TurboSelectionResults_Turbochargers_TurboId",
                        column: x => x.TurboId,
                        principalTable: "Turbochargers",
                        principalColumn: "TurboId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EngineTestParameters_EngineId",
                table: "EngineTestParameters",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_TurboSelectionResults_EngineId",
                table: "TurboSelectionResults",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_TurboSelectionResults_TurboId",
                table: "TurboSelectionResults",
                column: "TurboId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EngineTestParameters");

            migrationBuilder.DropTable(
                name: "TurboSelectionResults");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "Turbochargers");
        }
    }
}
