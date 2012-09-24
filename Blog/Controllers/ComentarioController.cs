using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Controllers
{
    public class ComentarioController : Controller
    {
        private BlogContext db = new BlogContext();

        //
        // GET: /Comentario/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Comentario/Create

        [HttpPost]
        public ActionResult Create(ComentarioDTO comentario)
        {
            if (ModelState.IsValid)
            {
                var novoNovocomentario = new Comentario { Texto = comentario.Texto, 
                Post = db.Posts.Find(comentario.PostId)};
                db.Comentarios.Add(novoNovocomentario);
                db.SaveChanges();
                return RedirectToAction("Details", "Post", new { id = comentario.PostId });
            }

            return View(comentario);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}