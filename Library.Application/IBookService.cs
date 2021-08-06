using Library.Application.Dto;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Application
{
    public interface IBookService
    {
        IList<BookDTO> GetAll();

        void Create(Book book);

        void Update(Book book);

        void Delete(Book book);

        Book GetByID(int id);
    }
}
