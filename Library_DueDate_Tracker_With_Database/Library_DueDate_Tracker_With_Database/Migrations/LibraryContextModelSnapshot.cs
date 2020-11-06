﻿// <auto-generated />
using System;
using Library_DueDate_Tracker_With_Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library_DueDate_Tracker_With_Database.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime?>("DeathDate")
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
                            ID = -1,
                            DateOfBirth = new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Edith Eva Eger"
                        },
                        new
                        {
                            ID = -2,
                            DateOfBirth = new DateTime(1960, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "David Mitchell"
                        },
                        new
                        {
                            ID = -3,
                            DateOfBirth = new DateTime(1960, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Abhijit V. Banerjee"
                        },
                        new
                        {
                            ID = -4,
                            DateOfBirth = new DateTime(1960, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "John M. Barry"
                        },
                        new
                        {
                            ID = -5,
                            DateOfBirth = new DateTime(1960, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
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

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AuthorID = -1,
                            PublicationDate = new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Choice"
                        },
                        new
                        {
                            ID = 2,
                            AuthorID = -2,
                            PublicationDate = new DateTime(2015, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Cloud Atlas"
                        },
                        new
                        {
                            ID = 3,
                            AuthorID = -3,
                            PublicationDate = new DateTime(2015, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Good Economics for Hard Times"
                        },
                        new
                        {
                            ID = 4,
                            AuthorID = -4,
                            PublicationDate = new DateTime(2015, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Great Influenza"
                        },
                        new
                        {
                            ID = 5,
                            AuthorID = -5,
                            PublicationDate = new DateTime(2015, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Ride of a Lifetime"
                        },
                        new
                        {
                            ID = 6,
                            AuthorID = -3,
                            PublicationDate = new DateTime(2016, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Good Economics for Hard Times part 2"
                        },
                        new
                        {
                            ID = 7,
                            AuthorID = -3,
                            PublicationDate = new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Good Economics for Hard Times part 3"
                        });
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

                    b.Property<DateTime?>("ReturnedDate")
                        .HasColumnType("date");

                    b.HasKey("ID");

                    b.HasIndex("BookID")
                        .HasName("FK_Borrow_Book");

                    b.ToTable("borrow");

                    b.HasData(
                        new
                        {
                            ID = -11,
                            BookID = 1,
                            ChechedOutDate = new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2016, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = -22,
                            BookID = 2,
                            ChechedOutDate = new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2016, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = -33,
                            BookID = 3,
                            ChechedOutDate = new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2016, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = -44,
                            BookID = 4,
                            ChechedOutDate = new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2016, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = -55,
                            BookID = 5,
                            ChechedOutDate = new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2016, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = -66,
                            BookID = 6,
                            ChechedOutDate = new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2016, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ID = -77,
                            BookID = 7,
                            ChechedOutDate = new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2016, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Library_DueDate_Tracker_With_Database.Models.Book", b =>
                {
                    b.HasOne("Library_DueDate_Tracker_With_Database.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorID")
                        .HasConstraintName("FK_Book_Author")
                        .OnDelete(DeleteBehavior.Restrict)
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
