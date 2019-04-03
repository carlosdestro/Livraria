using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Livraria;

namespace Livraria.Controllers
{
    public class LivrariaApiController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/LivrariaApi
      public IHttpActionResult GetLivros()
        {
            var Livros = db.Livros;

            var livrosJSON = Livros.Select(e => new
            {
                e.NOME,
                e.EDICAO,
                e.QUANTIDADE,
                e.DATA_PUBLICACAO,
                e.AUTOR
            });

            //var Livros = db.Livros.Include(l => l.Editora).Include(l => l.Genero).Include(l => l.Idioma);
            //Livros = Livros.OrderBy(l => l.NOME);

            return Ok(new { livros = livrosJSON });
        }

        // GET: api/LivrariaApi/5
        [ResponseType(typeof(Livro))]
        public async Task<IHttpActionResult> GetLivro(int id)
        {
            Livro livro = await db.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }

            return Ok(livro);
        }

        // PUT: api/LivrariaApi/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLivro(int id, Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != livro.ID)
            {
                return BadRequest();
            }

            db.Entry(livro).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/LivrariaApi
        [ResponseType(typeof(Livro))]
        public async Task<IHttpActionResult> PostLivro(Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Livros.Add(livro);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = livro.ID }, livro);
        }

        // DELETE: api/LivrariaApi/5
        [ResponseType(typeof(Livro))]
        public async Task<IHttpActionResult> DeleteLivro(int id)
        {
            Livro livro = await db.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }

            db.Livros.Remove(livro);
            await db.SaveChangesAsync();

            return Ok(livro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LivroExists(int id)
        {
            return db.Livros.Count(e => e.ID == id) > 0;
        }
    }
}