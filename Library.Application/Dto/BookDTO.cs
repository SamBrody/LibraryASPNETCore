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
        [DisplayName("Название книги")]
        [Required]
        public string Title { get; set; }
        [DisplayName("Обложка")]
        [Required]
        public string PhotoPath { get; set; }
        [DisplayName("Дата взятия")]
        [DataType(DataType.Date)]
        public DateTime? TakeDate { get; set; }

        public int ShelfId { get; set; }
        public int? ReaderId { get; set; }
        [DisplayName("Полка")]
        [Required]
        public string ShelfName { get; set; }
        //public ShelfDTO ShelfDTOObj { get; set; }     
        [DisplayName("Читатель")]
        public string ReaderName { get; set; }
        [DisplayName("Автор(ы)")]
        [Required]
        public IList<AuthorDTO> AuthorDTOs { get; set; }
        [DisplayName("Категории")]
        public IList<CategoryDTO> CategoryDTOs { get; set; }
        [DisplayName("Теги")]
        public IList<TagDTO> TagDTOs { get; set; }
        //public ReaderDTO ReaderDTOObj { get; set; }
    }
}
