﻿// <auto-generated />
using System;
using HairdresserSalon.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HairdresserSalon.Migrations
{
    [DbContext(typeof(HairdresserDbContext))]
    [Migration("20220318150541_opinionDate")]
    partial class opinionDate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HairdresserSalon.Models.CustomerModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VisitsCounter")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("HairdresserSalon.Models.DayModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("HairdresserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("HairdresserId");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("HairdresserSalon.Models.HairdresserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Hairdressers");
                });

            modelBuilder.Entity("HairdresserSalon.Models.HourModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<Guid?>("DayId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Hour")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DayId");

                    b.ToTable("Hours");
                });

            modelBuilder.Entity("HairdresserSalon.Models.OpinionModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("HairdresserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HairdresserId");

                    b.ToTable("Opinions");
                });

            modelBuilder.Entity("HairdresserSalon.Models.ServiceModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("HairdresserSalon.Models.VisitModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Canceled")
                        .HasColumnType("bit");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ended")
                        .HasColumnType("bit");

                    b.Property<Guid?>("HairdresserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("OpinionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<Guid?>("ServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DateId");

                    b.HasIndex("HairdresserId");

                    b.HasIndex("OpinionId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("HairdresserSalon.Models.DayModel", b =>
                {
                    b.HasOne("HairdresserSalon.Models.HairdresserModel", "Hairdresser")
                        .WithMany()
                        .HasForeignKey("HairdresserId");

                    b.Navigation("Hairdresser");
                });

            modelBuilder.Entity("HairdresserSalon.Models.HourModel", b =>
                {
                    b.HasOne("HairdresserSalon.Models.DayModel", "Day")
                        .WithMany("Hours")
                        .HasForeignKey("DayId");

                    b.Navigation("Day");
                });

            modelBuilder.Entity("HairdresserSalon.Models.OpinionModel", b =>
                {
                    b.HasOne("HairdresserSalon.Models.HairdresserModel", "Hairdresser")
                        .WithMany()
                        .HasForeignKey("HairdresserId");

                    b.Navigation("Hairdresser");
                });

            modelBuilder.Entity("HairdresserSalon.Models.VisitModel", b =>
                {
                    b.HasOne("HairdresserSalon.Models.CustomerModel", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("HairdresserSalon.Models.HourModel", "Date")
                        .WithMany()
                        .HasForeignKey("DateId");

                    b.HasOne("HairdresserSalon.Models.HairdresserModel", "Hairdresser")
                        .WithMany()
                        .HasForeignKey("HairdresserId");

                    b.HasOne("HairdresserSalon.Models.OpinionModel", "Opinion")
                        .WithMany()
                        .HasForeignKey("OpinionId");

                    b.HasOne("HairdresserSalon.Models.ServiceModel", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId");

                    b.Navigation("Customer");

                    b.Navigation("Date");

                    b.Navigation("Hairdresser");

                    b.Navigation("Opinion");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("HairdresserSalon.Models.DayModel", b =>
                {
                    b.Navigation("Hours");
                });
#pragma warning restore 612, 618
        }
    }
}
