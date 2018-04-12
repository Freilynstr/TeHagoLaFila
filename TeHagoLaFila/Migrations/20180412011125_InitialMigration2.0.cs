using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TeHagoLaFila.Migrations
{
    public partial class InitialMigration20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservacion",
                columns: table => new
                {
                    ReservacionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserID = table.Column<string>(nullable: false),
                    EmpleadoID = table.Column<int>(nullable: false),
                    EndAllTimes = table.Column<DateTime>(nullable: true),
                    InitialReservationTime = table.Column<DateTime>(nullable: true),
                    InitialServiceTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservacion", x => x.ReservacionID);
                    table.ForeignKey(
                        name: "FK_Reservacion_AspNetUsers_ApplicationUserID",
                        column: x => x.ApplicationUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservacion_Empleado_EmpleadoID",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_ApplicationUserID",
                table: "Reservacion",
                column: "ApplicationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_EmpleadoID",
                table: "Reservacion",
                column: "EmpleadoID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservacion");
        }
    }
}
