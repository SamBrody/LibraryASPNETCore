using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.DTO
{
    public class ShelfDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<BookDTO> BookObj { get; set; }
    }
}
