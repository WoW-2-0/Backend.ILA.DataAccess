﻿// <auto-generated />
using System;
using EfCore.Queries.GlobalQueryFilter.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EfCore.Queries.GlobalQueryFilter.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    partial class LibraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            DeletedTime = new DateTimeOffset(new DateTime(2023, 11, 13, 14, 27, 40, 808, DateTimeKind.Unspecified).AddTicks(5799), new TimeSpan(0, 5, 0, 0, 0)),
                            IsDeleted = true,
                            Name = "Mark. J. Price"
                        });
                });

            modelBuilder.Entity("EfCore.Queries.GlobalQueryFilter.Models.AuthorBook", b =>
                {
                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.HasKey("AuthorId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("AuthorBooks");

                    b.HasData(
                        new
                        {
                            AuthorId = new Guid("4941dec3-36f6-412d-babc-abd92b79b9bb"),
                            BookId = new Guid("4abd35a4-1d02-4e3f-9cca-50446c824540")
                        },
                        new
                        {
                            AuthorId = new Guid("4941dec3-36f6-412d-babc-abd92b79b9bb"),
                            BookId = new Guid("845f0813-88ee-4dfb-9e1f-8d8bb1c1e686")
                        },
                        new
                        {
                            AuthorId = new Guid("e0817981-a236-4836-bbdd-326ddb6565d3"),
                            BookId = new Guid("845f0813-88ee-4dfb-9e1f-8d8bb1c1e686")
                        },
                        new
                        {
                            AuthorId = new Guid("4941dec3-36f6-412d-babc-abd92b79b9bb"),
                            BookId = new Guid("ea55317a-2836-46f6-ad53-d10da0647ed9")
                        });
                });

            modelBuilder.Entity("EfCore.Queries.GlobalQueryFilter.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTimeOffset?>("DeletedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("Pages")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4abd35a4-1d02-4e3f-9cca-50446c824540"),
                            Genre = "Programming",
                            IsDeleted = false,
                            Pages = 1376,
                            Title = "Pro C# 7: With .NET and .NET Core"
                        },
                        new
                        {
                            Id = new Guid("845f0813-88ee-4dfb-9e1f-8d8bb1c1e686"),
                            Genre = "Programming",
                            IsDeleted = false,
                            Pages = 900,
                            Title = "Complete C# 7 Design Patterns"
                        },
                        new
                        {
                            Id = new Guid("ea55317a-2836-46f6-ad53-d10da0647ed9"),
                            DeletedTime = new DateTimeOffset(new DateTime(2023, 11, 13, 14, 27, 40, 809, DateTimeKind.Unspecified).AddTicks(2119), new TimeSpan(0, 5, 0, 0, 0)),
                            Genre = "Programming",
                            IsDeleted = true,
                            Pages = 900,
                            Title = "Pro C# 12 with .NET 8"
                        });
                });

            modelBuilder.Entity("EfCore.Queries.GlobalQueryFilter.Models.AuthorBook", b =>
                {
                    b.HasOne("EfCore.Queries.GlobalQueryFilter.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("EfCore.Queries.GlobalQueryFilter.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.Navigation("Author");

                    b.Navigation("Book");
                });
#pragma warning restore 612, 618
        }
    }
}