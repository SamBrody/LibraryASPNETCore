using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Dto
{
    public class ReaderDTO
    {
        public int Id { get; set; }
        public string Full_Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public virtual ICollection<BookDTO> BookObj { get; set; }
    }
}
