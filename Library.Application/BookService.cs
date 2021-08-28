using AutoMapper;
using Library.Application.Dto;
using Library.Domain.Models;
using Library.Infrasturcture.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Application
{
    public class BookService : IBookService
    {
        private readonly LibraryContext _libraryContext;
        private readonly IMapper _mapper;

        public BookService(LibraryContext libraryContext, IMapper mapper)
        {
            _libraryContext = libraryContext;
            _mapper = mapper;
        }

        public void AddBook(BookDTO bookDTO, int[] selectedAuthorsId, int[] selectedCategoriesId, int[] selectedTagsId, int shelfId, int? readerId)
        {            
            Book book = new Book {Title = bookDTO.Title, PhotoPath = bookDTO.PhotoPath, TakeDate = bookDTO.TakeDate, ShelfId = shelfId, ReaderId = readerId};
            _libraryContext.Book_.Add(book);
            _libraryContext.SaveChanges();

            int bookId = book.Id;
            // обрабатываем AuthorBook
            AddAuthorBook(bookId, selectedAuthorsId);
            // обрабатываем BookCategory
            AddBookCategory(bookId, selectedCategoriesId);
            // обрабатываем BookTag
            AddBookTag(bookId, selectedTagsId);
        }

        public void Delete(int id)
        {
            var book = _libraryContext.Book_.Where(x => x.Id == id).First();
            _libraryContext.Remove(book);
            _libraryContext.SaveChanges();
        }

        public IList<BookDTO> GetAllBooks()
        {
            var book = _libraryContext.Book_.Include(b => b.ReaderObj).Include(b => b.ShelfObj).ToList();
            var bookDTOs = _mapper.Map<List<BookDTO>>(book);
            foreach (var b in bookDTOs)
                LoadAndAssignBooksEntities(b);                
            return (bookDTOs);
        }

        public void Update(BookDTO bookDTO, int[] selectedAuthorsId, int[] selectedCategoriesId, int[] selectedTagsId, int shelfId, int? readerId)
        {
            int bookId = bookDTO.Id;
            // обрабатываем AuthorBook
            DeleteUnnecessaryAuthorBook(bookId, selectedAuthorsId);
            AddAuthorBook(bookId, selectedAuthorsId);
            // обрабатываем BookCategory
            DeleteUnnecessaryBookCategory(bookId, selectedCategoriesId);
            AddBookCategory(bookId, selectedCategoriesId);
            // обрабатываем BookTag
            DeleteUnnecessaryBookTag(bookId, selectedTagsId);
            AddBookTag(bookId, selectedTagsId);            
            Book book = _libraryContext.Book_.Find(bookDTO.Id);
            book.ShelfId = shelfId;
            book.ReaderId = readerId;
            book.TakeDate = bookDTO.TakeDate;
            book.Title = bookDTO.Title;
            book.PhotoPath = bookDTO.PhotoPath;

            _libraryContext.Book_.Update(book);

            _libraryContext.SaveChanges();
        }

        public BookDTO GetByID(int id)
        {
            var bookL = _libraryContext.Book_.Include(b => b.ReaderObj).Include(b => b.ShelfObj).AsNoTracking().FirstOrDefault(b => b.Id == id);
            var bookDTO = _mapper.Map<BookDTO>(bookL);
            
            return (LoadAndAssignBooksEntities(bookDTO));
        }

        #region gettingEntities
        public IList<AuthorDTO> GetAllAuthors()
        {
            var author = _libraryContext.Author_.ToList();
            var authorDTOs = _mapper.Map<List<AuthorDTO>>(author);
            return (authorDTOs);
        }

        public IList<TagDTO> GetAllTags()
        {
            var tag = _libraryContext.Tag_.ToList();
            var tagDTOs = _mapper.Map<List<TagDTO>>(tag);
            return (tagDTOs);
        }

        public IList<CategoryDTO> GetAllCategories()
        {
            var category = _libraryContext.Category_.ToList();
            var categoryDTOs = _mapper.Map<List<CategoryDTO>>(category);
            return (categoryDTOs);
        }

        public IList<ShelfDTO> GetAllShelves()
        {
            var shelf = _libraryContext.Shelf_.ToList();
            var shelfDTOs = _mapper.Map<List<ShelfDTO>>(shelf);
            return (shelfDTOs);
        }

        public IList<ReaderDTO> GetAllReaders()
        {
            var reader = _libraryContext.Reader_.ToList();
            var readerDTOs = _mapper.Map<List<ReaderDTO>>(reader);
            return (readerDTOs);
        }
        
        //получение тэгов
        public IList<TagDTO> GetBooksTags(int bookId)
        {
            var bookTag = _libraryContext.Book_Tag_.Where(b => b.BookId == bookId).ToList();
            List<Tag> tagsList = new List<Tag>();
            foreach (var item in bookTag)
            {
                tagsList.Add(_libraryContext.Tag_.FirstOrDefault(b => b.Id == item.TagId));
            }
            return (_mapper.Map<List<TagDTO>>(tagsList));
        }

        //получение категорий
        public IList<CategoryDTO> GetBooksCategories(int bookId)
        {
            var bookCategory = _libraryContext.Book_Category_.Where(b => b.BookId == bookId).ToList();
            List<Category> categoriesList = new List<Category>();
            foreach (var item in bookCategory)
            {
                categoriesList.Add(_libraryContext.Category_.FirstOrDefault(b => b.Id == item.CategoryId));
            }
            return (_mapper.Map<List<CategoryDTO>>(categoriesList));
        }

        //получение авторов
        public IList<AuthorDTO> GetAuthorsBooks(int bookId)
        {
            var authorBook = _libraryContext.Author_Book_.Where(b => b.BookId == bookId).ToList();
            List<Author> authorsList = new List<Author>();
            foreach (var item in authorBook)
            {
                authorsList.Add(_libraryContext.Author_.FirstOrDefault(b => b.Id == item.AuthorId));
            }
            return (_mapper.Map<List<AuthorDTO>>(authorsList));
        }
        #endregion

        
        //подгрузка сущностей связанными с сущностью книги 
        public BookDTO LoadAndAssignBooksEntities (BookDTO bookDTO)
        {
            var tags = GetBooksTags(bookDTO.Id);
            var authors = GetAuthorsBooks(bookDTO.Id);
            var categories = GetBooksCategories(bookDTO.Id);
            bookDTO.TagDTOs = tags;
            bookDTO.CategoryDTOs = categories;
            bookDTO.AuthorDTOs = authors;
            return (bookDTO);
        }

        #region CreateEntites
        public AuthorBook CreateAuthorBookEntity(int bookId, int authorId)
        {
            AuthorBook authorBook = new AuthorBook {BookId = bookId, AuthorId = authorId};           
            return (authorBook);            
        }
        public BookTag CreateBookTagEntity(int bookId, int tagId)
        {
            BookTag bookTag = new BookTag { BookId = bookId, TagId = tagId };
            return (bookTag);
        }
        public BookCategory CreateBookCategoryEntity(int bookId, int categoryId)
        {
            BookCategory bookCategory = new BookCategory { BookId = bookId, CategoryId = categoryId };
            return (bookCategory);
        }
        #endregion

        #region AddEntitiesToDB
        public void AddAuthorBook(int bookId, int[] selectedAuthorsId)
        {
            var authorsIdList = _libraryContext.Author_Book_.Where(x => x.BookId == bookId).Select(x => x.AuthorId);
            foreach (var id in selectedAuthorsId)
            {
                if (!authorsIdList.Contains(id))
                {
                    var authorBook = CreateAuthorBookEntity(bookId, id);
                    _libraryContext.Author_Book_.Add(authorBook);
                }
            }
            _libraryContext.SaveChanges();
        }
        public void AddBookCategory(int bookId, int[] selectedCategoriesId)
        {
            var categoriesIdList = _libraryContext.Book_Category_.Where(x => x.BookId == bookId).Select(x => x.CategoryId);
            foreach (var id in selectedCategoriesId)
            {
                if (!categoriesIdList.Contains(id))
                {
                    var bookCategory = CreateBookCategoryEntity(bookId, id);
                    _libraryContext.Book_Category_.Add(bookCategory);
                }
            }
            _libraryContext.SaveChanges();
        }
        public void AddBookTag(int bookId, int[] selectedTagsId)
        {
            var tagsIdList = _libraryContext.Book_Tag_.Where(x => x.BookId == bookId).Select(x => x.TagId);
            foreach (var id in selectedTagsId)
            {
                if (!tagsIdList.Contains(id))
                {
                    var bookTag = CreateBookTagEntity(bookId, id);
                    _libraryContext.Book_Tag_.Add(bookTag);
                }
            }
            _libraryContext.SaveChanges();
        }
        #endregion

        #region DeleteUnnecessaryEntities
        public void DeleteUnnecessaryAuthorBook(int bookId, int[] selectedAuthorsId)
        {
            var authorBookListFromDB = _libraryContext.Author_Book_.Where(x => x.BookId == bookId).ToList();
            foreach (var item in authorBookListFromDB)
            {
                if (!selectedAuthorsId.Contains(item.AuthorId))
                    _libraryContext.Author_Book_.Remove(item);
            }
            _libraryContext.SaveChanges();
        }
        public void DeleteUnnecessaryBookCategory(int bookId, int[] selectedCategoriesId)
        {
            var bookCategoriesListFromDB = _libraryContext.Book_Category_.Where(x => x.BookId == bookId).ToList();
            foreach (var item in bookCategoriesListFromDB)
            {
                if (!selectedCategoriesId.Contains(item.CategoryId))
                    _libraryContext.Book_Category_.Remove(item);
            }
            _libraryContext.SaveChanges();
        }
        public void DeleteUnnecessaryBookTag(int bookId, int[] selectedTagsId)
        {
            var bookTagsListFromDB = _libraryContext.Book_Tag_.Where(x => x.BookId == bookId).ToList();
            foreach (var item in bookTagsListFromDB)
            {
                if (!selectedTagsId.Contains(item.TagId))
                    _libraryContext.Book_Tag_.Remove(item);
            }
            _libraryContext.SaveChanges();
        }

        #endregion

    }
}