using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryASPNET_Core.Models
{
    public class Authors_Books
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public int Author_Id { get; set; }
        public int Book_Id { get; set; }

        public virtual ICollection<Authors> AuthorsObj { get; set; }
        public virtual ICollection<Books> BooksObj { get; set; }
    }
}
