using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_Ajmera.Models
{
    public partial class Author
    {
        [Key]
        public int Authorid { get; set; }

        [Required]
        public string AuthorName { get; set; } = null!;

        
    }
}
