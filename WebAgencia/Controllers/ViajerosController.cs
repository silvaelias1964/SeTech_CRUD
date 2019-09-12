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
    public class ViajerosController : Controller
    {
        private ViajesEntities db = new ViajesEntities();

        // GET: Viajeros
        public ActionResult Index()
        {
            return View(db.Viajeros.ToList());
        }

        // GET: Viajeros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viajeros viajeros = db.Viajeros.Find(id);
            if (viajeros == null)
            {
                return HttpNotFound();
            }

            var viajeromd = new ViajeroModel()
            {
                IdViajero = viajeros.IdViajero,
                Cedula = viajeros.Cedula,
                Nombre = viajeros.Nombre,
                Apellido = viajeros.Apellido,
                Direccion = viajeros.Direccion,
                CorreoE = viajeros.CorreoE,
                Telefonos = viajeros.Telefonos
            };

            return View(viajeromd);
        }

        // GET: Viajeros/Create
        public ActionResult Create()
        {
            Viajeros viajero = new Viajeros();
            var viajeromd = new ViajeroModel()
            {
                IdViajero=viajero.IdViajero,
                Cedula=viajero.Cedula,
                Nombre=viajero.Nombre,
                Apellido=viajero.Apellido,
                Direccion=viajero.Direccion,
                CorreoE=viajero.CorreoE,
                Telefonos=viajero.Telefonos
            };

            return View(viajeromd);
        }

        // POST: Viajeros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdViajero,Cedula,Nombre,Apellido,Direccion,Telefonos,CorreoE")] ViajeroModel viajeromd)
        {
            if (ModelState.IsValid)
            {
                var viajero = new Viajeros()
                {
                    Cedula=viajeromd.Cedula,
                    Nombre=viajeromd.Nombre,
                    Apellido=viajeromd.Apellido,
                    Direccion=viajeromd.Direccion,
                    Telefonos=viajeromd.Telefonos,
                    CorreoE=viajeromd.CorreoE
                };
                db.Viajeros.Add(viajero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viajeromd);
        }

        // GET: Viajeros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viajeros viajeros = db.Viajeros.Find(id);
            if (viajeros == null)
            {
                return HttpNotFound();
            }

            var viajeromd = new ViajeroModel()
            {
                IdViajero = viajeros.IdViajero,
                Cedula = viajeros.Cedula,
                Nombre = viajeros.Nombre,
                Apellido = viajeros.Apellido,
                Direccion = viajeros.Direccion,
                CorreoE = viajeros.CorreoE,
                Telefonos = viajeros.Telefonos
            };

            return View(viajeromd);
        }

        // POST: Viajeros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdViajero,Cedula,Nombre,Apellido,Direccion,Telefonos,CorreoE")] int? id,  ViajeroModel viajeromd)
        {
            Viajeros viajero = db.Viajeros.Find(id);
            if (ModelState.IsValid)
            {
                viajero.Cedula = viajeromd.Cedula;
                viajero.Nombre = viajeromd.Nombre;
                viajero.Apellido = viajeromd.Apellido;
                viajero.Direccion = viajeromd.Direccion;
                viajero.Telefonos = viajeromd.Telefonos;
                viajero.CorreoE = viajeromd.CorreoE;

                db.Entry(viajero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viajeromd);
        }

        // GET: Viajeros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viajeros viajeros = db.Viajeros.Find(id);
            if (viajeros == null)
            {
                return HttpNotFound();
            }
            var viajeromd = new ViajeroModel()
            {
                IdViajero = viajeros.IdViajero,
                Cedula = viajeros.Cedula,
                Nombre = viajeros.Nombre,
                Apellido = viajeros.Apellido,
                Direccion = viajeros.Direccion,
                CorreoE = viajeros.CorreoE,
                Telefonos = viajeros.Telefonos
            };

            return View(viajeromd);
        }

        // POST: Viajeros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Viajeros viajeros = db.Viajeros.Find(id);
            db.Viajeros.Remove(viajeros);
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
