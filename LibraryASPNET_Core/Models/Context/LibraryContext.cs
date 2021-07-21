using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryASPNET_Core.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        public DbSet<Authors> Authors_ { get; set; }
        public DbSet<Authors_Books> Authors_Books_ { get; set; }
        public DbSet<Books> Books_ { get; set; }
        public DbSet<Books_category> Books_Categories_ { get; set; }
        public DbSet<Books_tags> Books_Tags_ { get; set; }
        public DbSet<Category> Categories_ { get; set; }
        public DbSet<Reader> Readers_ { get; set; }
        public DbSet<Shelves> Shelves_ { get; set; }
        public DbSet<Tags> Tags_ { get; set; }

        /*public LibraryContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=localhost;database=CSharpProj;user=root;password=Sam19brody96117$emyon");
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>().ToTable("Author");
            modelBuilder.Entity<Authors_Books>().ToTable("Author_Book");
            modelBuilder.Entity<Books>().ToTable("Book");
            modelBuilder.Entity<Books_category>().ToTable("Book_Category");
            modelBuilder.Entity<Books_tags>().ToTable("Book_Tag");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Reader>().ToTable("Reader");
            modelBuilder.Entity<Shelves>().ToTable("Shelf");
            modelBuilder.Entity<Tags>().ToTable("Tag");
        }

    }
}
