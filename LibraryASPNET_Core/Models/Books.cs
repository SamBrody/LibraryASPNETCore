using System;
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
        public string PhotoPath { get; set; }
        [DataType(DataType.Date)]
        public DateTime TakeDate { get; set; }
        public virtual ICollection<Books_category> Books_CategoriesObj { get; set; }
        public virtual ICollection<Books_tags> Books_TagObj { get; set; }
        public int Shelf_id { get; set; }
        public virtual Shelves ShelfObj { get; set; }
        public int Reader_id { get; set; }
        public virtual Reader ReaderObj { get; set; }
        public virtual ICollection<Authors_Books> Author_BooksObj { get; set; }
    }
}
