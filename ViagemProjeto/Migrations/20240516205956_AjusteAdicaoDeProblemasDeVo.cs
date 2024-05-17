using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ViagemProjeto.Migrations
{
    /// <inheritdoc />
    public partial class AjusteAdicaoDeProblemasDeVo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registro_Tripulacoes");

            migrationBuilder.DropTable(
                name: "Registro_Voos");

            migrationBuilder.CreateTable(
                name: "Tripulacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Cargo = table.Column<string>(type: "TEXT", nullable: true),
                    Funcao = table.Column<string>(type: "TEXT", nullable: true),
                    Qualificacoes = table.Column<string>(type: "TEXT", nullable: true),
                    HorarioTrabalho = table.Column<string>(type: "TEXT", nullable: true),
                    IdiomasFalados = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tripulacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumeroVoo = table.Column<int>(type: "INTEGER", nullable: false),
                    Origem = table.Column<string>(type: "TEXT", nullable: true),
                    Destino = table.Column<string>(type: "TEXT", nullable: true),
                    HrPartida = table.Column<string>(type: "TEXT", nullable: true),
                    HrChegadaPrevista = table.Column<string>(type: "TEXT", nullable: true),
                    TipoAviao = table.Column<string>(type: "TEXT", nullable: true),
                    Companhia = table.Column<string>(type: "TEXT", nullable: true),
                    TemProblema = table.Column<bool>(type: "INTEGER", nullable: false),
                    VooCancelado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tripulacoes");

            migrationBuilder.DropTable(
                name: "Voos");

            migrationBuilder.CreateTable(
                name: "Registro_Tripulacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cargo = table.Column<string>(type: "TEXT", nullable: true),
                    Funcao = table.Column<string>(type: "TEXT", nullable: true),
                    HorarioTrabalho = table.Column<string>(type: "TEXT", nullable: true),
                    IdiomasFalados = table.Column<string>(type: "TEXT", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Qualificacoes = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registro_Tripulacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registro_Voos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Companhia = table.Column<string>(type: "TEXT", nullable: true),
                    Destino = table.Column<string>(type: "TEXT", nullable: true),
                    HrChegadaPrevista = table.Column<string>(type: "TEXT", nullable: true),
                    HrPartida = table.Column<string>(type: "TEXT", nullable: true),
                    NumeroVoo = table.Column<int>(type: "INTEGER", nullable: false),
                    Origem = table.Column<string>(type: "TEXT", nullable: true),
                    TipoAviao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registro_Voos", x => x.Id);
                });
        }
    }
}
