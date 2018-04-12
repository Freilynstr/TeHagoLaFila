using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TeHagoLaFila.Data.Migrations
{
    public partial class MigracionDeAhora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservacion_Empleado_EmpleadoID",
                table: "Reservacion");

            migrationBuilder.DropIndex(
                name: "IX_Reservacion_EmpleadoID",
                table: "Reservacion");

            migrationBuilder.DropColumn(
                name: "EmpleadoID",
                table: "Reservacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpleadoID",
                table: "Reservacion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_EmpleadoID",
                table: "Reservacion",
                column: "EmpleadoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservacion_Empleado_EmpleadoID",
                table: "Reservacion",
                column: "EmpleadoID",
                principalTable: "Empleado",
                principalColumn: "EmpleadoID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
