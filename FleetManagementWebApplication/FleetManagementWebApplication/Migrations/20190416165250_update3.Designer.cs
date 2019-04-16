﻿// <auto-generated />
using System;
using FleetManagementWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FleetManagementWebApplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190416165250_update3")]
    partial class update3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FleetManagementWebAplication.Models.Client", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<string>("Birthdate")
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<string>("Phonenumber")
                        .HasMaxLength(20);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Period");

                    b.Property<long?>("PlanId");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool>("AutomaticResponse");

                    b.Property<long?>("ManagerId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("OrderType")
                        .HasMaxLength(100);

                    b.Property<int>("Size");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.Driver", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Birthdate")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<long?>("CompanyId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<string>("Phonenumber")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.Manager", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.Plan", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Plan");
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.ScheduledActivity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActivityId");

                    b.Property<DateTime>("DueDate");

                    b.Property<long>("VehicleId");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("VehicleId");

                    b.ToTable("ScheduledActivities");
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.ServiceLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActivityId");

                    b.Property<float>("Cost");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<long>("VehicleId");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("VehicleId");

                    b.ToTable("ServiceLogs");
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.Vehicle", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CompanyId");

                    b.Property<long?>("CurrentDriverId");

                    b.Property<int>("CurrentLoad");

                    b.Property<long?>("DriverId");

                    b.Property<int>("EmissionsCO2");

                    b.Property<int>("FuelConsumption");

                    b.Property<int>("FuelLevel");

                    b.Property<double>("Latitude");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<double>("Longtitude");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long?>("ManagerId");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<float>("Odometer");

                    b.Property<int>("PayLoad");

                    b.Property<long?>("PlanId");

                    b.Property<string>("Status");

                    b.Property<int>("fuelType");

                    b.Property<DateTime>("purchaseDate")
                        .HasColumnType("Date");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CurrentDriverId");

                    b.HasIndex("DriverId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("PlanId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.VehicleLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("DriverId");

                    b.Property<float>("Fuel");

                    b.Property<bool>("Harshbreak");

                    b.Property<double>("Langtitude");

                    b.Property<double>("Latitude");

                    b.Property<float>("Odometer");

                    b.Property<bool>("Seatbelt");

                    b.Property<int>("Speed");

                    b.Property<DateTime>("Time");

                    b.Property<long>("VehicleId");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("VehicleId");

                    b.ToTable("VehicleLogs");
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.Activity", b =>
                {
                    b.HasOne("FleetManagementWebApplication.Models.Plan", "Plan")
                        .WithMany("Activities")
                        .HasForeignKey("PlanId");
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.Company", b =>
                {
                    b.HasOne("FleetManagementWebApplication.Models.Manager", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.Driver", b =>
                {
                    b.HasOne("FleetManagementWebApplication.Models.Company", "Company")
                        .WithMany("Drivers")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.ScheduledActivity", b =>
                {
                    b.HasOne("FleetManagementWebApplication.Models.Activity", "Activity")
                        .WithMany("ScheduledActivities")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FleetManagementWebApplication.Models.Vehicle", "Vehicle")
                        .WithMany("ScheduledActivities")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.ServiceLog", b =>
                {
                    b.HasOne("FleetManagementWebApplication.Models.Activity", "Activity")
                        .WithMany("ServiceLogs")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FleetManagementWebApplication.Models.Vehicle", "Vehicle")
                        .WithMany("ServiceLogs")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.Vehicle", b =>
                {
                    b.HasOne("FleetManagementWebApplication.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("FleetManagementWebApplication.Models.Driver", "CurrentDriver")
                        .WithMany()
                        .HasForeignKey("CurrentDriverId");

                    b.HasOne("FleetManagementWebApplication.Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId");

                    b.HasOne("FleetManagementWebApplication.Models.Manager")
                        .WithMany("Vehicles")
                        .HasForeignKey("ManagerId");

                    b.HasOne("FleetManagementWebApplication.Models.Plan", "Plan")
                        .WithMany("Vehicles")
                        .HasForeignKey("PlanId");
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.VehicleLog", b =>
                {
                    b.HasOne("FleetManagementWebApplication.Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FleetManagementWebApplication.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
