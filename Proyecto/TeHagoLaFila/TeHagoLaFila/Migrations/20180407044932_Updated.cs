using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TeHagoLaFila.Migrations
{
    public partial class Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Negocio_CategoriaNegocio_CategoriaIDCategoriaNegocioID",
                table: "Negocio");

            migrationBuilder.RenameColumn(
                name: "CategoriaIDCategoriaNegocioID",
                table: "Negocio",
                newName: "IDCategoriaNegocioID");

            migrationBuilder.RenameIndex(
                name: "IX_Negocio_CategoriaIDCategoriaNegocioID",
                table: "Negocio",
                newName: "IX_Negocio_IDCategoriaNegocioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Negocio_CategoriaNegocio_IDCategoriaNegocioID",
                table: "Negocio",
                column: "IDCategoriaNegocioID",
                principalTable: "CategoriaNegocio",
                principalColumn: "CategoriaNegocioID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Negocio_CategoriaNegocio_IDCategoriaNegocioID",
                table: "Negocio");

            migrationBuilder.RenameColumn(
                name: "IDCategoriaNegocioID",
                table: "Negocio",
                newName: "CategoriaIDCategoriaNegocioID");

            migrationBuilder.RenameIndex(
                name: "IX_Negocio_IDCategoriaNegocioID",
                table: "Negocio",
                newName: "IX_Negocio_CategoriaIDCategoriaNegocioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Negocio_CategoriaNegocio_CategoriaIDCategoriaNegocioID",
                table: "Negocio",
                column: "CategoriaIDCategoriaNegocioID",
                principalTable: "CategoriaNegocio",
                principalColumn: "CategoriaNegocioID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
