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
        IList<BookDTO> GetAllBooks();

        void AddBook(BookDTO bookDTO, int[] selectedAuthorsId, int[] selectedCategoriesId, int[] selectedTagsId, int shelfId, int? readerId);

        void Update(BookDTO bookDTO, int[] selectedAuthorsId, int[] selectedCategoriesId, int[] selectedTagsId, int shelfId, int? readerId);

        void Delete(int id);

        BookDTO GetByID(int id);

        IList<AuthorDTO> GetAllAuthors();

        IList<TagDTO> GetAllTags();

        IList<CategoryDTO> GetAllCategories();

        IList<ShelfDTO> GetAllShelves();

        IList<ReaderDTO> GetAllReaders();
    }
}