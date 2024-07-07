using ServicioAlquilerAutos.Clases;
using ServicioAlquilerAutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ServicioAlquilerAutos.Controllers
{
    [EnableCors(origins: "http://localhost:51464", headers: "*", methods: "*")]
    public class UbicacionController : ApiController
    {
        // GET api/<controller>
        public List<Ubicacione> Get()
        {
            clsUbicaciones ubicacion = new clsUbicaciones();
            return ubicacion.ListaUbicaciones();
        }

        // GET api/<controller>/5
        public Ubicacione Get(int id)
        {
            clsUbicaciones _ubicacion = new clsUbicaciones();
            return _ubicacion.Consultar(id);
        }

        // POST api/<controller>
        public string Post([FromBody] Ubicacione ubicacion)
        {
            clsUbicaciones _ubicacion = new clsUbicaciones();
            _ubicacion.ubicacion = ubicacion;
            return _ubicacion.Insertar();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] Ubicacione ubicacion)
        {
            clsUbicaciones _ubicacion = new clsUbicaciones();
            _ubicacion.ubicacion = ubicacion;
            return _ubicacion.Actualizar();
        }

        // DELETE api/<controller>/5
        public string Delete(Ubicacione ubicacion)
        {
            clsUbicaciones _ubicacion = new clsUbicaciones();
            _ubicacion.ubicacion = ubicacion;
            return _ubicacion.Eliminar();
        }
    }
}