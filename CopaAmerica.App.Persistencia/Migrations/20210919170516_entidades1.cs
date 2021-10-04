using Microsoft.EntityFrameworkCore.Migrations;

namespace CopaAmerica.App.Persistencia.Migrations
{
    public partial class entidades1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipoId",
                table: "Jugadores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    EquipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEquipo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.EquipoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_EquipoId",
                table: "Jugadores",
                column: "EquipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jugadores_Equipo_EquipoId",
                table: "Jugadores",
                column: "EquipoId",
                principalTable: "Equipo",
                principalColumn: "EquipoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Equipo_EquipoId",
                table: "Jugadores");

            migrationBuilder.DropTable(
                name: "Equipo");

            migrationBuilder.DropIndex(
                name: "IX_Jugadores_EquipoId",
                table: "Jugadores");

            migrationBuilder.DropColumn(
                name: "EquipoId",
                table: "Jugadores");
        }
    }
}
