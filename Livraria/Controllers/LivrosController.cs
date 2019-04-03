using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Livraria;

namespace Livraria.Controllers
{
    public class LivrosController : Controller
    {
        private Model1 db = new Model1();

        // GET: Livros
        public ActionResult Index()
        {
            var Livros = db.Livros.Include(l => l.Editora).Include(l => l.Genero).Include(l => l.Idioma);
            Livros = Livros.OrderBy(l => l.NOME);
            return View(Livros.ToList());
        }

        // GET: Livros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.Livros.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }

        // GET: Livros/Create
        public ActionResult Create()
        {
            ViewBag.EDITORA_ID = new SelectList(db.Editoras, "ID", "NOME");
            ViewBag.GENERO_ID = new SelectList(db.Generos, "ID", "NOME");
            ViewBag.IDIOMA_ID = new SelectList(db.Idiomas, "ID", "NOME");
            return View();
        }

        // POST: Livros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOME,AUTOR,IDIOMA_ID,EDITORA_ID,EDICAO,GENERO_ID,DATA_PUBLICACAO,QUANTIDADE")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                livro.DATA_CADASTRO = DateTime.Now;
                db.Livros.Add(livro);
                db.SaveChanges();
                return RedirectToAction("Index", "Livros");
            }

            ViewBag.EDITORA_ID = new SelectList(db.Editoras, "ID", "NOME", livro.EDITORA_ID);
            ViewBag.GENERO_ID = new SelectList(db.Generos, "ID", "NOME", livro.GENERO_ID);
            ViewBag.IDIOMA_ID = new SelectList(db.Idiomas, "ID", "NOME", livro.IDIOMA_ID);
            return View(livro);
        }

        // GET: Livros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.Livros.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            ViewBag.EDITORA_ID = new SelectList(db.Editoras, "ID", "NOME", livro.EDITORA_ID);
            ViewBag.GENERO_ID = new SelectList(db.Generos, "ID", "NOME", livro.GENERO_ID);
            ViewBag.IDIOMA_ID = new SelectList(db.Idiomas, "ID", "NOME", livro.IDIOMA_ID);
            return View(livro);
        }

        // POST: Livros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOME,AUTOR,IDIOMA_ID,EDITORA_ID,EDICAO,GENERO_ID,DATA_PUBLICACAO,QUANTIDADE")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                livro.DATA_ALTERACAO = DateTime.Now;
                db.Entry(livro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EDITORA_ID = new SelectList(db.Editoras, "ID", "NOME", livro.EDITORA_ID);
            ViewBag.GENERO_ID = new SelectList(db.Generos, "ID", "NOME", livro.GENERO_ID);
            ViewBag.IDIOMA_ID = new SelectList(db.Idiomas, "ID", "NOME", livro.IDIOMA_ID);
            return View(livro);
        }

        // GET: Livros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.Livros.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livro livro = db.Livros.Find(id);
            db.Livros.Remove(livro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
