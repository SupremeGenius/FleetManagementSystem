﻿// <auto-generated />
using System;
using FleetManagementWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FleetManagementWebApplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("FleetManagementWebApplication.Models.Bill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Cost");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("Date");

                    b.Property<string>("Provider")
                        .HasMaxLength(150);

                    b.Property<string>("Service")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<long?>("VehicleId");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("Bills");
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

            modelBuilder.Entity("FleetManagementWebApplication.Models.Delivery", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Answered");

                    b.Property<long?>("ClientId");

                    b.Property<long?>("CompanyId");

                    b.Property<string>("DestinationCity");

                    b.Property<double>("DestinationLatitude");

                    b.Property<double>("DestinationLongtitude");

                    b.Property<long?>("DriverId");

                    b.Property<bool>("Finished");

                    b.Property<float>("OptimalDistance");

                    b.Property<float>("OptimalFuelConsumption");

                    b.Property<int>("OptimalTime");

                    b.Property<int>("Quantity");

                    b.Property<string>("SourceCity");

                    b.Property<double>("SourceLatitude");

                    b.Property<double>("SourceLongtitude");

                    b.Property<bool>("Started");

                    b.Property<DateTime>("Time");

                    b.Property<long?>("VehicleId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DriverId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Deliveries");
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.DeliverySummary", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("DeliveryId");

                    b.Property<float>("EndFuelLevel");

                    b.Property<float>("EndOdometer");

                    b.Property<DateTime>("EndTime");

                    b.Property<bool>("NumberOfHarshbreaks");

                    b.Property<bool>("NumberOfNoSeatbelts");

                    b.Property<int>("NumberOfSpeedings");

                    b.Property<float>("StartFuelLevel");

                    b.Property<float>("StartOdometer");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryId");

                    b.ToTable("DeliverySummaries");
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

            modelBuilder.Entity("FleetManagementWebApplication.Models.MapLocation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Langtitude");

                    b.Property<float>("Latitude");

                    b.Property<string>("Name");

                    b.Property<long?>("RouteId");

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.ToTable("MapLocations");
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

            modelBuilder.Entity("FleetManagementWebApplication.Models.Route", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.ScheduledActivity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActivityId");

                    b.Property<long>("CompanyId");

                    b.Property<DateTime>("DueDate");

                    b.Property<long>("VehicleId");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("VehicleId");

                    b.ToTable("ScheduledActivities");
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.Vehicle", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CompanyId");

                    b.Property<long?>("CurrentDriverId");

                    b.Property<int>("CurrentLoad");

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

                    b.Property<bool>("isCurrentlyActive");

                    b.Property<DateTime>("purchaseDate")
                        .HasColumnType("Date");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CurrentDriverId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("PlanId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.Activity", b =>
                {
                    b.HasOne("FleetManagementWebApplication.Models.Plan", "Plan")
                        .WithMany("Activities")
                        .HasForeignKey("PlanId");
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.Bill", b =>
                {
                    b.HasOne("FleetManagementWebApplication.Models.Vehicle", "Vehicle")
                        .WithMany("Bills")
                        .HasForeignKey("VehicleId");
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.Company", b =>
                {
                    b.HasOne("FleetManagementWebApplication.Models.Manager", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.Delivery", b =>
                {
                    b.HasOne("FleetManagementWebAplication.Models.Client", "Client")
                        .WithMany("Deliveries")
                        .HasForeignKey("ClientId");

                    b.HasOne("FleetManagementWebApplication.Models.Company", "Company")
                        .WithMany("Deliveries")
                        .HasForeignKey("CompanyId");

                    b.HasOne("FleetManagementWebApplication.Models.Driver", "Driver")
                        .WithMany("Deliveries")
                        .HasForeignKey("DriverId");

                    b.HasOne("FleetManagementWebApplication.Models.Vehicle", "Vehicle")
                        .WithMany("Deliveries")
                        .HasForeignKey("VehicleId");
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.DeliverySummary", b =>
                {
                    b.HasOne("FleetManagementWebApplication.Models.Delivery", "Delivery")
                        .WithMany()
                        .HasForeignKey("DeliveryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.Driver", b =>
                {
                    b.HasOne("FleetManagementWebApplication.Models.Company", "Company")
                        .WithMany("Drivers")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("FleetManagementWebApplication.Models.MapLocation", b =>
                {
                    b.HasOne("FleetManagementWebApplication.Models.Route", "Route")
                        .WithMany("Points")
                        .HasForeignKey("RouteId");
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

            modelBuilder.Entity("FleetManagementWebApplication.Models.Vehicle", b =>
                {
                    b.HasOne("FleetManagementWebApplication.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("FleetManagementWebApplication.Models.Driver", "CurrentDriver")
                        .WithMany()
                        .HasForeignKey("CurrentDriverId");

                    b.HasOne("FleetManagementWebApplication.Models.Manager")
                        .WithMany("Vehicles")
                        .HasForeignKey("ManagerId");

                    b.HasOne("FleetManagementWebApplication.Models.Plan", "Plan")
                        .WithMany("Vehicles")
                        .HasForeignKey("PlanId");
                });
#pragma warning restore 612, 618
        }
    }
}
