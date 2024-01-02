﻿// <auto-generated />
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UcakRezervasyonSitesi.Models;

#nullable disable

namespace UcakRezervasyonSitesi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240101053344_SeedKullaniciData")]
    partial class SeedKullaniciData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UcakRezervasyonSitesi.Models.KoltukYapisi", b =>
                {
                    b.Property<int>("KoltukYapisiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("KoltukYapisiId"));

                    b.Property<int>("Sira")
                        .HasColumnType("integer");

                    b.Property<int>("Sutun")
                        .HasColumnType("integer");

                    b.HasKey("KoltukYapisiId");

                    b.ToTable("KoltukYapisi");
                });

            modelBuilder.Entity("UcakRezervasyonSitesi.Models.Kullanici", b =>
                {
                    b.Property<int>("KullaniciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("KullaniciId"));

                    b.Property<bool>("AdminOncelik")
                        .HasColumnType("boolean");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("KullaniciId");

                    b.ToTable("Kullanicilar");

                    b.HasData(
                        new
                        {
                            KullaniciId = 50,
                            AdminOncelik = false,
                            KullaniciAdi = "g201210056@sakarya.edu.tr",
                            Sifre = "sau"
                        });
                });

            modelBuilder.Entity("UcakRezervasyonSitesi.Models.Ucak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("KoltukDuzeniKoltukYapisiId")
                        .HasColumnType("integer");

                    b.Property<decimal>("KoltukFiyati")
                        .HasColumnType("numeric");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("VarisNoktalari")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.HasKey("Id");

                    b.HasIndex("KoltukDuzeniKoltukYapisiId");

                    b.ToTable("Ucaklar");
                });

            modelBuilder.Entity("UcakRezervasyonSitesi.Models.Ucak", b =>
                {
                    b.HasOne("UcakRezervasyonSitesi.Models.KoltukYapisi", "KoltukDuzeni")
                        .WithMany()
                        .HasForeignKey("KoltukDuzeniKoltukYapisiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KoltukDuzeni");
                });
#pragma warning restore 612, 618
        }
    }
}
