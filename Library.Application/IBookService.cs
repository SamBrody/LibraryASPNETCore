using Library.Application.Dto;
using Library.Application.ViewModels;
using Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Application
{
    public interface IBookService
    {
        IList<BookDTO> GetAllBooks();

        void Create(BookDTO bookDTO);

        void Update(BookEditVM bookVM);

        void Delete(int id);

        BookDTO GetByID(int id);

        IList<AuthorDTO> GetAllAuthors();

        IList<TagDTO> GetAllTags();

        IList<CategoryDTO> GetAllCategories();

        IList<ShelfDTO> GetAllShelves();

        IList<ReaderDTO> GetAllReaders();
    }
}
