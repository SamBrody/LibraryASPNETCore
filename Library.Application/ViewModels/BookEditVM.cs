using Library.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.ViewModels
{
    public class BookEditVM
    {
        public BookDTO book { get; set; }
        public IEnumerable<AuthorDTO> authors { get; set; }
        public IEnumerable<TagDTO> tags { get; set; }
        public IEnumerable<CategoryDTO> categories { get; set; }
        public IList<ShelfDTO> shelves { get; set; }
        public IList<ReaderDTO> readers { get; set; }
    }
}
