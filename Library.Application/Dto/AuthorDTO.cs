using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Library.Application.Dto
{
    public class AuthorDTO
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Автор")]
        public string FullName { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Дата рождения")]
        public DateTime BirthDate { get; set; }

        //public ICollection<AuthorBookDTO> AuthorBookDTOObj { get; set; }
    }
}
