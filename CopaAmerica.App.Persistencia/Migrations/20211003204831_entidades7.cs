using Microsoft.EntityFrameworkCore.Migrations;

namespace CopaAmerica.App.Persistencia.Migrations
{
    public partial class entidades7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Personas_PersonaId",
                table: "Jugadores");

            migrationBuilder.AlterColumn<int>(
                name: "PersonaId",
                table: "Jugadores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Jugadores_Personas_PersonaId",
                table: "Jugadores",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Personas_PersonaId",
                table: "Jugadores");

            migrationBuilder.AlterColumn<int>(
                name: "PersonaId",
                table: "Jugadores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Jugadores_Personas_PersonaId",
                table: "Jugadores",
                column: "PersonaId",
                principalTable: "Personas",
                principalColumn: "PersonaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
