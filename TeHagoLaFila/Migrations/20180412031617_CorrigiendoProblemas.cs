using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TeHagoLaFila.Migrations
{
    public partial class CorrigiendoProblemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservacion_EmpleadoID",
                table: "Reservacion");

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_EmpleadoID",
                table: "Reservacion",
                column: "EmpleadoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Reservacion_EmpleadoID",
                table: "Reservacion");

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_EmpleadoID",
                table: "Reservacion",
                column: "EmpleadoID",
                unique: true);
        }
    }
}
