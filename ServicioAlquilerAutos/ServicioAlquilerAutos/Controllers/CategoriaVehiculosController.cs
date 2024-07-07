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
    public class CategoriaVehiculosController : ApiController
    {
        // GET api/<controller>
        public List<CategoriasVehiculo> Get()
        {
            clsCategoriaVehiculos categoriaVehiculos = new clsCategoriaVehiculos();
            return categoriaVehiculos.ListaCategorias();
        }


        
    }
}