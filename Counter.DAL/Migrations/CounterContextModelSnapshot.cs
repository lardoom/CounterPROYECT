﻿// <auto-generated />
using System;
using Counter.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Counter.DAL.Migrations
{
    [DbContext(typeof(CounterContext))]
    partial class CounterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Counter.DAL.models.Armas", b =>
                {
                    b.Property<long>("Armas_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Armas_ID"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<float?>("Desgaste")
                        .HasColumnType("float");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("Jugador_ID")
                        .HasColumnType("bigint");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Armas_ID");

                    b.HasIndex("Jugador_ID");

                    b.HasIndex("Nombre");

                    b.ToTable("Armas");
                });

            modelBuilder.Entity("Counter.DAL.models.Equipos", b =>
                {
                    b.Property<long>("Equipo_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Equipo_ID"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("TorneosGanados")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Equipo_ID");

                    b.HasIndex("Nombre");

                    b.ToTable("Equipos");
                });

            modelBuilder.Entity("Counter.DAL.models.Jugadores", b =>
                {
                    b.Property<long>("Jugador_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Jugador_ID"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Deaths")
                        .HasColumnType("int");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<long>("Equipo_ID")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Kills")
                        .HasColumnType("int");

                    b.Property<string>("MapaFavorito")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<long>("Pais_ID")
                        .HasColumnType("bigint");

                    b.Property<decimal>("PrecisionTiro")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("RondasGanadas")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Jugador_ID");

                    b.HasIndex("Equipo_ID");

                    b.HasIndex("Nombre");

                    b.HasIndex("Pais_ID");

                    b.ToTable("Jugadores");
                });

            modelBuilder.Entity("Counter.DAL.models.Pais", b =>
                {
                    b.Property<long>("Pais_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Pais_ID"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Pais_ID");

                    b.HasIndex("Nombre");

                    b.ToTable("Pais");
                });

            modelBuilder.Entity("Counter.DAL.models.Armas", b =>
                {
                    b.HasOne("Counter.DAL.models.Jugadores", "Jugadores")
                        .WithMany("Armas")
                        .HasForeignKey("Jugador_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Jugadores");
                });

            modelBuilder.Entity("Counter.DAL.models.Jugadores", b =>
                {
                    b.HasOne("Counter.DAL.models.Equipos", "Equipo")
                        .WithMany("Jugadores")
                        .HasForeignKey("Equipo_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Counter.DAL.models.Pais", "Pais")
                        .WithMany("Jugadores")
                        .HasForeignKey("Pais_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipo");

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("Counter.DAL.models.Equipos", b =>
                {
                    b.Navigation("Jugadores");
                });

            modelBuilder.Entity("Counter.DAL.models.Jugadores", b =>
                {
                    b.Navigation("Armas");
                });

            modelBuilder.Entity("Counter.DAL.models.Pais", b =>
                {
                    b.Navigation("Jugadores");
                });
#pragma warning restore 612, 618
        }
    }
}
