using Microsoft.Ajax.Utilities;
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
    public class EmpleadoController : ApiController
    {
        // GET api/<controller>
        public IQueryable Get()
        {
            clsEmpleado empleado = new clsEmpleado();
            return empleado.ListaEmpleados();
        }

        // GET api/<controller>/5
        public Empleado Get(int id)
        {
            clsEmpleado empleado = new clsEmpleado();
            return empleado.Consultar(id);
        }

        // POST api/<controller>
        public string Post([FromBody] Empleado empleado)
        {
            clsEmpleado _empleado = new clsEmpleado();
            _empleado.empleado = empleado;
            return _empleado.Insertar();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] Empleado empleado)
        {
            clsEmpleado _empleado = new clsEmpleado();
            _empleado.empleado = empleado;
            return _empleado.Actualizar();

        }

        // DELETE api/<controller>/5
        public string Delete(Empleado empleado)
        {
            clsEmpleado _empleado = new clsEmpleado();
            _empleado.empleado = empleado;
            return _empleado.Eliminar();
        }
    }
}