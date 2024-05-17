using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ViagemProjeto.Migrations
{
    /// <inheritdoc />
    public partial class VerificacaoClimatica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VerificacoesClimaticas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumeroVoo = table.Column<int>(type: "INTEGER", nullable: false),
                    RotaVoo = table.Column<string>(type: "TEXT", nullable: true),
                    CondicoesMeteorologicas = table.Column<string>(type: "TEXT", nullable: true),
                    PrevisaoTempo = table.Column<string>(type: "TEXT", nullable: true),
                    AlertasTempestades = table.Column<string>(type: "TEXT", nullable: true),
                    CondicoesAdversas = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificacoesClimaticas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VerificacoesClimaticas");
        }
    }
}
