using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TeHagoLaFila.Data.Migrations
{
    public partial class ProbandoFKss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_AspNetUsers_ApplicationUserId",
                table: "Empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Negocio_NegocioID1",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_NegocioID1",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "ApplicationUserUserName",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "NegocioID1",
                table: "Empleado");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Empleado",
                newName: "ApplicationUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Empleado_ApplicationUserId",
                table: "Empleado",
                newName: "IX_Empleado_ApplicationUserID");

            migrationBuilder.AddColumn<int>(
                name: "NegocioID",
                table: "Empleado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_NegocioID",
                table: "Empleado",
                column: "NegocioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_AspNetUsers_ApplicationUserID",
                table: "Empleado",
                column: "ApplicationUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Negocio_NegocioID",
                table: "Empleado",
                column: "NegocioID",
                principalTable: "Negocio",
                principalColumn: "NegocioID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_AspNetUsers_ApplicationUserID",
                table: "Empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Negocio_NegocioID",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_NegocioID",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "NegocioID",
                table: "Empleado");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserID",
                table: "Empleado",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Empleado_ApplicationUserID",
                table: "Empleado",
                newName: "IX_Empleado_ApplicationUserId");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserUserName",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NegocioID1",
                table: "Empleado",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_NegocioID1",
                table: "Empleado",
                column: "NegocioID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_AspNetUsers_ApplicationUserId",
                table: "Empleado",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Negocio_NegocioID1",
                table: "Empleado",
                column: "NegocioID1",
                principalTable: "Negocio",
                principalColumn: "NegocioID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
