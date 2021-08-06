using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Library.Application.Dto
{
    public class BookDTO
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

        public int ShelfId { get; set; }
        public int ReaderId { get; set; }
        [DisplayName("Полка")]
        public virtual ShelfDTO ShelfDTOObj { get; set; }
        //public string ShelfName { get; set; }        
        [DisplayName("Читатель")]
        public ReaderDTO ReaderDTOObj { get; set; }
    }
}
