using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryASPNET_Core.Models
{
    public class Category
    {
        [Required]
        public int Id { get; set; }
        public string Name_Category { get; set; }
    }
}
