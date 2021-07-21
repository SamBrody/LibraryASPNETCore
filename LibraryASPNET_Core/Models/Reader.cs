using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryASPNET_Core.Models
{
    public class Reader
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Patronymic { get; set; }
        public string Last_Name { get; set; }                
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
        public virtual ICollection<Books> BooksObj { get; set; }
    }
}
