using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.DTO
{
    public class Author_BookDTO
    {
        public int Id { get; set; }
        public int Author_Id { get; set; }
        public int Book_Id { get; set; }
        public AuthorDTO AuthorObj { get; set; }
        public BookDTO BookObj{ get; set; }
    }
}
