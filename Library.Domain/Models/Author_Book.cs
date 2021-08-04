using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Models
{
    public class Author_Book
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Author_Id { get; set; }
        public int Book_Id { get; set; }

        public virtual Author AuthorsObj { get; set; }
        public virtual Book BooksObj { get; set; }
    }
}
