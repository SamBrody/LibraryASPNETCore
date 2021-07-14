﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryASPNET_Core.Models
{
    public class Books
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }        
    }
}
