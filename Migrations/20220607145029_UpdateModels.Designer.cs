﻿// <auto-generated />
using API_Filmes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API_Filmes.Migrations
{
    [DbContext(typeof(FilmeContext))]
    [Migration("20220607145029_UpdateModels")]
    partial class UpdateModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("API_Filmes.Models.Ator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nacionalidade")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Atores");
                });

            modelBuilder.Entity("API_Filmes.Models.Diretor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nacionalidade")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Diretores");
                });

            modelBuilder.Entity("API_Filmes.Models.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<int>("DiretorId")
                        .HasColumnType("int");

                    b.Property<int>("DuracaoMinutos")
                        .HasColumnType("int");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nacionalidade")
                        .HasColumnType("longtext");

                    b.Property<decimal>("RatingIMDB")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TituloOriginal")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DiretorId");

                    b.ToTable("Filmes");
                });

            modelBuilder.Entity("AtorFilme", b =>
                {
                    b.Property<int>("ElencoId")
                        .HasColumnType("int");

                    b.Property<int>("TrabalhosId")
                        .HasColumnType("int");

                    b.HasKey("ElencoId", "TrabalhosId");

                    b.HasIndex("TrabalhosId");

                    b.ToTable("AtorFilme");
                });

            modelBuilder.Entity("API_Filmes.Models.Filme", b =>
                {
                    b.HasOne("API_Filmes.Models.Diretor", "Diretor")
                        .WithMany("Trabalhos")
                        .HasForeignKey("DiretorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diretor");
                });

            modelBuilder.Entity("AtorFilme", b =>
                {
                    b.HasOne("API_Filmes.Models.Ator", null)
                        .WithMany()
                        .HasForeignKey("ElencoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Filmes.Models.Filme", null)
                        .WithMany()
                        .HasForeignKey("TrabalhosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API_Filmes.Models.Diretor", b =>
                {
                    b.Navigation("Trabalhos");
                });
#pragma warning restore 612, 618
        }
    }
}
