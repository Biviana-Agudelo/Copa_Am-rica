using Microsoft.EntityFrameworkCore.Migrations;

namespace CopaAmerica.App.Persistencia.Migrations
{
    public partial class entidades4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    PartidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Equipo1EquipoId = table.Column<int>(type: "int", nullable: true),
                    Equipo2EquipoId = table.Column<int>(type: "int", nullable: true),
                    GolesE1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GolesE2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TirosArcoE1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TirosArcoE2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TirosEsquinaE1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TirosEsquinaE2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarjetasAmarillasE1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarjetasAmarillasE2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarjetasRojasE1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarjetasRojasE2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosecionPelotaE1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosecionPelotaE2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.PartidoId);
                    table.ForeignKey(
                        name: "FK_Partidos_Equipos_Equipo1EquipoId",
                        column: x => x.Equipo1EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidos_Equipos_Equipo2EquipoId",
                        column: x => x.Equipo2EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipoId = table.Column<int>(type: "int", nullable: true),
                    JugadoresJugadorId = table.Column<int>(type: "int", nullable: true),
                    PartidosPartidoId = table.Column<int>(type: "int", nullable: true),
                    Accion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tiempo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventoId);
                    table.ForeignKey(
                        name: "FK_Eventos_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Eventos_Jugadores_JugadoresJugadorId",
                        column: x => x.JugadoresJugadorId,
                        principalTable: "Jugadores",
                        principalColumn: "JugadorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Eventos_Partidos_PartidosPartidoId",
                        column: x => x.PartidosPartidoId,
                        principalTable: "Partidos",
                        principalColumn: "PartidoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_EquipoId",
                table: "Eventos",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_JugadoresJugadorId",
                table: "Eventos",
                column: "JugadoresJugadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_PartidosPartidoId",
                table: "Eventos",
                column: "PartidosPartidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_Equipo1EquipoId",
                table: "Partidos",
                column: "Equipo1EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidos_Equipo2EquipoId",
                table: "Partidos",
                column: "Equipo2EquipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Partidos");
        }
    }
}
