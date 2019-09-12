using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BDViajero.Modelo;

namespace WApiViajes.Controllers
{
    public class ViajerosController : ApiController
    {
        private ViajesEntities db = new ViajesEntities();

        // GET: api/Viajeros
        public IQueryable<Viajeros> GetViajeros()
        {
            return db.Viajeros;
        }

        // GET: api/Viajeros/5
        [ResponseType(typeof(Viajeros))]
        public IHttpActionResult GetViajeros(int id)
        {
            Viajeros viajeros = db.Viajeros.Find(id);
            if (viajeros == null)
            {
                return NotFound();
            }

            return Ok(viajeros);
        }

        // PUT: api/Viajeros/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutViajeros(int id, Viajeros viajeros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != viajeros.IdViajero)
            {
                return BadRequest();
            }

            db.Entry(viajeros).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViajerosExists(id))
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

        // POST: api/Viajeros
        [ResponseType(typeof(Viajeros))]
        public IHttpActionResult PostViajeros(Viajeros viajeros)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Viajeros.Add(viajeros);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = viajeros.IdViajero }, viajeros);
        }

        // DELETE: api/Viajeros/5
        [ResponseType(typeof(Viajeros))]
        public IHttpActionResult DeleteViajeros(int id)
        {
            Viajeros viajeros = db.Viajeros.Find(id);
            if (viajeros == null)
            {
                return NotFound();
            }

            db.Viajeros.Remove(viajeros);
            db.SaveChanges();

            return Ok(viajeros);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ViajerosExists(int id)
        {
            return db.Viajeros.Count(e => e.IdViajero == id) > 0;
        }
    }
}