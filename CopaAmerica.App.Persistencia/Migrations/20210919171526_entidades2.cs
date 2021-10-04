using Microsoft.EntityFrameworkCore.Migrations;

namespace CopaAmerica.App.Persistencia.Migrations
{
    public partial class entidades2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Equipo_EquipoId",
                table: "Jugadores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipo",
                table: "Equipo");

            migrationBuilder.RenameTable(
                name: "Equipo",
                newName: "Equipos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipos",
                table: "Equipos",
                column: "EquipoId");

            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    AdministradorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaId = table.Column<int>(type: "int", nullable: true),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoEmpleado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.AdministradorId);
                    table.ForeignKey(
                        name: "FK_Administradores_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DirectoresTecnicos",
                columns: table => new
                {
                    DirectorTecnicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaId = table.Column<int>(type: "int", nullable: true),
                    EquipoId = table.Column<int>(type: "int", nullable: true),
                    Nacionalidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroEquipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectoresTecnicos", x => x.DirectorTecnicoId);
                    table.ForeignKey(
                        name: "FK_DirectoresTecnicos_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DirectoresTecnicos_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_PersonaId",
                table: "Administradores",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectoresTecnicos_EquipoId",
                table: "DirectoresTecnicos",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectoresTecnicos_PersonaId",
                table: "DirectoresTecnicos",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jugadores_Equipos_EquipoId",
                table: "Jugadores",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "EquipoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Equipos_EquipoId",
                table: "Jugadores");

            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "DirectoresTecnicos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipos",
                table: "Equipos");

            migrationBuilder.RenameTable(
                name: "Equipos",
                newName: "Equipo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipo",
                table: "Equipo",
                column: "EquipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jugadores_Equipo_EquipoId",
                table: "Jugadores",
                column: "EquipoId",
                principalTable: "Equipo",
                principalColumn: "EquipoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
