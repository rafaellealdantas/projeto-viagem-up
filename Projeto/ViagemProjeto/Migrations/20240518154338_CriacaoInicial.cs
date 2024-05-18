using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ViagemProjeto.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Passageiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    Nacionalidade = table.Column<string>(type: "TEXT", nullable: false),
                    InformacoesContato = table.Column<string>(type: "TEXT", nullable: false),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: true),
                    Passaporte = table.Column<string>(type: "TEXT", nullable: true),
                    VooId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passageiros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passageiros_Voos_VooId",
                        column: x => x.VooId,
                        principalTable: "Voos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    IdiomasFalados = table.Column<string>(type: "TEXT", nullable: true),
                    VooId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tripulacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tripulacoes_Voos_VooId",
                        column: x => x.VooId,
                        principalTable: "Voos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VerificacoesClimaticas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CondicoesMeteorologicas = table.Column<string>(type: "TEXT", nullable: true),
                    PrevisaoTempo = table.Column<string>(type: "TEXT", nullable: true),
                    AlertasTempestades = table.Column<string>(type: "TEXT", nullable: true),
                    CondicoesAdversas = table.Column<string>(type: "TEXT", nullable: true),
                    VooId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificacoesClimaticas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerificacoesClimaticas_Voos_VooId",
                        column: x => x.VooId,
                        principalTable: "Voos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passageiros_VooId",
                table: "Passageiros",
                column: "VooId");

            migrationBuilder.CreateIndex(
                name: "IX_Tripulacoes_VooId",
                table: "Tripulacoes",
                column: "VooId");

            migrationBuilder.CreateIndex(
                name: "IX_VerificacoesClimaticas_VooId",
                table: "VerificacoesClimaticas",
                column: "VooId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passageiros");

            migrationBuilder.DropTable(
                name: "Tripulacoes");

            migrationBuilder.DropTable(
                name: "VerificacoesClimaticas");

            migrationBuilder.DropTable(
                name: "Voos");
        }
    }
}
