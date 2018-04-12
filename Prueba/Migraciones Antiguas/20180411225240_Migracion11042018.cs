using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TeHagoLaFila.Data.Migrations
{
    public partial class Migracion11042018 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "Reservacion",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_ApplicationUserID",
                table: "Reservacion",
                column: "ApplicationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_EmpleadoID",
                table: "Reservacion",
                column: "EmpleadoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservacion_AspNetUsers_ApplicationUserID",
                table: "Reservacion",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservacion_Empleado_EmpleadoID",
                table: "Reservacion",
                column: "EmpleadoID",
                principalTable: "Empleado",
                principalColumn: "EmpleadoID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservacion_AspNetUsers_ApplicationUserID",
                table: "Reservacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservacion_Empleado_EmpleadoID",
                table: "Reservacion");

            migrationBuilder.DropIndex(
                name: "IX_Reservacion_ApplicationUserID",
                table: "Reservacion");

            migrationBuilder.DropIndex(
                name: "IX_Reservacion_EmpleadoID",
                table: "Reservacion");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "Reservacion",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
