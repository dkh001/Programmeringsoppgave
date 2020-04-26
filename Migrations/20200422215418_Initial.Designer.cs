﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Programmeringsoppgave.Data;

namespace Programmeringsoppgave.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200422215418_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Programmeringsoppgave.Models.Entities.DailyMeasure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Customer_id")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<string>("Meter_id")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Resolution")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.Property<string>("Values")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DailyMeasure");
                });
#pragma warning restore 612, 618
        }
    }
}