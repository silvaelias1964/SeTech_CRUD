using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BDViajero.Modelo;
using WebAgencia.Models;

namespace WebAgencia.Controllers
{
    public class DestinosController : Controller
    {
        private ViajesEntities db = new ViajesEntities();

        // GET: Destinos
        public ActionResult Index()
        {
            return View(db.Destinos.ToList());
        }

        // GET: Destinos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destinos destinos = db.Destinos.Find(id);
            if (destinos == null)
            {
                return HttpNotFound();
            }
            return View(destinos);
        }

        // GET: Destinos/Create
        public ActionResult Create()
        {
            Destinos destino = new Destinos();
            var destinomd = new DestinoModel()
            {
                IdDestino = destino.IdDestino,
                Destino = destino.Destino,
                Precio = destino.Precio,
                Plazas = destino.Plazas
            };

            return View(destinomd);
        }

        // POST: Destinos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDestino,Destino,Precio,Plazas")] DestinoModel destinomd)
        {
            if (ModelState.IsValid)
            {
                var destino = new Destinos()
                {
                    Destino = destinomd.Destino,
                    Precio = destinomd.Precio,
                    Plazas = destinomd.Plazas
                };

                db.Destinos.Add(destino);
                db.SaveChanges();                
                return RedirectToAction("Index");
            }
            return View(destinomd);
        }

        // GET: Destinos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destinos destinos = db.Destinos.Find(id);
            if (destinos == null)
            {
                return HttpNotFound();
            }
            var destinomd = new DestinoModel()
            {
                IdDestino = destinos.IdDestino,
                Destino = destinos.Destino,
                Precio = destinos.Precio,
                Plazas = destinos.Plazas
            };
            return View(destinomd);
        }

        // POST: Destinos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDestino,Destino,Precio,Plazas")] int? id, DestinoModel destinomd)
        {
            Destinos destino = db.Destinos.Find(id);
            if (ModelState.IsValid)
            {
                destino.Destino = destinomd.Destino;
                destino.Precio = destinomd.Precio;
                destino.Plazas = destinomd.Plazas;

                db.Entry(destino).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(destinomd);
        }

        // GET: Destinos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destinos destinos = db.Destinos.Find(id);
            if (destinos == null)
            {
                return HttpNotFound();
            }
            var destinomd = new DestinoModel()
            {
                IdDestino = destinos.IdDestino,
                Destino = destinos.Destino,
                Precio = destinos.Precio,
                Plazas = destinos.Plazas
            };

            return View(destinomd);
        }

        // POST: Destinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Destinos destinos = db.Destinos.Find(id);
            db.Destinos.Remove(destinos);
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
