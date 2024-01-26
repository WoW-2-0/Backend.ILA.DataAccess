﻿// <auto-generated />
using System;
using EntityConfiguration.ManyToMany.DirectNavigation.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EntityConfiguration.ManyToMany.DirectNavigation.Persistence.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    partial class LibraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EntityConfiguration.ManyToMany.DirectNavigation.Models.Author", b =>
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
                            Id = new Guid("a67cdffc-f7a4-4d23-a882-49a6df9c817f"),
                            Name = "Robert C. Martin"
                        },
                        new
                        {
                            Id = new Guid("4399c1f6-896e-4d54-a88f-1d7206d8997f"),
                            Name = "Martin Fowler"
                        },
                        new
                        {
                            Id = new Guid("b657d94d-0710-415c-8c31-a5e8680b31ed"),
                            Name = "Eric Evans"
                        },
                        new
                        {
                            Id = new Guid("6cef5459-8106-4086-a613-5b19afde6163"),
                            Name = "Steve McConnell"
                        });
                });

            modelBuilder.Entity("EntityConfiguration.ManyToMany.DirectNavigation.Models.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e9582b0d-a6c7-4fdb-b17b-7e9d64e5b784"),
                            Genre = "Programming",
                            Title = "Pro C# 7: With .NET and .NET Core"
                        },
                        new
                        {
                            Id = new Guid("a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6"),
                            Genre = "Programming",
                            Title = "Clean Code: A Handbook of Agile Software Craftsmanship"
                        },
                        new
                        {
                            Id = new Guid("b2c3d4e5-f6a7-48b9-c0d1-e2f3a4b5c6d7"),
                            Genre = "Programming",
                            Title = "Refactoring: Improving the Design of Existing Code"
                        },
                        new
                        {
                            Id = new Guid("c3d4e5f6-a7b8-49c0-d1e2-f3a4b5c6d7e8"),
                            Genre = "Programming",
                            Title = "Domain-Driven Design: Tackling Complexity in the Heart of Software"
                        },
                        new
                        {
                            Id = new Guid("d4e5f6a7-b8c9-4ad0-e1f2-a3b4c5d6e7f8"),
                            Genre = "Programming",
                            Title = "Code Complete: A Practical Handbook of Software Construction"
                        },
                        new
                        {
                            Id = new Guid("e6f7a8b9-c0d1-4ae2-f3b4-c5d6e7f8a9b0"),
                            Genre = "Programming",
                            Title = "Patterns of Enterprise Application Architecture"
                        });
                });

            modelBuilder.Entity("EntityConfiguration.ManyToMany.DirectNavigation.Models.BookAuthor", b =>
                {
                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.HasKey("AuthorId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("BookAuthor", (string)null);

                    b.HasData(
                        new
                        {
                            AuthorId = new Guid("4941dec3-36f6-412d-babc-abd92b79b9bb"),
                            BookId = new Guid("e9582b0d-a6c7-4fdb-b17b-7e9d64e5b784")
                        },
                        new
                        {
                            AuthorId = new Guid("a67cdffc-f7a4-4d23-a882-49a6df9c817f"),
                            BookId = new Guid("a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6")
                        },
                        new
                        {
                            AuthorId = new Guid("4399c1f6-896e-4d54-a88f-1d7206d8997f"),
                            BookId = new Guid("b2c3d4e5-f6a7-48b9-c0d1-e2f3a4b5c6d7")
                        },
                        new
                        {
                            AuthorId = new Guid("b657d94d-0710-415c-8c31-a5e8680b31ed"),
                            BookId = new Guid("c3d4e5f6-a7b8-49c0-d1e2-f3a4b5c6d7e8")
                        },
                        new
                        {
                            AuthorId = new Guid("6cef5459-8106-4086-a613-5b19afde6163"),
                            BookId = new Guid("d4e5f6a7-b8c9-4ad0-e1f2-a3b4c5d6e7f8")
                        },
                        new
                        {
                            AuthorId = new Guid("4399c1f6-896e-4d54-a88f-1d7206d8997f"),
                            BookId = new Guid("e6f7a8b9-c0d1-4ae2-f3b4-c5d6e7f8a9b0")
                        },
                        new
                        {
                            AuthorId = new Guid("b657d94d-0710-415c-8c31-a5e8680b31ed"),
                            BookId = new Guid("e6f7a8b9-c0d1-4ae2-f3b4-c5d6e7f8a9b0")
                        });
                });

            modelBuilder.Entity("EntityConfiguration.ManyToMany.DirectNavigation.Models.BookAuthor", b =>
                {
                    b.HasOne("EntityConfiguration.ManyToMany.DirectNavigation.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityConfiguration.ManyToMany.DirectNavigation.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}