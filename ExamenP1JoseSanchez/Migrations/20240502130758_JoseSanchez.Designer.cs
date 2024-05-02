﻿// <auto-generated />
using System;
using ExamenP1JoseSanchez.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExamenP1JoseSanchez.Migrations
{
    [DbContext(typeof(ExamenP1JoseSanchezContext))]
    [Migration("20240502130758_JoseSanchez")]
    partial class JoseSanchez
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExamenP1JoseSanchez.Models.Carrera", b =>
                {
                    b.Property<int>("IdCarrera")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCarrera"));

                    b.Property<string>("Campus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCarrera")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumSemestre")
                        .HasColumnType("int");

                    b.HasKey("IdCarrera");

                    b.ToTable("Carrera");
                });

            modelBuilder.Entity("ExamenP1JoseSanchez.Models.JSanchez", b =>
                {
                    b.Property<int>("IdSanchez")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSanchez"));

                    b.Property<int>("CarreraIdCarrera")
                        .HasColumnType("int");

                    b.Property<bool>("EsdelaUdla")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("FechaNacimeinto")
                        .HasColumnType("date");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSanchez");

                    b.HasIndex("CarreraIdCarrera");

                    b.ToTable("JSanchez");
                });

            modelBuilder.Entity("ExamenP1JoseSanchez.Models.JSanchez", b =>
                {
                    b.HasOne("ExamenP1JoseSanchez.Models.Carrera", "Carrera")
                        .WithMany()
                        .HasForeignKey("CarreraIdCarrera")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrera");
                });
#pragma warning restore 612, 618
        }
    }
}
