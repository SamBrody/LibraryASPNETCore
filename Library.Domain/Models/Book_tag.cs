using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Models
{
    public class Book_tag
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Book_Id { get; set; }
        public int Tag_Id { get; set; }

        public virtual Book BookObj { get; set; }
        public virtual Tag TagObj { get; set; }        
    }
}
