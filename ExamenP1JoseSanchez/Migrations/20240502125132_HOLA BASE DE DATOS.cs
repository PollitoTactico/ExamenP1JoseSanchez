using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenP1JoseSanchez.Migrations
{
    /// <inheritdoc />
    public partial class HOLABASEDEDATOS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrera",
                columns: table => new
                {
                    IdCarrera = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCarrera = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Campus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumSemestre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrera", x => x.IdCarrera);
                });

            migrationBuilder.CreateTable(
                name: "JSanchez",
                columns: table => new
                {
                    IdSanchez = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsdelaUdla = table.Column<bool>(type: "bit", nullable: false),
                    FechaNacimeinto = table.Column<DateOnly>(type: "date", nullable: false),
                    CarreraIdCarrera = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JSanchez", x => x.IdSanchez);
                    table.ForeignKey(
                        name: "FK_JSanchez_Carrera_CarreraIdCarrera",
                        column: x => x.CarreraIdCarrera,
                        principalTable: "Carrera",
                        principalColumn: "IdCarrera",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JSanchez_CarreraIdCarrera",
                table: "JSanchez",
                column: "CarreraIdCarrera");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JSanchez");

            migrationBuilder.DropTable(
                name: "Carrera");
        }
    }
}
