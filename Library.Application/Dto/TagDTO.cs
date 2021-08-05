using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Dto
{
    public class TagDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Book_tagDTO> Book_TagObj { get; set; }
    }
}
