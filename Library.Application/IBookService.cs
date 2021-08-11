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

        void Create(BookDTO bookDTO);

        void Update(BookDTO bookDTO);

        void Delete(int id);

        BookDTO GetByID(int id);
    }
}
