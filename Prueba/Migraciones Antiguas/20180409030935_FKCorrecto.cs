using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TeHagoLaFila.Data.Migrations
{
    public partial class FKCorrecto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Negocio_CategoriaNegocio_CategoriaIDCategoriaNegocioID",
                table: "Negocio");

            migrationBuilder.RenameColumn(
                name: "CategoriaIDCategoriaNegocioID",
                table: "Negocio",
                newName: "CategoriaNegocioID");

            migrationBuilder.RenameIndex(
                name: "IX_Negocio_CategoriaIDCategoriaNegocioID",
                table: "Negocio",
                newName: "IX_Negocio_CategoriaNegocioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Negocio_CategoriaNegocio_CategoriaNegocioID",
                table: "Negocio",
                column: "CategoriaNegocioID",
                principalTable: "CategoriaNegocio",
                principalColumn: "CategoriaNegocioID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Negocio_CategoriaNegocio_CategoriaNegocioID",
                table: "Negocio");

            migrationBuilder.RenameColumn(
                name: "CategoriaNegocioID",
                table: "Negocio",
                newName: "CategoriaIDCategoriaNegocioID");

            migrationBuilder.RenameIndex(
                name: "IX_Negocio_CategoriaNegocioID",
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
