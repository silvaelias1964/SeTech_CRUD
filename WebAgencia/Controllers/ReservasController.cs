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
    public class ReservasController : Controller
    {
        private ViajesEntities db = new ViajesEntities();

        // GET: Reservas
        public ActionResult Index()
        {
            var reservas = db.Reservas.Include(r => r.Destinos).Include(r => r.Viajeros);
            return View(reservas.ToList());
        }

        // GET: Reservas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservas reservas = db.Reservas.Find(id);
            if (reservas == null)
            {
                return HttpNotFound();
            }

            //var reservamd = new ReservaModel()
            //{
            //    IdReserva=reservas.IdReserva,
            //    IdViajero=reservas.IdViajero,
            //    IdDestino=reservas.IdDestino,
            //    FechaReserva=reservas.FechaReserva,
            //    LugarOrigen=reservas.LugarOrigen,
            //    PlazasReserva=reservas.PlazasReserva
            //};


            var viajero = db.Viajeros.Single(x => x.IdViajero == reservas.IdViajero);
            var destino = db.Destinos.Single(x => x.IdDestino == reservas.IdDestino);

            ViewBag.NomViajero = viajero.Cedula + " - " + viajero.Apellido + ", " + viajero.Nombre;
            ViewBag.NomDestino = destino.Destino;

            return View(reservas);
        }

        // GET: Reservas/Create
        public ActionResult Create()
        {
            ViewBag.IdDestino = new SelectList(db.Destinos, "IdDestino", "Destino");
            ViewBag.IdViajero = new SelectList(db.Viajeros, "IdViajero", "Cedula");
            ViewBag.plazas = 0;

            return View();
        }

        // POST: Reservas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdReserva,IdViajero,IdDestino,PlazasReserva,LugarOrigen,FechaReserva")] Reservas reservas)
        {
            if (ModelState.IsValid)
            {
                db.Reservas.Add(reservas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDestino = new SelectList(db.Destinos, "IdDestino", "Destino", reservas.IdDestino);
            ViewBag.IdViajero = new SelectList(db.Viajeros, "IdViajero", "Cedula", reservas.IdViajero);

            var destino = db.Destinos.Single(x => x.IdDestino == reservas.IdDestino);
            ViewBag.plazas = destino.Plazas;

            return View(reservas);
        }

        // GET: Reservas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservas reservas = db.Reservas.Find(id);
            if (reservas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDestino = new SelectList(db.Destinos, "IdDestino", "Destino", reservas.IdDestino);
            ViewBag.IdViajero = new SelectList(db.Viajeros, "IdViajero", "Cedula", reservas.IdViajero);
            return View(reservas);
        }

        // POST: Reservas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdReserva,IdViajero,IdDestino,PlazasReserva,LugarOrigen,FechaReserva")] Reservas reservas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDestino = new SelectList(db.Destinos, "IdDestino", "Destino", reservas.IdDestino);
            ViewBag.IdViajero = new SelectList(db.Viajeros, "IdViajero", "Cedula", reservas.IdViajero);
            return View(reservas);
        }

        // GET: Reservas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservas reservas = db.Reservas.Find(id);
            if (reservas == null)
            {
                return HttpNotFound();
            }

            var viajero = db.Viajeros.Single(x => x.IdViajero == reservas.IdViajero);
            var destino = db.Destinos.Single(x => x.IdDestino == reservas.IdDestino);

            ViewBag.NomViajero = viajero.Cedula + " - " + viajero.Apellido + ", " + viajero.Nombre;
            ViewBag.NomDestino = destino.Destino;

            return View(reservas);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservas reservas = db.Reservas.Find(id);
            db.Reservas.Remove(reservas);
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
