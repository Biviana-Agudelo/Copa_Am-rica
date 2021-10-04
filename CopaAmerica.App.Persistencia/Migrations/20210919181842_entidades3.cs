using Microsoft.EntityFrameworkCore.Migrations;

namespace CopaAmerica.App.Persistencia.Migrations
{
    public partial class entidades3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroEquipo",
                table: "DirectoresTecnicos");

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    GrupoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreGrupo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Equipo1EquipoId = table.Column<int>(type: "int", nullable: true),
                    Equipo2EquipoId = table.Column<int>(type: "int", nullable: true),
                    Equipo3EquipoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.GrupoId);
                    table.ForeignKey(
                        name: "FK_Grupos_Equipos_Equipo1EquipoId",
                        column: x => x.Equipo1EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grupos_Equipos_Equipo2EquipoId",
                        column: x => x.Equipo2EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grupos_Equipos_Equipo3EquipoId",
                        column: x => x.Equipo3EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clasificaciones",
                columns: table => new
                {
                    FaseClasificacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquiposEquipoId = table.Column<int>(type: "int", nullable: true),
                    GruposGrupoId = table.Column<int>(type: "int", nullable: true),
                    Posicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PTS = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasificaciones", x => x.FaseClasificacionId);
                    table.ForeignKey(
                        name: "FK_Clasificaciones_Equipos_EquiposEquipoId",
                        column: x => x.EquiposEquipoId,
                        principalTable: "Equipos",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clasificaciones_Grupos_GruposGrupoId",
                        column: x => x.GruposGrupoId,
                        principalTable: "Grupos",
                        principalColumn: "GrupoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clasificaciones_EquiposEquipoId",
                table: "Clasificaciones",
                column: "EquiposEquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clasificaciones_GruposGrupoId",
                table: "Clasificaciones",
                column: "GruposGrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_Equipo1EquipoId",
                table: "Grupos",
                column: "Equipo1EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_Equipo2EquipoId",
                table: "Grupos",
                column: "Equipo2EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_Equipo3EquipoId",
                table: "Grupos",
                column: "Equipo3EquipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clasificaciones");

            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.AddColumn<string>(
                name: "NumeroEquipo",
                table: "DirectoresTecnicos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
