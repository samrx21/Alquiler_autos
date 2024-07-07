using ServicioAlquilerAutos.Clases;
using ServicioAlquilerAutos.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ServicioAlquilerAutos.Controllers
{
   [EnableCors(origins: "http://localhost:51464", headers: "*", methods: "*")]
    public class VehiculoController : ApiController
    {

        // GET api/<controller>
        public IQueryable Get(int categoria,int op)
        {
                clsVehiculo vehiculo = new clsVehiculo();
                return vehiculo.ListaVehiculosCategoria(categoria);  
        }
        public IQueryable Get()
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.ListaVehiculos();
        }

         // GET api/<controller>/5
        public Vehiculo Get(string id)
        {
            clsVehiculo vehiculo = new clsVehiculo();
            return vehiculo.Consultar(id);
        }

        // POST api/<controller>
        public string Post([FromBody] Vehiculo vehiculo)
        {
            clsVehiculo _vehiculo = new clsVehiculo();
            _vehiculo.vehiculo = vehiculo;
            return _vehiculo.Insertar();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] Vehiculo vehiculo)
        {
            clsVehiculo _vehiculo = new clsVehiculo();
            _vehiculo.vehiculo = vehiculo;
            return _vehiculo.Actualizar();
        }

        // DELETE api/<controller>/5
        public string Delete(Vehiculo vehiculo)
        {
            clsVehiculo _vehiculo = new clsVehiculo();
            _vehiculo.vehiculo = vehiculo;
            return _vehiculo.Eliminar();
        }
    }
}