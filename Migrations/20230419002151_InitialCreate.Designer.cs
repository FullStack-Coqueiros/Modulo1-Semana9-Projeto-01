﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using meu_primiro_projeto_ef.Model;

#nullable disable

namespace meu_primiro_projeto_ef.Migrations
{
    [DbContext(typeof(MeuBancoDadosContext))]
    [Migration("20230419002151_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("meu_primiro_projeto_ef.Model.MesModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alergias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StatusAtendimento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Mes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ano = 1234,
                            Nome = "Teste Um",
                            StatusAtendimento = 1
                        },
                        new
                        {
                            Id = 2,
                            Ano = 2023,
                            Nome = "Teste Dois",
                            StatusAtendimento = 3
                        });
                });

            modelBuilder.Entity("meu_primiro_projeto_ef.Model.SemanaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Dia")
                        .HasColumnType("int");

                    b.Property<int>("MesId")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MesId");

                    b.ToTable("Semana");
                });

            modelBuilder.Entity("meu_primiro_projeto_ef.Model.SemanaModel", b =>
                {
                    b.HasOne("meu_primiro_projeto_ef.Model.MesModel", "Mes")
                        .WithMany("SemanaModels")
                        .HasForeignKey("MesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mes");
                });

            modelBuilder.Entity("meu_primiro_projeto_ef.Model.MesModel", b =>
                {
                    b.Navigation("SemanaModels");
                });
#pragma warning restore 612, 618
        }
    }
}