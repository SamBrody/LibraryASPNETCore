using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Library.Application.Dto
{
    public class CategoryDTO
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }

       // public ICollection<BookCategoryDTO> BookCategoryDTOObj { get; set; }
    }
}
