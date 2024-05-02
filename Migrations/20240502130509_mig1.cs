﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvaluacionP1.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrera",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nombreCarrera = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    campus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numeroSemestres = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrera", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MBaquero",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false),
                    mensualidad = table.Column<double>(type: "float", nullable: false),
                    anio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    reprobo = table.Column<bool>(type: "bit", nullable: false),
                    CarreraId = table.Column<int>(type: "int", nullable: false),
                    Carreraid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MBaquero", x => x.id);
                    table.ForeignKey(
                        name: "FK_MBaquero_Carrera_Carreraid",
                        column: x => x.Carreraid,
                        principalTable: "Carrera",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MBaquero_Carreraid",
                table: "MBaquero",
                column: "Carreraid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MBaquero");

            migrationBuilder.DropTable(
                name: "Carrera");
        }
    }
}
