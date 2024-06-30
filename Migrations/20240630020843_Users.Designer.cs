﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SozinBackNew.Data;

#nullable disable

namespace SozinBackNew.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240630020843_Users")]
    partial class Users
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("SozinBackNew.Models.Incident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<ulong?>("Active")
                        .HasColumnType("bigint unsigned");

                    b.Property<int?>("Altitude")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Begin")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Command_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Severity")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("incident");
                });

            modelBuilder.Entity("SozinBackNew.Models.Machinery.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("MachineryCategories");
                });

            modelBuilder.Entity("SozinBackNew.Models.Machinery.Machinery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Available")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<double>("Latitude")
                        .HasColumnType("double");

                    b.Property<double>("Longitude")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Operative")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Serial")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Machineries");
                });

            modelBuilder.Entity("SozinBackNew.Models.Machinery.MachineryIncident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IncidentId")
                        .HasColumnType("int");

                    b.Property<int>("MachineryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MachineryId");

                    b.ToTable("MachineriesPerIncident");
                });

            modelBuilder.Entity("SozinBackNew.Models.Material.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("MaterialCategories");
                });

            modelBuilder.Entity("SozinBackNew.Models.Material.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Available")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<double>("Latitude")
                        .HasColumnType("double");

                    b.Property<double>("Longitude")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Operative")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Serial")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("SozinBackNew.Models.Material.MaterialIncident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IncidentId")
                        .HasColumnType("int");

                    b.Property<int>("MaterialId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.ToTable("MaterialsPerIncident");
                });

            modelBuilder.Entity("SozinBackNew.Models.Personal.Personal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Available")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("Latitude")
                        .HasColumnType("double");

                    b.Property<double>("Longitude")
                        .HasColumnType("double");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Operative")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Schedule")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Personal");
                });

            modelBuilder.Entity("SozinBackNew.Models.Personal.PersonalIncident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IncidentId")
                        .HasColumnType("int");

                    b.Property<int>("PersonalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonalId");

                    b.ToTable("PersonalIncident");
                });

            modelBuilder.Entity("SozinBackNew.Models.Users.User", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SozinBackNew.Models.Machinery.Machinery", b =>
                {
                    b.HasOne("SozinBackNew.Models.Machinery.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SozinBackNew.Models.Machinery.MachineryIncident", b =>
                {
                    b.HasOne("SozinBackNew.Models.Machinery.Machinery", "Machinery")
                        .WithMany()
                        .HasForeignKey("MachineryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Machinery");
                });

            modelBuilder.Entity("SozinBackNew.Models.Material.Material", b =>
                {
                    b.HasOne("SozinBackNew.Models.Material.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("SozinBackNew.Models.Material.MaterialIncident", b =>
                {
                    b.HasOne("SozinBackNew.Models.Material.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Material");
                });

            modelBuilder.Entity("SozinBackNew.Models.Personal.PersonalIncident", b =>
                {
                    b.HasOne("SozinBackNew.Models.Personal.Personal", "Personal")
                        .WithMany()
                        .HasForeignKey("PersonalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personal");
                });
#pragma warning restore 612, 618
        }
    }
}
