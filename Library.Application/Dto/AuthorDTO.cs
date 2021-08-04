using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.DTO
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string Full_Name { get; set; }
        public DateTime BirthDate { get; set; }
        public  IList<Author_BookDTO> Author_BookObj { get; set; }
    }
}
