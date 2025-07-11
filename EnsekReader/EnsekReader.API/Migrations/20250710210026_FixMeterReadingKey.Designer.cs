﻿// <auto-generated />
using System;
using EnsekReader.API.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EnsekReader.API.Migrations
{
    [DbContext(typeof(EnsekDbContext))]
    [Migration("20250710210026_FixMeterReadingKey")]
    partial class FixMeterReadingKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("EnsekReader.API.Models.MeterReading", b =>
                {
                    b.Property<DateTime>("MeterReadingDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("MeterReadValue")
                        .HasColumnType("int");

                    b.HasKey("MeterReadingDateTime");

                    b.ToTable("MeterReadings");
                });
#pragma warning restore 612, 618
        }
    }
}
