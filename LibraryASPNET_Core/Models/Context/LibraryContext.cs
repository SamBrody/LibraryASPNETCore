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

        public LibraryContext()
        {
            Database.EnsureCreated();
        }
     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reader>().HasMany(o1 => o1.BooksObj).WithOne(o2 => o2.ReaderObj).HasForeignKey(o1 => o1.Reader_Id).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Shelves>().HasMany(o1 => o1.BooksObj).WithOne(o2 => o2.ShelfObj).HasForeignKey(o1 => o1.Shelf_Id).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Books_category>().HasKey(o1 => new { o1.Book_Id, o1.Category_Id });
            modelBuilder.Entity<Books_category>().HasOne<Books>(o1 => o1.BooksObj).WithMany(o2 => o2.Books_CategoriesObj).HasForeignKey(o1 => o1.Book_Id);
            modelBuilder.Entity<Books_category>().HasOne<Category>(o1 => o1.CategoriesObj).WithMany(o2 => o2.Books_CategoriesObj).HasForeignKey(o1 => o1.Category_Id);

            modelBuilder.Entity<Books_tags>().HasKey(o1 => new { o1.Book_Id, o1.Tag_Id });
            modelBuilder.Entity<Books_tags>().HasOne<Books>(o1 => o1.BooksObj).WithMany(o2 => o2.Books_TagObj).HasForeignKey(o1 => o1.Book_Id);
            modelBuilder.Entity<Books_tags>().HasOne<Tags>(o1 => o1.TagsObj).WithMany(o2 => o2.Books_TagObj).HasForeignKey(o1 => o1.Tag_Id);

            modelBuilder.Entity<Authors_Books>().HasKey(o1 => new { o1.Book_Id, o1.Author_Id });
            modelBuilder.Entity<Authors_Books>().HasOne<Books>(o1 => o1.BooksObj).WithMany(o2 => o2.Author_BooksObj).HasForeignKey(o1 => o1.Book_Id);
            modelBuilder.Entity<Authors_Books>().HasOne<Authors>(o1 => o1.AuthorsObj).WithMany(o2 => o2.Authors_BooksObj).HasForeignKey(o1 => o1.Author_Id);

            modelBuilder.Entity<Tags>().HasData(
                new Tags[]
                {
                    new Tags{Id=1, Name="#war" },
                    new Tags{Id=2, Name="#love"},
                    new Tags{Id=3, Name="#KILLA"}
                });
            modelBuilder.Entity<Shelves>().HasData(
                new Shelves[]
                {
                    new Shelves{Id=1, Name="A" },
                    new Shelves{Id=2, Name="B"},
                    new Shelves{Id=3, Name="C"}
                });
        }

    }
}
