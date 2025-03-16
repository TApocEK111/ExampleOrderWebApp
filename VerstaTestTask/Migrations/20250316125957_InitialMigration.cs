using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VerstaTestTask.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SenderCity = table.Column<string>(type: "TEXT", maxLength: 170, nullable: false),
                    SenderAdress = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    RecieverCity = table.Column<string>(type: "TEXT", maxLength: 170, nullable: false),
                    RecieverAdress = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    WeightInGrams = table.Column<double>(type: "REAL", nullable: false),
                    PickUpDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
