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
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Название")]
        public string Title { get; set; }
        [DisplayName("Обложка")]
        public string PhotoPath { get; set; }
        [DisplayName("Дата взятия")]
        [DataType(DataType.Date)]
        public DateTime TakeDate { get; set; }
        public virtual ICollection<Author_Book> Author_BookObj { get; set; }
        public virtual ICollection<Book_category> Book_CategoryObj { get; set; }
        public virtual ICollection<Book_tag> Book_TagObj { get; set; }
        public int Shelf_Id { get; set; }
        [DisplayName("Полка")]
        public virtual Shelf ShelfObj { get; set; }
        public int Reader_Id { get; set; }
        [DisplayName("Читатель")]
        public virtual Reader ReaderObj { get; set; }
        
    }
}

