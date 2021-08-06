using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Library.Domain.Models
{
    public class Category
    {        
        public int Id { get; set; }        
        public string Name { get; set; }
        public virtual ICollection<BookCategory> BookCategoryObj { get; set; }
    }
}
