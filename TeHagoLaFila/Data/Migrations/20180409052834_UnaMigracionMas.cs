using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TeHagoLaFila.Data.Migrations
{
    public partial class UnaMigracionMas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_AspNetUsers_ApplicationUserID",
                table: "Empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservacion_Empleado_EmpleadoID1",
                table: "Reservacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservacion_AspNetUsers_UserNameId",
                table: "Reservacion");

            migrationBuilder.DropIndex(
                name: "IX_Reservacion_EmpleadoID1",
                table: "Reservacion");

            migrationBuilder.DropIndex(
                name: "IX_Reservacion_UserNameId",
                table: "Reservacion");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "CategoriaNegocio");

            migrationBuilder.RenameColumn(
                name: "UserNameId",
                table: "Reservacion",
                newName: "ApplicationUserID");

            migrationBuilder.RenameColumn(
                name: "InitialTime",
                table: "Reservacion",
                newName: "InitialServiceTime");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "Reservacion",
                newName: "InitialReservationTime");

            migrationBuilder.RenameColumn(
                name: "EmpleadoID1",
                table: "Reservacion",
                newName: "EmpleadoID");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "Reservacion",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndAllTimes",
                table: "Reservacion",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "Empleado",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_AspNetUsers_ApplicationUserID",
                table: "Empleado",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_AspNetUsers_ApplicationUserID",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "EndAllTimes",
                table: "Reservacion");

            migrationBuilder.RenameColumn(
                name: "InitialServiceTime",
                table: "Reservacion",
                newName: "InitialTime");

            migrationBuilder.RenameColumn(
                name: "InitialReservationTime",
                table: "Reservacion",
                newName: "EndTime");

            migrationBuilder.RenameColumn(
                name: "EmpleadoID",
                table: "Reservacion",
                newName: "EmpleadoID1");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "Reservacion",
                newName: "UserNameId");

            migrationBuilder.AlterColumn<string>(
                name: "UserNameId",
                table: "Reservacion",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserID",
                table: "Empleado",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "CategoriaNegocio",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_EmpleadoID1",
                table: "Reservacion",
                column: "EmpleadoID1");

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_UserNameId",
                table: "Reservacion",
                column: "UserNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_AspNetUsers_ApplicationUserID",
                table: "Empleado",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservacion_Empleado_EmpleadoID1",
                table: "Reservacion",
                column: "EmpleadoID1",
                principalTable: "Empleado",
                principalColumn: "EmpleadoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservacion_AspNetUsers_UserNameId",
                table: "Reservacion",
                column: "UserNameId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
