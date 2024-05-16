﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ViagemProjeto.Models;

#nullable disable

namespace ViagemProjeto.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240516205956_AjusteAdicaoDeProblemasDeVo")]
    partial class AjusteAdicaoDeProblemasDeVo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("ViagemProjeto.Models.Tripulacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cargo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Funcao")
                        .HasColumnType("TEXT");

                    b.Property<string>("HorarioTrabalho")
                        .HasColumnType("TEXT");

                    b.Property<string>("IdiomasFalados")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Qualificacoes")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tripulacoes");
                });

            modelBuilder.Entity("ViagemProjeto.Models.Voo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Companhia")
                        .HasColumnType("TEXT");

                    b.Property<string>("Destino")
                        .HasColumnType("TEXT");

                    b.Property<string>("HrChegadaPrevista")
                        .HasColumnType("TEXT");

                    b.Property<string>("HrPartida")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumeroVoo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Origem")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TemProblema")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TipoAviao")
                        .HasColumnType("TEXT");

                    b.Property<bool>("VooCancelado")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Voos");
                });
#pragma warning restore 612, 618
        }
    }
}
