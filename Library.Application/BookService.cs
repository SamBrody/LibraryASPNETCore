using Library.Domain.Models;
using Library.Infrasturcture.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Application
{
    public class BookService : IBookService
    {
        private readonly LibraryContext _libraryContext;

        public BookService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public void Create(Book book)
        {         
            _libraryContext.Add(book);
        }

        public void Delete(Book book)
        {
            _libraryContext.Remove(book);
        }

        public IList<Book> GetAll()
        {
            return (_libraryContext.Book_.ToList());
        }

        public void Update(Book book)
        {
            throw new NotImplementedException();
        }

        public Book GetByID(int id)
        {
            return (_libraryContext.Book_.Find(id));
        }
    }
}
