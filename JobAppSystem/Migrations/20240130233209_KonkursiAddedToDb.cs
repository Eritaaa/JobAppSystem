using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobAppSystem.Migrations
{
    /// <inheritdoc />
    public partial class KonkursiAddedToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NrTelefonit",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Qyteti",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Konkurset",
                columns: table => new
                {
                    KonkursiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nvarchar250 = table.Column<string>(name: "nvarchar(250)", type: "nvarchar(max)", nullable: false),
                    varchar100 = table.Column<string>(name: "varchar(100)", type: "nvarchar(max)", nullable: false),
                    EksperiencaENevojshme = table.Column<int>(type: "int", nullable: false),
                    DataEHapjes = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataEMbylljes = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konkurset", x => x.KonkursiId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Konkurset");

            migrationBuilder.DropColumn(
                name: "NrTelefonit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Qyteti",
                table: "AspNetUsers");
        }
    }
}
