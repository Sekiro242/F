﻿// <auto-generated />
using System;
using AirPort.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AirPort.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AirPort.Models.Entities.Airline", b =>
                {
                    b.Property<int>("AirlineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AirlineID"));

                    b.Property<string>("AirlineName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AirlineID");

                    b.ToTable("airlines");
                });

            modelBuilder.Entity("AirPort.Models.Entities.Booking", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingID"));

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FlightID")
                        .HasColumnType("int");

                    b.Property<int>("PassengerID")
                        .HasColumnType("int");

                    b.HasKey("BookingID");

                    b.HasIndex("FlightID");

                    b.HasIndex("PassengerID");

                    b.ToTable("bookings");
                });

            modelBuilder.Entity("AirPort.Models.Entities.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FlightId"));

                    b.Property<int>("AirlineID")
                        .HasColumnType("int");

                    b.Property<string>("ArrivalCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartureCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FlightNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("Schedule")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FlightId");

                    b.HasIndex("AirlineID");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("AirPort.Models.Entities.Passenger", b =>
                {
                    b.Property<int>("PassengerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassengerID"));

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassengerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PassengerID");

                    b.ToTable("passenger");
                });

            modelBuilder.Entity("AirPort.Models.Entities.Booking", b =>
                {
                    b.HasOne("AirPort.Models.Entities.Flight", "Flight")
                        .WithMany("Bookings")
                        .HasForeignKey("FlightID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirPort.Models.Entities.Passenger", "Passenger")
                        .WithMany("bookings")
                        .HasForeignKey("PassengerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("AirPort.Models.Entities.Flight", b =>
                {
                    b.HasOne("AirPort.Models.Entities.Airline", "Airline")
                        .WithMany("Flights")
                        .HasForeignKey("AirlineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airline");
                });

            modelBuilder.Entity("AirPort.Models.Entities.Airline", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("AirPort.Models.Entities.Flight", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("AirPort.Models.Entities.Passenger", b =>
                {
                    b.Navigation("bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
