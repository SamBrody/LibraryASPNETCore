using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Dto
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PhotoPath { get; set; }
        public DateTime TakeDate { get; set; }
        public IList<Author_BookDTO> Author_BookObj { get; set; }
        public IList<Book_categoryDTO> Book_CategoryObj { get; set; }
        public IList<Book_tagDTO> Book_TagObj { get; set; }
        public int Shelf_Id { get; set; }
        public virtual ShelfDTO ShelfObj { get; set; }
        public int Reader_Id { get; set; }
        public virtual ReaderDTO ReaderObj { get; set; }
    }
}
