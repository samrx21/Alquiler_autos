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
    public class SeguroController : ApiController
    {
        // GET api/<controller>
        public List<Seguro> Get()
        {
            clsSeguro seguro = new clsSeguro(); 
            return seguro.ListaSeguros();
        }

        // GET api/<controller>/5
        public Seguro Get(int id)
        {
            clsSeguro _seguro = new clsSeguro();
            return _seguro.Consultar(id);
        }

        // POST api/<controller>
        public string Post([FromBody] Seguro seguro)
        {
            clsSeguro _seguro = new clsSeguro();
            _seguro.seguro = seguro;
            return _seguro.Insertar();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] Seguro seguro)
        {
            clsSeguro _seguro = new clsSeguro();
            _seguro.seguro = seguro;
            return _seguro.Actualizar();
        }

        // DELETE api/<controller>/5
        public string Delete(Seguro seguro)
        {
            clsSeguro _seguro = new clsSeguro();
            _seguro.seguro = seguro;
            return _seguro.Eliminar();
        }
    }
}