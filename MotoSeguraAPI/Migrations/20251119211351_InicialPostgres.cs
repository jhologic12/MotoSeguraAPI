using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoSeguraAPI.Migrations
{
    /// <inheritdoc />
    public partial class InicialPostgres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trayectos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DistanciaRecorridaKm = table.Column<double>(type: "double precision", nullable: false),
                    VelocidadPromedioKmH = table.Column<double>(type: "double precision", nullable: false),
                    VelocidadMaximaKmH = table.Column<double>(type: "double precision", nullable: false),
                    ModoConduccion = table.Column<string>(type: "text", nullable: false),
                    UbicacionInicio_Lat = table.Column<double>(type: "double precision", nullable: false),
                    UbicacionInicio_Lng = table.Column<double>(type: "double precision", nullable: false),
                    UbicacionFin_Lat = table.Column<double>(type: "double precision", nullable: true),
                    UbicacionFin_Lng = table.Column<double>(type: "double precision", nullable: true),
                    Gps_Ubicacion_Lat = table.Column<double>(type: "double precision", nullable: false),
                    Gps_Ubicacion_Lng = table.Column<double>(type: "double precision", nullable: false),
                    Gps_Velocidad = table.Column<double>(type: "double precision", nullable: false),
                    Gps_Altitud = table.Column<double>(type: "double precision", nullable: false),
                    Gps_Direccion = table.Column<double>(type: "double precision", nullable: false),
                    Acelerometro_Aceleracion = table.Column<double>(type: "double precision", nullable: false),
                    Acelerometro_FrenadoBrusco = table.Column<bool>(type: "boolean", nullable: false),
                    Giroscopio_CambioBruscoDireccion = table.Column<bool>(type: "boolean", nullable: false),
                    Conectividad_RedMovil = table.Column<bool>(type: "boolean", nullable: false),
                    Conectividad_Wifi = table.Column<bool>(type: "boolean", nullable: false),
                    VerificacionCasco_FotoCasco = table.Column<string>(type: "text", nullable: false),
                    VerificacionCasco_CascoDetectado = table.Column<bool>(type: "boolean", nullable: false),
                    AceleracionPromedio = table.Column<double>(type: "double precision", nullable: false),
                    FrenadasFuertes = table.Column<int>(type: "integer", nullable: false),
                    GirosBruscos = table.Column<int>(type: "integer", nullable: false),
                    ExcesoVelocidad = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trayectos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trayectos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Detalles = table.Column<string>(type: "text", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TrayectoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_Trayectos_TrayectoId",
                        column: x => x.TrayectoId,
                        principalTable: "Trayectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_TrayectoId",
                table: "Eventos",
                column: "TrayectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Trayectos_UserId",
                table: "Trayectos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Trayectos");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
