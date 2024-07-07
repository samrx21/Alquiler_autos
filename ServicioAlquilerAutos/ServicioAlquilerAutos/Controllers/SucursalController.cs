using ServicioAlquilerAutos.Clases;
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

    public class SucursalController : ApiController
    {

        // GET api/<controller>
        public IQueryable Get()
        {
            clsSucursal sucursal = new clsSucursal();
            return sucursal.ListaSucursales();
        }
    }
}