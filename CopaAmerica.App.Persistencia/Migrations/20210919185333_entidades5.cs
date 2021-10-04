using Microsoft.EntityFrameworkCore.Migrations;

namespace CopaAmerica.App.Persistencia.Migrations
{
    public partial class entidades5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eliminaciones",
                columns: table => new
                {
                    FaseEliminacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroGoles = table.Column<int>(type: "int", nullable: false),
                    Penal = table.Column<bool>(type: "bit", nullable: false),
                    GolesPenal = table.Column<int>(type: "int", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eliminaciones", x => x.FaseEliminacionId);
                });

            migrationBuilder.CreateTable(
                name: "RelacionEquipoFase",
                columns: table => new
                {
                    RelacionEquipoFaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipoId = table.Column<int>(type: "int", nullable: true),
                    FaseEliminacionId = table.Column<int>(type: "int", nullable: true),
                    EstadoFase = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelacionEquipoFase", x => x.RelacionEquipoFaseId);
                    table.ForeignKey(
                        name: "FK_RelacionEquipoFase_Eliminaciones_FaseEliminacionId",
                        column: x => x.FaseEliminacionId,
                        principalTable: "Eliminaciones",
                        principalColumn: "FaseEliminacionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RelacionEquipoFase_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "EquipoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelacionEquipoFase_EquipoId",
                table: "RelacionEquipoFase",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_RelacionEquipoFase_FaseEliminacionId",
                table: "RelacionEquipoFase",
                column: "FaseEliminacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelacionEquipoFase");

            migrationBuilder.DropTable(
                name: "Eliminaciones");
        }
    }
}
