﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UcakRezervasyonSitesi.Models;

#nullable disable

namespace UcakRezervasyonSitesi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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
                            KullaniciId = 5,
                            AdminOncelik = true,
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

                    b.Property<string>("KalkisNoktasi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("KoltukFiyati")
                        .HasColumnType("numeric");

                    b.Property<int>("KoltukSatir")
                        .HasColumnType("integer");

                    b.Property<int>("KoltukSutun")
                        .HasColumnType("integer");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VarisNoktasi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Ucaklar");
                });
#pragma warning restore 612, 618
        }
    }
}
