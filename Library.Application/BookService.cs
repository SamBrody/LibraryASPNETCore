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

        public void Create(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            _libraryContext.Add(book);
            _libraryContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _mapper.Map<Book>(GetByID(id));
            _libraryContext.Remove(book);
            _libraryContext.SaveChanges();
        }

        public IList<BookDTO> GetAllBooks()
        {
            var book = _libraryContext.Book_.Include(b => b.ReaderObj).Include(b => b.ShelfObj).ToList();
            var bookDTOs = _mapper.Map<List<BookDTO>>(book);
            foreach (var b in bookDTOs)
            {
                var tags = GetBooksTags(b.Id);
                var authors = GetAuthorsBooks(b.Id);
                var categories = GetBooksCategories(b.Id);
                b.TagDTOs = tags;
                b.CategoryDTOs = categories;
                b.AuthorDTOs = authors;
            }
            return (bookDTOs);
        }

        public void Update(BookDTO bookDTO)
        {
            //var book = _mapper.Map<Book>(bookDTO);
            //_libraryContext.Book_.Update(book);
            _libraryContext.SaveChanges();
        }

        public BookDTO GetByID(int id)
        {
            var bookL = _libraryContext.Book_.Include(b => b.ReaderObj).Include(b => b.ShelfObj).AsNoTracking().FirstOrDefault(b => b.Id == id);
            var bookDTO = _mapper.Map<BookDTO>(bookL);
            var tags = GetBooksTags(id);
            var authors = GetAuthorsBooks(id);
            var categories = GetBooksCategories(id);
            bookDTO.TagDTOs = tags;
            bookDTO.CategoryDTOs = categories;
            bookDTO.AuthorDTOs = authors;
            return (bookDTO);
        }

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
    }
}