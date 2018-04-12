using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TeHagoLaFila.Data.Migrations
{
    public partial class ProbandoFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_CategoriaUsuario_CategoriaEmpleadoID1",
                table: "Empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_AspNetUsers_UserNameId",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_CategoriaEmpleadoID1",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_UserNameId",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "CategoriaEmpleadoID1",
                table: "Empleado");

            migrationBuilder.RenameColumn(
                name: "UserNameId",
                table: "Empleado",
                newName: "ApplicationUserUserName");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserUserName",
                table: "Empleado",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaEmpleadoID",
                table: "Empleado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_ApplicationUserId",
                table: "Empleado",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_CategoriaEmpleadoID",
                table: "Empleado",
                column: "CategoriaEmpleadoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_AspNetUsers_ApplicationUserId",
                table: "Empleado",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_CategoriaUsuario_CategoriaEmpleadoID",
                table: "Empleado",
                column: "CategoriaEmpleadoID",
                principalTable: "CategoriaUsuario",
                principalColumn: "CategoriaEmpleadoID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_AspNetUsers_ApplicationUserId",
                table: "Empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_CategoriaUsuario_CategoriaEmpleadoID",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_ApplicationUserId",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_CategoriaEmpleadoID",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "CategoriaEmpleadoID",
                table: "Empleado");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserUserName",
                table: "Empleado",
                newName: "UserNameId");

            migrationBuilder.AlterColumn<string>(
                name: "UserNameId",
                table: "Empleado",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaEmpleadoID1",
                table: "Empleado",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_CategoriaEmpleadoID1",
                table: "Empleado",
                column: "CategoriaEmpleadoID1");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_UserNameId",
                table: "Empleado",
                column: "UserNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_CategoriaUsuario_CategoriaEmpleadoID1",
                table: "Empleado",
                column: "CategoriaEmpleadoID1",
                principalTable: "CategoriaUsuario",
                principalColumn: "CategoriaEmpleadoID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_AspNetUsers_UserNameId",
                table: "Empleado",
                column: "UserNameId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
