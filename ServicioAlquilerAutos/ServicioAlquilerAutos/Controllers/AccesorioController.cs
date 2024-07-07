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
    public class AccesorioController : ApiController
    {
        // GET api/<controller>
        public List<Accesorio> Get()
        {
            clsAccesorios accesorio = new clsAccesorios();
            return accesorio.ListaAccesorios();
        }

        // GET api/<controller>/5
        public Accesorio Get(int id)
        {
            clsAccesorios accesorio = new clsAccesorios();
            return accesorio.Consultar(id);
        }

        // POST api/<controller>
        public string Post([FromBody] Accesorio accesorio)
        {
            clsAccesorios _accesorio = new clsAccesorios();
            _accesorio.accesorio = accesorio;
            return _accesorio.Insertar();
        }


        // PUT api/<controller>/5
        public string Put([FromBody] Accesorio accesorio)
        {
            clsAccesorios _accesorio = new clsAccesorios();
            _accesorio.accesorio = accesorio;
             return _accesorio.Actualizar();
        }

        // DELETE api/<controller>/5
        public string Delete(Accesorio accesorio)
        {
            clsAccesorios _accesorio = new clsAccesorios();
            _accesorio.accesorio = accesorio;
             return _accesorio.Eliminar();
        }
    }
}