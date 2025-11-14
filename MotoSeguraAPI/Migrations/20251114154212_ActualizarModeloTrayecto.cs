using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoSeguraAPI.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarModeloTrayecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AceleracionPromedio",
                table: "Trayectos",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ExcesoVelocidad",
                table: "Trayectos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FrenadasFuertes",
                table: "Trayectos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GirosBruscos",
                table: "Trayectos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AceleracionPromedio",
                table: "Trayectos");

            migrationBuilder.DropColumn(
                name: "ExcesoVelocidad",
                table: "Trayectos");

            migrationBuilder.DropColumn(
                name: "FrenadasFuertes",
                table: "Trayectos");

            migrationBuilder.DropColumn(
                name: "GirosBruscos",
                table: "Trayectos");
        }
    }
}
