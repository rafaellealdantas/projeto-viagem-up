using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ViagemProjeto.Migrations
{
    /// <inheritdoc />
    public partial class BancoDE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Passageiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nacionalidade = table.Column<string>(type: "TEXT", nullable: false),
                    InformacoesContato = table.Column<string>(type: "TEXT", nullable: false),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: true),
                    Passaporte = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passageiros", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passageiros");
        }
    }
}
