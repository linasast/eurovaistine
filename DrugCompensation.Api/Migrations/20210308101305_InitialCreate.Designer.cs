﻿// <auto-generated />
using System;
using DrugCompensation.Api.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DrugCompensation.Api.Migrations
{
    [DbContext(typeof(DrugContext))]
    [Migration("20210308101305_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DrugCompensation.Api.Entities.Compensation", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiscountFormula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Compensations");
                });

            modelBuilder.Entity("DrugCompensation.Api.Entities.CompensationRecord", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid?>("CompensationTypeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DrugID")
                        .HasColumnType("int");

                    b.Property<double>("PayableSum")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.HasIndex("CompensationTypeID");

                    b.HasIndex("DrugID");

                    b.ToTable("CompensationRecords");
                });

            modelBuilder.Entity("DrugCompensation.Api.Entities.Drug", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("BasicCompensationPrice")
                        .HasColumnType("float");

                    b.Property<double>("CompensationPercent")
                        .HasColumnType("float");

                    b.Property<double>("RetailPrice")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("Drugs");
                });

            modelBuilder.Entity("DrugCompensation.Api.Entities.CompensationRecord", b =>
                {
                    b.HasOne("DrugCompensation.Api.Entities.Compensation", "CompensationType")
                        .WithMany()
                        .HasForeignKey("CompensationTypeID");

                    b.HasOne("DrugCompensation.Api.Entities.Drug", "Drug")
                        .WithMany()
                        .HasForeignKey("DrugID");

                    b.Navigation("CompensationType");

                    b.Navigation("Drug");
                });
#pragma warning restore 612, 618
        }
    }
}
