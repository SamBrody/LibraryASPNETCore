using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Infrasturcture.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        public DbSet<Author> Author_ { get; set; }
        public DbSet<Author_Book> Author_Book_ { get; set; }
        public DbSet<Book> Book_ { get; set; }
        public DbSet<Book_category> Book_Category_ { get; set; }
        public DbSet<Book_tag> Book_Tag_ { get; set; }
        public DbSet<Category> Category_ { get; set; }
        public DbSet<Reader> Reader_ { get; set; }
        public DbSet<Shelf> Shelf_ { get; set; }
        public DbSet<Tag> Tag_ { get; set; }

        public LibraryContext()
        {
            Database.EnsureCreated();
        }
     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Relationship setup
            modelBuilder.Entity<Reader>().HasMany(o1 => o1.BookObj).WithOne(o2 => o2.ReaderObj).HasForeignKey(o1 => o1.Reader_Id).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Shelf>().HasMany(o1 => o1.BookObj).WithOne(o2 => o2.ShelfObj).HasForeignKey(o1 => o1.Shelf_Id).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Book_category>().HasKey(o1 => new { o1.Book_Id, o1.Category_Id });
            modelBuilder.Entity<Book_category>().HasOne<Book>(o1 => o1.BookObj).WithMany(o2 => o2.Book_CategoryObj).HasForeignKey(o1 => o1.Book_Id);
            modelBuilder.Entity<Book_category>().HasOne<Category>(o1 => o1.CategoryObj).WithMany(o2 => o2.Book_CategoryObj).HasForeignKey(o1 => o1.Category_Id);

            modelBuilder.Entity<Book_tag>().HasKey(o1 => new { o1.Book_Id, o1.Tag_Id });
            modelBuilder.Entity<Book_tag>().HasOne<Book>(o1 => o1.BookObj).WithMany(o2 => o2.Book_TagObj).HasForeignKey(o1 => o1.Book_Id);
            modelBuilder.Entity<Book_tag>().HasOne<Tag>(o1 => o1.TagObj).WithMany(o2 => o2.Book_TagObj).HasForeignKey(o1 => o1.Tag_Id);

            modelBuilder.Entity<Author_Book>().HasKey(o1 => new { o1.Book_Id, o1.Author_Id });
            modelBuilder.Entity<Author_Book>().HasOne<Book>(o1 => o1.BooksObj).WithMany(o2 => o2.Author_BookObj).HasForeignKey(o1 => o1.Book_Id);
            modelBuilder.Entity<Author_Book>().HasOne<Author>(o1 => o1.AuthorsObj).WithMany(o2 => o2.Author_BookObj).HasForeignKey(o1 => o1.Author_Id);
            #endregion

            #region Data setup
            modelBuilder.Entity<Tag>().HasData(
                new Tag[]
                {
                    new Tag{Id=1, Name="#war" },
                    new Tag{Id=2, Name="#love"},
                    new Tag{Id=3, Name="#KILLA"}
                });

            modelBuilder.Entity<Category>().HasData(
                new Category[]
                {
                    new Category{Id=1, Name="Детектив"},
                    new Category{Id=2, Name="Фантастика"},
                    new Category{Id=3, Name="Фэнтези"},
                    new Category{Id=4, Name="Приключения"},
                    new Category{Id=5, Name="История"}
                });

            modelBuilder.Entity<Shelf>().HasData(
                new Shelf[]
                {
                    new Shelf{Id=1, Name="A" },
                    new Shelf{Id=2, Name="B"},
                    new Shelf{Id=3, Name="C"}
                });

            modelBuilder.Entity<Reader>().HasData(
                new Reader[]
                {
                    new Reader{Id=1, Full_Name="Иванов Иван Иванович", BirthDate= new DateTime(1996,1,16), RegistrationDate=new DateTime(2021,7,16)},
                    new Reader{Id=2, Full_Name="Квашнин Петр Михайлович", BirthDate= new DateTime(1992,5,29), RegistrationDate=new DateTime(2021,6,22)},
                    new Reader{Id=3, Full_Name="Петрухин Александр Андреевич", BirthDate= new DateTime(2001,9,16), RegistrationDate=new DateTime(2021,7,25)},
                });

            modelBuilder.Entity<Book>().HasData(
                new Book[]
                {
                    new Book{Id=1, Title="Бесконечная шутка", Shelf_Id=1, Reader_Id=1, TakeDate=new DateTime(2021,7,17), PhotoPath="infjoke.jpg"}
                });
            #endregion
        }

    }
}
