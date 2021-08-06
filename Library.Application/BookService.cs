using AutoMapper;
using Library.Application.Dto;
using Library.Domain.Models;
using Library.Infrasturcture.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public void Create(Book book)
        {            
            _libraryContext.Add(book);
        }

        public void Delete(Book book)
        {
            _libraryContext.Remove(book);
        }

        public IList<BookDTO> GetAll()
        {
            var book = _libraryContext.Book_.Include(b=>b.ReaderObj).Include(b=>b.ShelfObj).ToList();
            var bookDTOs = _mapper.Map<List<BookDTO>>(book);
            return (bookDTOs);
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
