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
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName(keyName);
               
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


            });
        }

    }
}
