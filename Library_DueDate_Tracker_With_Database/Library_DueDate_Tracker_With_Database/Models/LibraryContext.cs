using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_DueDate_Tracker_With_Database.Models
{
    public class LibraryContext : DbContext
    {
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Borrow> Borrows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connection =
                    "server=localhost;" +
                    "port=3306;" +
                    "user=root;" +
                    "database=mvc_library;";

                string version = "10.4.14-MariaDB";

                optionsBuilder.UseMySql(connection, x => x.ServerVersion(version));
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Name)
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_general_ci");

                entity.HasData(
                    new Author()
                    {
                        ID = -1,
                        Name = "Edith Eva Eger",
                        DateOfBirth = new DateTime(1960, 01, 01),
                        DeathDate = null
                    },
                    new Author()
                    {
                        ID = -2,
                        Name = "David Mitchell",
                        DateOfBirth = new DateTime(1960, 02, 02),
                        DeathDate = null
                    },
                    new Author()
                    {
                        ID = -3,
                        Name = "Abhijit V. Banerjee",
                        DateOfBirth = new DateTime(1960, 03, 03),
                        DeathDate = null
                    },
                    new Author()
                    {
                        ID = -4,
                        Name = "John M. Barry",
                        DateOfBirth = new DateTime(1960, 04, 04),
                        DeathDate = null
                    },
                    new Author()
                    {
                        ID = -5,
                        Name = "Robert Iger",
                        DateOfBirth = new DateTime(1960, 05, 05),
                        DeathDate = null
                    }

                );

            });
            modelBuilder.Entity<Book>(entity =>
            {
                string keyName = "FK_" + nameof(Book) +
                    "_" + nameof(Author);

                entity.Property(e => e.Title)
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.AuthorID)
                .HasName(keyName);

                entity.HasOne(thisEntity => thisEntity.Author)
                .WithMany(parent => parent.Books)
                .HasForeignKey(thisEntity => thisEntity.AuthorID)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName(keyName);

                entity.HasData(
                    new Book()
                    {
                        ID = 1,
                        AuthorID = -1,
                        Title = "The Choice",
                        PublicationDate = new DateTime(2015, 01, 01)
                    },
                    new Book()
                    {
                        ID = 2,
                        AuthorID = -2,
                        Title = "Cloud Atlas",
                        PublicationDate = new DateTime(2015, 02, 02)
                    },
                    new Book()
                    {
                        ID = 3,
                        AuthorID = -3,
                        Title = "Good Economics for Hard Times",
                        PublicationDate = new DateTime(2015, 03, 03)
                    },
                    new Book()
                    {
                        ID = 4,
                        AuthorID = -4,
                        Title = "The Great Influenza",
                        PublicationDate = new DateTime(2015, 04, 04)
                    },
                    new Book()
                    {
                        ID = 5,
                        AuthorID = -5,
                        Title = "The Ride of a Lifetime",
                        PublicationDate = new DateTime(2015, 05, 05)
                    },
                    new Book()
                    {
                        ID = 6,
                        AuthorID = -3,
                        Title = "Good Economics for Hard Times part 2",
                        PublicationDate = new DateTime(2016, 03, 03)
                    },
                    new Book()
                    {
                        ID = 7,
                        AuthorID = -3,
                        Title = "Good Economics for Hard Times part 3",
                        PublicationDate = new DateTime(2017, 03, 03)
                    }
                );
            });
            modelBuilder.Entity<Borrow>(entity =>
            {
                string keyName = "FK_" + nameof(Borrow) +
                    "_" + nameof(Book);

                entity.HasIndex(e => e.BookID)
                .HasName(keyName);

                entity.HasOne(thisEntity => thisEntity.Book)
                .WithMany(parent => parent.Borrows)
                .HasForeignKey(thisEntity => thisEntity.BookID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName(keyName);

                entity.HasData(
                    new Borrow()
                    {
                        ID = -11,
                        BookID = 1,
                        CheckedOutDate = new DateTime(2019, 12, 25),
                        DueDate = new DateTime(2020, 01, 08),
                        ReturnedDate = null,
                        ExtensionCount = 0
                    },
                    new Borrow()
                    {
                        ID = -22,
                        BookID = 2,
                        CheckedOutDate = new DateTime(2019, 12, 25),
                        DueDate = new DateTime(2020, 01, 08),
                        ReturnedDate = null,
                        ExtensionCount = 0
                    },
                    new Borrow()
                    {
                        ID = -33,
                        BookID = 3,
                        CheckedOutDate = new DateTime(2019, 12, 25),
                        DueDate = new DateTime(2020, 01, 08),
                        ReturnedDate = new DateTime(2020,01,05),
                        ExtensionCount = 0
                    },
                    new Borrow()
                    {
                        ID = -44,
                        BookID = 4,
                        CheckedOutDate = new DateTime(2019, 12, 25),
                        DueDate = new DateTime(2020, 01, 08),
                        ReturnedDate = null,
                        ExtensionCount = 0
                    },
                    new Borrow()
                    {
                        ID = -55,
                        BookID = 5,
                        CheckedOutDate = new DateTime(2019, 12, 25),
                        DueDate = new DateTime(2020, 01, 08),
                        ReturnedDate = null,
                        ExtensionCount = 0
                    },
                    new Borrow()
                    {
                        ID = -66,
                        BookID = 6,
                        CheckedOutDate = new DateTime(2019, 12, 25),
                        DueDate = new DateTime(2020, 01, 08),
                        ReturnedDate = new DateTime(2020, 01, 10),
                        ExtensionCount = 0
                    },
                    new Borrow()
                    {
                        ID = -77,
                        BookID = 7,
                        CheckedOutDate = new DateTime(2019, 12, 25),
                        DueDate = new DateTime(2020, 01, 08),
                        ReturnedDate = null,
                        ExtensionCount = 0
                    });
            });
        }

    }
}

