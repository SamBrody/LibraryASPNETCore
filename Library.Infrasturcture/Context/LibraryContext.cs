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
        public DbSet<AuthorBook> Author_Book_ { get; set; }
        public DbSet<Book> Book_ { get; set; }
        public DbSet<BookCategory> Book_Category_ { get; set; }
        public DbSet<BookTag> Book_Tag_ { get; set; }
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
            modelBuilder.Entity<Reader>().HasMany(o1 => o1.BookObj).WithOne(o2 => o2.ReaderObj).HasForeignKey(o1 => o1.ReaderId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Shelf>().HasMany(o1 => o1.BookObj).WithOne(o2 => o2.ShelfObj).HasForeignKey(o1 => o1.ShelfId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BookCategory>().HasKey(o1 => new { o1.BookId, o1.CategoryId });
            modelBuilder.Entity<BookCategory>().HasOne<Book>(o1 => o1.BookObj).WithMany(o2 => o2.BookCategoryObj).HasForeignKey(o1 => o1.BookId);
            modelBuilder.Entity<BookCategory>().HasOne<Category>(o1 => o1.CategoryObj).WithMany(o2 => o2.BookCategoryObj).HasForeignKey(o1 => o1.CategoryId);

            modelBuilder.Entity<BookTag>().HasKey(o1 => new { o1.BookId, o1.TagId });
            modelBuilder.Entity<BookTag>().HasOne<Book>(o1 => o1.BookObj).WithMany(o2 => o2.BookTagObj).HasForeignKey(o1 => o1.BookId);
            modelBuilder.Entity<BookTag>().HasOne<Tag>(o1 => o1.TagObj).WithMany(o2 => o2.BookTagObj).HasForeignKey(o1 => o1.TagId);

            modelBuilder.Entity<AuthorBook>().HasKey(o1 => new { o1.BookId, o1.AuthorId });
            modelBuilder.Entity<AuthorBook>().HasOne<Book>(o1 => o1.BooksObj).WithMany(o2 => o2.AuthorBookObj).HasForeignKey(o1 => o1.BookId);
            modelBuilder.Entity<AuthorBook>().HasOne<Author>(o1 => o1.AuthorsObj).WithMany(o2 => o2.AuthorBookObj).HasForeignKey(o1 => o1.AuthorId);
            #endregion

            #region Data setup
            modelBuilder.Entity<Tag>().HasData(
                new Tag[]
                {
                    new Tag{Id=1, Name="#люди" },
                    new Tag{Id=2, Name="#собака"},
                    new Tag{Id=3, Name="#постмодерн"}
                });

            modelBuilder.Entity<Category>().HasData(
                new Category[]
                {
                    new Category{Id=1, Name="Рассказ"},
                    new Category{Id=2, Name="Роман"},               
                });

            modelBuilder.Entity<Shelf>().HasData(
                new Shelf[]
                {
                    new Shelf{Id=1, Name="-" },
                    new Shelf{Id=2, Name="A" },
                    new Shelf{Id=3, Name="B"},
                    new Shelf{Id=4, Name="C"}
                });

            modelBuilder.Entity<Reader>().HasData(
                new Reader[]
                {
                    new Reader{Id=1, FullName="-"},
                    new Reader{Id=2, FullName="Иванов Иван Иванович", BirthDate= new DateTime(1996,1,16), RegistrationDate=new DateTime(2021,7,16)},
                    new Reader{Id=3, FullName="Квашнин Петр Михайлович", BirthDate= new DateTime(1992,5,29), RegistrationDate=new DateTime(2021,6,22)},
                    new Reader{Id=4, FullName="Петрухин Александр Андреевич", BirthDate= new DateTime(2001,9,16), RegistrationDate=new DateTime(2021,7,25)},
                });

            modelBuilder.Entity<Author>().HasData(
                new Author[]
                {
                    new Author{Id=1, FullName="Дэвид Фостер", BirthDate= new DateTime(1962,2,21)},
                    new Author{Id=2, FullName="Иван Сергеевич Тургенев", BirthDate= new DateTime(1818,11,9)}
                });

            modelBuilder.Entity<AuthorBook>().HasData(
                new AuthorBook[]
                {
                    new AuthorBook{Id=1, AuthorId=2, BookId=2},
                    new AuthorBook{Id=2, AuthorId=1, BookId=1}
                });

            modelBuilder.Entity<BookCategory>().HasData(
                new BookCategory[]
                {
                    new BookCategory{Id=1, CategoryId=1, BookId=2},
                    new BookCategory{Id=2, CategoryId=2, BookId=1}
                });

            modelBuilder.Entity<BookTag>().HasData(
                new BookTag[]
                {
                    new BookTag{Id=1, TagId=1, BookId=1},
                    new BookTag{Id=2, TagId=3, BookId=1},
                    new BookTag{Id=3, TagId=1, BookId=2},
                    new BookTag{Id=4, TagId=2, BookId=2}
                });

            modelBuilder.Entity<Book>().HasData(
                new Book[]
                {
                    new Book{Id=1, Title="Бесконечная шутка", ShelfId=2, ReaderId=2, TakeDate=new DateTime(2021,7,17), PhotoPath="infjoke.jpg" },
                    new Book{Id=2, Title="Муму", ShelfId=2, ReaderId=3, TakeDate=new DateTime(2021,7,29), PhotoPath="mymy.jpg" }
                });
            #endregion
        }

    }
}
