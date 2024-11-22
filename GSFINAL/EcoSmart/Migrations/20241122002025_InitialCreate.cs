using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoSmart.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENERGY_TIPS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Title = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PotentialSavingPercentage = table.Column<decimal>(type: "NUMBER(5,2)", nullable: false),
                    Category = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENERGY_TIPS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Username = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ALERTS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Message = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Type = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IsRead = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALERTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ALERTS_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DEVICES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    DeviceType = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    IsConnected = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    Location = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    LastDataReceived = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEVICES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DEVICES_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ENERGY_CONSUMPTIONS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Timestamp = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ConsumptionValue = table.Column<decimal>(type: "NUMBER(18,2)", nullable: false),
                    Cost = table.Column<decimal>(type: "NUMBER(18,2)", nullable: false),
                    DeviceId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENERGY_CONSUMPTIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ENERGY_CONSUMPTIONS_DEVICES_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "DEVICES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ENERGY_CONSUMPTIONS_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALERTS_UserId",
                table: "ALERTS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DEVICES_UserId_Name",
                table: "DEVICES",
                columns: new[] { "UserId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ENERGY_CONSUMPTIONS_DeviceId",
                table: "ENERGY_CONSUMPTIONS",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_ENERGY_CONSUMPTIONS_UserId",
                table: "ENERGY_CONSUMPTIONS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_USERS_Email",
                table: "USERS",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALERTS");

            migrationBuilder.DropTable(
                name: "ENERGY_CONSUMPTIONS");

            migrationBuilder.DropTable(
                name: "ENERGY_TIPS");

            migrationBuilder.DropTable(
                name: "DEVICES");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
