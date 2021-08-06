using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Models
{
    public class BookTag
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int TagId { get; set; }

        public virtual Book BookObj { get; set; }
        public virtual Tag TagObj { get; set; }        
    }
}
