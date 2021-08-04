using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Library.Domain.Models
{
    public class Author
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("ФИО")]
        public string Full_Name { get; set; }     
        [DataType(DataType.Date)]
        [DisplayName("Дата рождения")]
        public DateTime BirthDate { get; set; }
        public virtual ICollection<Author_Book> Author_BookObj { get; set; }
    }
}
