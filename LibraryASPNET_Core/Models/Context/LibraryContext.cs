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

            #region Relationship setup
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
            #endregion

            #region Data setup
            modelBuilder.Entity<Tags>().HasData(
                new Tags[]
                {
                    new Tags{Id=1, Name="#war" },
                    new Tags{Id=2, Name="#love"},
                    new Tags{Id=3, Name="#KILLA"}
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

            modelBuilder.Entity<Shelves>().HasData(
                new Shelves[]
                {
                    new Shelves{Id=1, Name="A" },
                    new Shelves{Id=2, Name="B"},
                    new Shelves{Id=3, Name="C"}
                });

            modelBuilder.Entity<Reader>().HasData(
                new Reader[]
                {
                    new Reader{Id=1, First_Name="Иван", Last_Name="Иванов", Patronymic="Иванович", BirthDate= new DateTime(1996,1,16), RegistrationDate=new DateTime(2021,7,16)},
                    new Reader{Id=2, First_Name="Петр", Last_Name="Квашнин", Patronymic="Михайлович", BirthDate= new DateTime(1992,5,29), RegistrationDate=new DateTime(2021,6,22)},
                    new Reader{Id=3, First_Name="Александр", Last_Name="Петрухин", Patronymic="Андреевич", BirthDate= new DateTime(2001,9,16), RegistrationDate=new DateTime(2021,7,25)},
                });

            modelBuilder.Entity<Books>().HasData(
                new Books[]
                {
                    new Books{Id=1, Title="Бесконечная шутка", Shelf_Id=1, Reader_Id=1, TakeDate=new DateTime(2021,7,17), PhotoPath=@"C:\Users\semyo\Desktop\images\1"}
                });
            #endregion
        }

    }
}
