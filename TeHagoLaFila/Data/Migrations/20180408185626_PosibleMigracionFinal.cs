using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TeHagoLaFila.Data.Migrations
{
    public partial class PosibleMigracionFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Negocio");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "CategoriaUsuario");

            migrationBuilder.RenameColumn(
                name: "CategoriaUsuarioID",
                table: "CategoriaUsuario",
                newName: "CategoriaEmpleadoID");

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Negocio",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AddColumn<int>(
                name: "CategoriaIDCategoriaNegocioID",
                table: "Negocio",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    EmpleadoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoriaEmpleadoID1 = table.Column<int>(nullable: true),
                    NegocioID1 = table.Column<int>(nullable: true),
                    UserNameId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.EmpleadoID);
                    table.ForeignKey(
                        name: "FK_Empleado_CategoriaUsuario_CategoriaEmpleadoID1",
                        column: x => x.CategoriaEmpleadoID1,
                        principalTable: "CategoriaUsuario",
                        principalColumn: "CategoriaEmpleadoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empleado_Negocio_NegocioID1",
                        column: x => x.NegocioID1,
                        principalTable: "Negocio",
                        principalColumn: "NegocioID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empleado_AspNetUsers_UserNameId",
                        column: x => x.UserNameId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
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
                    UserNameId = table.Column<string>(nullable: false)
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
                        name: "FK_Reservacion_AspNetUsers_UserNameId",
                        column: x => x.UserNameId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Negocio_CategoriaIDCategoriaNegocioID",
                table: "Negocio",
                column: "CategoriaIDCategoriaNegocioID");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_CategoriaEmpleadoID1",
                table: "Empleado",
                column: "CategoriaEmpleadoID1");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_NegocioID1",
                table: "Empleado",
                column: "NegocioID1");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_UserNameId",
                table: "Empleado",
                column: "UserNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_EmpleadoID1",
                table: "Reservacion",
                column: "EmpleadoID1");

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_UserNameId",
                table: "Reservacion",
                column: "UserNameId");

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

            migrationBuilder.DropIndex(
                name: "IX_Negocio_CategoriaIDCategoriaNegocioID",
                table: "Negocio");

            migrationBuilder.DropColumn(
                name: "CategoriaIDCategoriaNegocioID",
                table: "Negocio");

            migrationBuilder.RenameColumn(
                name: "CategoriaEmpleadoID",
                table: "CategoriaUsuario",
                newName: "CategoriaUsuarioID");

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Negocio",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Negocio",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "CategoriaUsuario",
                nullable: false,
                defaultValue: false);
        }
    }
}
