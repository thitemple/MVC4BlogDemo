using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Post
    {
        public int PostId { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Corpo { get; set; }
        public List<Comentario> Comentarios { get; set; }
    }
}