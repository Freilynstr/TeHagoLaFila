using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TeHagoLaFila.Migrations
{
    public partial class CompletdeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    EmpleadoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoriaEmpleadoID1 = table.Column<int>(nullable: true),
                    NegocioID1 = table.Column<int>(nullable: true),
                    UsuarioID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.EmpleadoID);
                    table.ForeignKey(
                        name: "FK_Empleado_CategoriaEmpleado_CategoriaEmpleadoID1",
                        column: x => x.CategoriaEmpleadoID1,
                        principalTable: "CategoriaEmpleado",
                        principalColumn: "CategoriaEmpleadoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empleado_Negocio_NegocioID1",
                        column: x => x.NegocioID1,
                        principalTable: "Negocio",
                        principalColumn: "NegocioID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empleado_Usuario_UsuarioID1",
                        column: x => x.UsuarioID1,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservacion",
                columns: table => new
                {
                    ReservacionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpleadoID1 = table.Column<int>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    InitialTime = table.Column<DateTime>(nullable: false),
                    UsuarioID1 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservacion", x => x.ReservacionID);
                    table.ForeignKey(
                        name: "FK_Reservacion_Empleado_EmpleadoID1",
                        column: x => x.EmpleadoID1,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservacion_Usuario_UsuarioID1",
                        column: x => x.UsuarioID1,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_CategoriaEmpleadoID1",
                table: "Empleado",
                column: "CategoriaEmpleadoID1");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_NegocioID1",
                table: "Empleado",
                column: "NegocioID1");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_UsuarioID1",
                table: "Empleado",
                column: "UsuarioID1");

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_EmpleadoID1",
                table: "Reservacion",
                column: "EmpleadoID1");

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_UsuarioID1",
                table: "Reservacion",
                column: "UsuarioID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Negocio_CategoriaNegocio_CategoriaIDCategoriaNegocioID",
                table: "Negocio",
                column: "CategoriaIDCategoriaNegocioID",
                principalTable: "CategoriaNegocio",
                principalColumn: "CategoriaNegocioID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Negocio_CategoriaNegocio_CategoriaIDCategoriaNegocioID",
                table: "Negocio");

            migrationBuilder.DropTable(
                name: "Reservacion");

            migrationBuilder.DropTable(
                name: "Empleado");

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
    }
}
