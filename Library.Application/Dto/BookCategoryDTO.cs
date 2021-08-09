using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Application.Dto
{
    public class BookCategoryDTO
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BookId { get; set; }
        public int CategoryId { get; set; }
        public string BookTitle { get; set; }
        public string CategoryName { get; set; }
        //public BookDTO BookDTOObj { get; set; }
        //public CategoryDTO CategoryDTOObj { get; set; }
    }
}
