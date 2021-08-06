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
        public int Id { get; set; }        
        public string FullName { get; set; }             
        public DateTime BirthDate { get; set; }

        public virtual ICollection<AuthorBook> AuthorBookObj { get; set; }
    }
}
