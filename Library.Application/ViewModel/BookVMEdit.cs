using Library.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.ViewModel
{
    public class BookVMEdit
    {
        public IEnumerable<BookDTO> Books { get; set; }
        public IEnumerable<ShelfDTO> Shelves { get; set; }
        public IEnumerable<ReaderDTO> Readers { get; set; }
        public IEnumerable<TagDTO> Tags { get; set; }
    }
}
