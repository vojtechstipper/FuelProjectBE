﻿// <auto-generated />
using System;
using FuelProject.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FuelProject.Migrations
{
    [DbContext(typeof(DiaryDbContext))]
    partial class DiaryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CarUser", b =>
                {
                    b.Property<Guid>("CarsId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("char(36)");

                    b.HasKey("CarsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("CarUser");
                });

            modelBuilder.Entity("FuelProject.Domain.Entities.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<string>("LicencePlate")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("FuelProject.Domain.Entities.FuelRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CarId")
                        .HasColumnType("char(36)");

                    b.Property<int>("DashboardKms")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfRefuel")
                        .HasColumnType("datetime(6)");

                    b.Property<float>("FuelAmount")
                        .HasColumnType("float");

                    b.Property<string>("NameOfFuelStation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("PricePerLiter")
                        .HasColumnType("float");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("FuelRecords");
                });

            modelBuilder.Entity("FuelProject.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarUser", b =>
                {
                    b.HasOne("FuelProject.Domain.Entities.Car", null)
                        .WithMany()
                        .HasForeignKey("CarsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FuelProject.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FuelProject.Domain.Entities.FuelRecord", b =>
                {
                    b.HasOne("FuelProject.Domain.Entities.Car", "Car")
                        .WithMany("FuelRecords")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FuelProject.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FuelProject.Domain.Entities.Car", b =>
                {
                    b.Navigation("FuelRecords");
                });
#pragma warning restore 612, 618
        }
    }
}