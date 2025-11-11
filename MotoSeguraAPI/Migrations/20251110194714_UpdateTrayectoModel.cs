using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoSeguraAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTrayectoModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Trayectos_TrayectoId1",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_TrayectoId1",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "TrayectoId1",
                table: "Eventos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TrayectoId1",
                table: "Eventos",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_TrayectoId1",
                table: "Eventos",
                column: "TrayectoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Trayectos_TrayectoId1",
                table: "Eventos",
                column: "TrayectoId1",
                principalTable: "Trayectos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
