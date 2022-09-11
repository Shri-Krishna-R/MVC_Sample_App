using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_Ajmera.Models
{
    public partial class Book
    {
        [Key]
        public int Bookid { get; set; }
        [Required]
        public string Booktitle { get; set; } = null!;
        [Required]
        public string Author { get; set; } = null!;
        [Required]
        public int AuthorId { get; set; }
    }
}
