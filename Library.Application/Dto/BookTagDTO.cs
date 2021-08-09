using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Application.Dto
{
    public class BookTagDTO
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int BookId { get; set; }
        public int TagId { get; set; }
        public string BookTitle { get; set; }
        public string TagName { get; set; }
        //public BookDTO BookDTOObj { get; set; }
        //public TagDTO TagDTOObj { get; set; }
    }
}
