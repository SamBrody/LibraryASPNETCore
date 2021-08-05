using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Dto
{
    public class Book_tagDTO
    {
        public int Id { get; set; }
        public int Book_Id { get; set; }
        public int Tag_Id { get; set; }

        public BookDTO BookObj { get; set; }
        public TagDTO TagObj { get; set; }
    }
}
