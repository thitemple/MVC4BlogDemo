using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Blog.Models;

namespace Blog.Areas.api.Controllers
{
    public class ComentarioController : ApiController
    {
        private BlogContext db = new BlogContext();

        // GET api/Comentario
        public IEnumerable<Comentario> GetComentarios()
        {
            return db.Comentarios.AsEnumerable();
        }

        // GET api/Comentario/5
        public Comentario GetComentario(int id)
        {
            Comentario comentario = db.Comentarios.Find(id);
            if (comentario == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return comentario;
        }

        // PUT api/Comentario/5
        public HttpResponseMessage PutComentario(int id, Comentario comentario)
        {
            if (ModelState.IsValid && id == comentario.ComentarioId)
            {
                db.Entry(comentario).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Comentario
        public HttpResponseMessage PostComentario(ComentarioDTO comentario)
        {
            if (ModelState.IsValid)
            {
                var novoComentario = new Comentario { Texto = comentario.Texto, Post = db.Posts.Find(comentario.PostId) };
                db.Comentarios.Add(novoComentario);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, novoComentario);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = novoComentario.ComentarioId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Comentario/5
        public HttpResponseMessage DeleteComentario(int id)
        {
            Comentario comentario = db.Comentarios.Find(id);
            if (comentario == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Comentarios.Remove(comentario);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, comentario);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}