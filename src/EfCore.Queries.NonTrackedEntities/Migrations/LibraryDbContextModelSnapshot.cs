﻿// <auto-generated />
using System;
using EfCore.Queries.NonTrackedEntities.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EfCore.Queries.NonTrackedEntities.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    partial class LibraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EfCore.Queries.NonTrackedEntities.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("aea165f8-69e5-4605-b45b-1e66227445ba"),
                            Title = "Asp.NET Core in Action"
                        },
                        new
                        {
                            Id = new Guid("d0ba9d76-f454-41b6-aad8-23dcea4ef167"),
                            Title = "C# 12 and .Net 8"
                        });
                });

            modelBuilder.Entity("EfCore.Queries.NonTrackedEntities.Models.BookReview", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("BookReviews");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1c832fc1-1146-4aa8-819c-e6e0788a4e50"),
                            BookId = new Guid("aea165f8-69e5-4605-b45b-1e66227445ba"),
                            Review = "Great book"
                        },
                        new
                        {
                            Id = new Guid("c7e81257-582e-4b4f-96d3-96dc8506b9da"),
                            BookId = new Guid("aea165f8-69e5-4605-b45b-1e66227445ba"),
                            Review = "Awesome book"
                        });
                });

            modelBuilder.Entity("EfCore.Queries.NonTrackedEntities.Models.BookReview", b =>
                {
                    b.HasOne("EfCore.Queries.NonTrackedEntities.Models.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("EfCore.Queries.NonTrackedEntities.Models.Book", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}