﻿// <auto-generated />
using System;
using Library_DueDate_Tracker_With_Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library_DueDate_Tracker_With_Database.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20201104041613_SeedAuthorData")]
    partial class SeedAuthorData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Library_DueDate_Tracker_With_Database.Models.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<DateTime>("DeathDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("ID");

                    b.ToTable("author");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            DateOfBirth = new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeathDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Edith Eva Eger"
                        },
                        new
                        {
                            ID = 2,
                            DateOfBirth = new DateTime(1960, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeathDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "David Mitchell"
                        },
                        new
                        {
                            ID = 3,
                            DateOfBirth = new DateTime(1960, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeathDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Abhijit V. Banerjee"
                        },
                        new
                        {
                            ID = 4,
                            DateOfBirth = new DateTime(1960, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeathDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "John M. Barry"
                        },
                        new
                        {
                            ID = 5,
                            DateOfBirth = new DateTime(1960, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeathDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Robert Iger"
                        });
                });

            modelBuilder.Entity("Library_DueDate_Tracker_With_Database.Models.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10)");

                    b.Property<int>("AuthorID")
                        .HasColumnType("int(10)");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_general_ci");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID")
                        .HasName("FK_Book_Author");

                    b.ToTable("book");
                });

            modelBuilder.Entity("Library_DueDate_Tracker_With_Database.Models.Borrow", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(10)");

                    b.Property<int>("BookID")
                        .HasColumnType("int(10)");

                    b.Property<DateTime>("ChechedOutDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("ReturnedDate")
                        .HasColumnType("date");

                    b.HasKey("ID");

                    b.HasIndex("BookID")
                        .HasName("FK_Borrow_Book");

                    b.ToTable("borrow");
                });

            modelBuilder.Entity("Library_DueDate_Tracker_With_Database.Models.Book", b =>
                {
                    b.HasOne("Library_DueDate_Tracker_With_Database.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorID")
                        .HasConstraintName("FK_Book_Author")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Library_DueDate_Tracker_With_Database.Models.Borrow", b =>
                {
                    b.HasOne("Library_DueDate_Tracker_With_Database.Models.Book", "Book")
                        .WithMany("Borrows")
                        .HasForeignKey("BookID")
                        .HasConstraintName("FK_Borrow_Book")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
