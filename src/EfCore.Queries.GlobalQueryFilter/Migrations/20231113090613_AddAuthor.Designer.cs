﻿// <auto-generated />
using System;
using EfCore.Queries.GlobalQueryFilter.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EfCore.Queries.GlobalQueryFilter.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20231113090613_AddAuthor")]
    partial class AddAuthor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EfCore.Queries.GlobalQueryFilter.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4941dec3-36f6-412d-babc-abd92b79b9bb"),
                            IsDeleted = false,
                            Name = "Andrew Troelsen"
                        },
                        new
                        {
                            Id = new Guid("e0817981-a236-4836-bbdd-326ddb6565d3"),
                            DeletedTime = new DateTimeOffset(new DateTime(2023, 11, 13, 14, 6, 13, 448, DateTimeKind.Unspecified).AddTicks(612), new TimeSpan(0, 5, 0, 0, 0)),
                            IsDeleted = true,
                            Name = "Mark. J. Price"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
