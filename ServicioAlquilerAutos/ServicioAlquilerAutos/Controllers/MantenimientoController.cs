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
    public class MantenimientoController : ApiController
    {
        // GET api/<controller>
        public IQueryable Get()
        {
            clsMantenimiento mantenimineto = new clsMantenimiento();
            return mantenimineto.ListaMantenimientos();
        }

        // GET api/<controller>/5
        public Mantenimiento Get(int id)
        {
            clsMantenimiento mantenimineto = new clsMantenimiento();
            return mantenimineto.Consultar(id);
        }

        // POST api/<controller>
        public string Post([FromBody] Mantenimiento mantenimineto)
        {
            clsMantenimiento _mantenimineto = new clsMantenimiento();
            _mantenimineto.mantenimiento= mantenimineto;
            return _mantenimineto.Insertar();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] Mantenimiento mantenimineto)
        {
            clsMantenimiento _mantenimineto = new clsMantenimiento();
            _mantenimineto.mantenimiento = mantenimineto;
            return _mantenimineto.Actualizar();
        }

        // DELETE api/<controller>/5
        public string Delete(Mantenimiento mantenimineto)
        {
            clsMantenimiento _mantenimineto = new clsMantenimiento();
            _mantenimineto.mantenimiento = mantenimineto;
            return _mantenimineto.Eliminar();
        }
    }
}