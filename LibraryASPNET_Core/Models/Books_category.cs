using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryASPNET_Core.Models
{
    public class Books_category
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Book_Id { get; set; }
        public int Category_Id { get; set; }

        public virtual Books BooksObj { get; set; }
        public virtual Category CategoriesObj { get; set; }        
    }
}
