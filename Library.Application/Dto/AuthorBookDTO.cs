using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Library.Application.Dto
{
    public class AuthorBookDTO
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int BookId { get; set; }  

        public AuthorDTO AuthorsDTOObj { get; set; }
        public BookDTO BooksDTOObj { get; set; }
    }
}
