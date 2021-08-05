using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Dto
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Book_categoryDTO> Book_CategoryObj { get; set; }
    }
}
