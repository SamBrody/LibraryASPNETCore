﻿using AutoMapper;
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

        public void Create(BookDTO bookDTO)
        {            
            _libraryContext.Add(bookDTO);
        }

        public void Delete(BookDTO bookDTO)
        {
            _libraryContext.Remove(bookDTO);
        }

        public IList<BookDTO> GetAll()
        {
            var book = _libraryContext.Book_.Include(b=>b.ReaderObj).Include(b=>b.ShelfObj).ToList();
            var bookDTOs = _mapper.Map<List<BookDTO>>(book);
            return (bookDTOs);
        }

        public void Update(BookDTO bookDTO)
        {
            throw new NotImplementedException();
        }

        public BookDTO GetByID(int id)
        {
            var bookL = _libraryContext.Book_.Include(b => b.ReaderObj).Include(b => b.ShelfObj).ToList();
            var bookDTOs = _mapper.Map<List<BookDTO>>(bookL);
            BookDTO book = new BookDTO();
            foreach (var item in bookDTOs)
            {
                if (item.Id==id)
                {
                    book= item;
                }
            }
            return (book);
        }        
    }
}
