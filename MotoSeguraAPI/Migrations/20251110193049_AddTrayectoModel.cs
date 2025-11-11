using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotoSeguraAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTrayectoModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventLogs");

            migrationBuilder.DropColumn(
                name: "HelmetValidated",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "HelmetType",
                table: "Users",
                newName: "Email");

            migrationBuilder.CreateTable(
                name: "Trayectos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DistanciaRecorridaKm = table.Column<double>(type: "REAL", nullable: false),
                    VelocidadPromedioKmH = table.Column<double>(type: "REAL", nullable: false),
                    VelocidadMaximaKmH = table.Column<double>(type: "REAL", nullable: false),
                    ModoConduccion = table.Column<string>(type: "TEXT", nullable: false),
                    UbicacionInicio_Lat = table.Column<double>(type: "REAL", nullable: false),
                    UbicacionInicio_Lng = table.Column<double>(type: "REAL", nullable: false),
                    UbicacionFin_Lat = table.Column<double>(type: "REAL", nullable: true),
                    UbicacionFin_Lng = table.Column<double>(type: "REAL", nullable: true),
                    Gps_Ubicacion_Lat = table.Column<double>(type: "REAL", nullable: true),
                    Gps_Ubicacion_Lng = table.Column<double>(type: "REAL", nullable: true),
                    Gps_Velocidad = table.Column<double>(type: "REAL", nullable: false),
                    Gps_Altitud = table.Column<double>(type: "REAL", nullable: false),
                    Gps_Direccion = table.Column<double>(type: "REAL", nullable: false),
                    Acelerometro_Aceleracion = table.Column<double>(type: "REAL", nullable: false),
                    Acelerometro_FrenadoBrusco = table.Column<bool>(type: "INTEGER", nullable: false),
                    Giroscopio_CambioBruscoDireccion = table.Column<bool>(type: "INTEGER", nullable: false),
                    Conectividad_RedMovil = table.Column<bool>(type: "INTEGER", nullable: false),
                    Conectividad_Wifi = table.Column<bool>(type: "INTEGER", nullable: false),
                    VerificacionCasco_FotoCasco = table.Column<string>(type: "TEXT", nullable: false),
                    VerificacionCasco_CascoDetectado = table.Column<bool>(type: "INTEGER", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false)
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
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false),
                    Detalles = table.Column<string>(type: "TEXT", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TrayectoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TrayectoId1 = table.Column<Guid>(type: "TEXT", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Eventos_Trayectos_TrayectoId1",
                        column: x => x.TrayectoId1,
                        principalTable: "Trayectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_TrayectoId",
                table: "Eventos",
                column: "TrayectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_TrayectoId1",
                table: "Eventos",
                column: "TrayectoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Trayectos_UserId",
                table: "Trayectos",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Trayectos");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "HelmetType");

            migrationBuilder.AddColumn<bool>(
                name: "HelmetValidated",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "EventLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventLogs_UserId",
                table: "EventLogs",
                column: "UserId");
        }
    }
}
