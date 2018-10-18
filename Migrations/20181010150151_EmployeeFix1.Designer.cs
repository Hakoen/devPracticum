﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ticketSystem.Migrations
{
    [DbContext(typeof(ticketSystemContext))]
    [Migration("20181010150151_EmployeeFix1")]
    partial class EmployeeFix1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Company", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Birthdate");

                    b.Property<int?>("CompanyID");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("SSN");

                    b.HasKey("ID");

                    b.HasIndex("CompanyID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("EmployeeTask", b =>
                {
                    b.Property<int>("EmployeeID");

                    b.Property<int>("TaskID");

                    b.HasKey("EmployeeID", "TaskID");

                    b.HasIndex("TaskID");

                    b.ToTable("EmployeeTask");
                });

            modelBuilder.Entity("Task", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("ID");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("Employee", b =>
                {
                    b.HasOne("Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyID");
                });

            modelBuilder.Entity("EmployeeTask", b =>
                {
                    b.HasOne("Employee", "Employee")
                        .WithMany("Tasks")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Task", "Task")
                        .WithMany("Employees")
                        .HasForeignKey("TaskID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
