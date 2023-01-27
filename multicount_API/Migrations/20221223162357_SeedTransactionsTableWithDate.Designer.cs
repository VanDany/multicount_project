﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using multicount_API.Data;

#nullable disable

namespace multicountAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221223162357_SeedTransactionsTableWithDate")]
    partial class SeedTransactionsTableWithDate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("multicount_API.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 51.12f,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2022, 12, 23, 17, 23, 57, 232, DateTimeKind.Local).AddTicks(2418),
                            Description = "Raclette",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Amount = 5.75f,
                            CategoryId = 2,
                            CreatedDate = new DateTime(2022, 12, 23, 17, 23, 57, 232, DateTimeKind.Local).AddTicks(2445),
                            Description = "Bananes pour tous",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Amount = 450.11f,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2022, 12, 23, 17, 23, 57, 232, DateTimeKind.Local).AddTicks(2446),
                            Description = "Chauffage",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Amount = 23.59f,
                            CategoryId = 4,
                            CreatedDate = new DateTime(2022, 12, 23, 17, 23, 57, 232, DateTimeKind.Local).AddTicks(2448),
                            Description = "Casseroles",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Amount = 684.42f,
                            CategoryId = 5,
                            CreatedDate = new DateTime(2022, 12, 23, 17, 23, 57, 232, DateTimeKind.Local).AddTicks(2449),
                            Description = "Isolation",
                            UpdatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
