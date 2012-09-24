using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class ComentarioDTO
    {
        public string Texto { get; set; }
        public int PostId { get; set; }
    }
}