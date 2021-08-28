using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Library.Domain.Models
{
    public class Book
    {
        public int Id { get; set; }       
        public string Title { get; set; }        
        public string PhotoPath { get; set; }        
        public DateTime? TakeDate { get; set; }
        public virtual ICollection<AuthorBook> AuthorBookObj { get; set; }
        public virtual ICollection<BookCategory> BookCategoryObj { get; set; }
        public virtual ICollection<BookTag> BookTagObj { get; set; }
        public int ShelfId { get; set; }        
        public virtual Shelf ShelfObj { get; set; }
        public int? ReaderId { get; set; }        
        public virtual Reader ReaderObj { get; set; }        
    }
}

