﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryASPNET_Core.Models
{
    public class Books_tags
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public int Tag_id { get; set; }
        public int Book_id { get; set; }

        public virtual ICollection<Tags> TagsObj { get; set; }
        public virtual ICollection<Books> BooksObj { get; set; }
    }
}