﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryASPNET_Core.Models
{
    public class Tags
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Books_tags> Books_TagObj { get; set; }
    }
}
