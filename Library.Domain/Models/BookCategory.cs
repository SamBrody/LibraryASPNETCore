using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Models
{
    public class BookCategory
    {        
        public int Id { get; set; }
        public int BookId { get; set; }
        public int CategoryId { get; set; }

        public virtual Book BookObj { get; set; }
        public virtual Category CategoryObj { get; set; }        
    }
}
