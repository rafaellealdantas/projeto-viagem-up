using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ViagemProjeto.Migrations
{
    /// <inheritdoc />
    public partial class Att : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Companhia",
                table: "Registro_Voos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HrChegadaPrevista",
                table: "Registro_Voos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HrPartida",
                table: "Registro_Voos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoAviao",
                table: "Registro_Voos",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Companhia",
                table: "Registro_Voos");

            migrationBuilder.DropColumn(
                name: "HrChegadaPrevista",
                table: "Registro_Voos");

            migrationBuilder.DropColumn(
                name: "HrPartida",
                table: "Registro_Voos");

            migrationBuilder.DropColumn(
                name: "TipoAviao",
                table: "Registro_Voos");
        }
    }
}
