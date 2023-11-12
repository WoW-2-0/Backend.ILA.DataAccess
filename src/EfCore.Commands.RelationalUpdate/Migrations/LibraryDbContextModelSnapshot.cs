﻿// <auto-generated />
using System;
using EfCore.Commands.RelationalUpdate.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EfCore.Commands.RelationalUpdate.Migrations
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

            modelBuilder.Entity("AuthorBooks", b =>
                {
                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.HasKey("AuthorId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("AuthorBooks");
                });

            modelBuilder.Entity("EfCore.Commands.RelationalUpdate.Models.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4941dec3-36f6-412d-babc-abd92b79b9bb"),
                            Name = "Andrew Troelsen"
                        },
                        new
                        {
                            Id = new Guid("e0817981-a236-4836-bbdd-326ddb6565d3"),
                            Name = "Mark. J. Price"
                        });
                });

            modelBuilder.Entity("EfCore.Commands.RelationalUpdate.Models.AuthorBiography", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId")
                        .IsUnique();

                    b.ToTable("AuthorBiographies");
                });

            modelBuilder.Entity("EfCore.Commands.RelationalUpdate.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Pages")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("EfCore.Commands.RelationalUpdate.Models.BookReview", b =>
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
                });

            modelBuilder.Entity("AuthorBooks", b =>
                {
                    b.HasOne("EfCore.Commands.RelationalUpdate.Models.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCore.Commands.RelationalUpdate.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("EfCore.Commands.RelationalUpdate.Models.AuthorBiography", b =>
                {
                    b.HasOne("EfCore.Commands.RelationalUpdate.Models.Author", null)
                        .WithOne("Biography")
                        .HasForeignKey("EfCore.Commands.RelationalUpdate.Models.AuthorBiography", "AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EfCore.Commands.RelationalUpdate.Models.BookReview", b =>
                {
                    b.HasOne("EfCore.Commands.RelationalUpdate.Models.Book", null)
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EfCore.Commands.RelationalUpdate.Models.Author", b =>
                {
                    b.Navigation("Biography")
                        .IsRequired();
                });

            modelBuilder.Entity("EfCore.Commands.RelationalUpdate.Models.Book", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}