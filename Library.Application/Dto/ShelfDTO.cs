using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Dto
{
    public class ShelfDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<BookDTO> BookObj { get; set; }
    }
}
