using BDViajero.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace WebApiViajero.Controllers
{
    public class ViajeController : ApiController
    {
        ViajesEntities BD = new ViajesEntities();

        /// <summary>
        /// Consultar con una lista los viajeros
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Viajeros> GET()
        {
            var lista = BD.Viajeros.ToList();

            //IList<Viajeros> viajero = null;
            //using (var dt = new ViajesEntities())
            //{
            //    viajero = dt.Viajeros.Include("Viajero")
            //        .Select(x => new Viajeros()
            //        {
            //            IdViajero = x.IdViajero,
            //            Cedula = x.Cedula,
            //            Apellido = x.Apellido,
            //            Nombre = x.Nombre,
            //            Direccion = x.Direccion,
            //            Telefonos = x.Telefonos,
            //            CorreoE = x.CorreoE
            //        }).ToList<Viajeros>();
            //}

            //return viajero;

            return lista;
        }

        // Para buscar solo un registro
        [HttpGet]
        public Viajeros Get(int id)
        {
            using (ViajesEntities viajesEntities = new ViajesEntities())
            {
                return viajesEntities.Viajeros.FirstOrDefault(x => x.IdViajero == id);
            }
        }



        public IHttpActionResult GetViajeros()
        {
            IList<Viajeros> viajero = null;
            using (var dt = new ViajesEntities())
            {
                viajero = dt.Viajeros.Include("Viajero")
                    .Select(x => new Viajeros()
                    {
                        IdViajero = x.IdViajero,
                        Cedula = x.Cedula,
                        Apellido = x.Apellido,
                        Nombre = x.Nombre,
                        Direccion = x.Direccion,
                        Telefonos = x.Telefonos,
                        CorreoE = x.CorreoE
                    }).ToList<Viajeros>();
            }
            if (viajero.Count == 0)
                return NotFound();

            return Ok(viajero);
        }

    }
}
