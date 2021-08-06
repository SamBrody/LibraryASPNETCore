using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Domain.Models
{
    public class AuthorBook
    {      
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int BookId { get; set; }

        public virtual Author AuthorsObj { get; set; }
        public virtual Book BooksObj { get; set; }
    }
}
