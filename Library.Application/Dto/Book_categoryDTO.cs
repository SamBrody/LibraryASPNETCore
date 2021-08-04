using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.DTO
{
    public class Book_categoryDTO
    {
        public int Id { get; set; }
        public int Book_Id { get; set; }
        public int Category_Id { get; set; }

        public BookDTO BookObj { get; set; }
        public CategoryDTO CategoryObj { get; set; }
    }
}
