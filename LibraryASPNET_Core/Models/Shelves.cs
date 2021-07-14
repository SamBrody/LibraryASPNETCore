using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryASPNET_Core.Models
{
    public class Shelves
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Name_Shelf { get; set; }
        public int Book_id { get; set; }
        public ICollection<Books> Books { get; set; }
    }
}
