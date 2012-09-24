using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Comentario
    {
        public int ComentarioId { get; set; }
        public string Texto { get; set; }
        public Post Post { get; set; }
    }
}