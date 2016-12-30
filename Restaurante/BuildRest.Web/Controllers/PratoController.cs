using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BuildRest.Modelo;
using BuildRest.Entity;

namespace BuildRest.Web.Controllers
{
    public class PratoController : Controller
    {
        private BuildRestContexto db = new BuildRestContexto();

        // GET: /Prato/
        public ActionResult Index()
        {
            var pratos = db.Pratos.Include(p => p.Restaurante);
            return View(pratos.ToList());
        }

        // GET: /Prato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = db.Pratos.Find(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            return View(prato);
        }

        // GET: /Prato/Create
        public ActionResult Create()
        {
            ViewBag.RestauranteId = new SelectList(db.Empresas, "RestauranteId", "RestauranteNome");
            return View();
        }

        // POST: /Prato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="PratoId,PratoNome,RestauranteId")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                db.Pratos.Add(prato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RestauranteId = new SelectList(db.Empresas, "RestauranteId", "RestauranteNome", prato.RestauranteId);
            return View(prato);
        }

        // GET: /Prato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = db.Pratos.Find(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestauranteId = new SelectList(db.Empresas, "RestauranteId", "RestauranteNome", prato.RestauranteId);
            return View(prato);
        }

        // POST: /Prato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="PratoId,PratoNome,RestauranteId")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RestauranteId = new SelectList(db.Empresas, "RestauranteId", "RestauranteNome", prato.RestauranteId);
            return View(prato);
        }

        // GET: /Prato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = db.Pratos.Find(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            return View(prato);
        }

        // POST: /Prato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prato prato = db.Pratos.Find(id);
            db.Pratos.Remove(prato);
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
