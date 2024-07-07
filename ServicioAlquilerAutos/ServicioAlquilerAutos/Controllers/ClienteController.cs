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
    public class ClienteController : ApiController
    {
        // GET api/<controller>
        public Cliente Get(int Documento)
        {
            clsCliente cliente = new clsCliente();
            return cliente.Consultar(Documento);
        }
        // POST api/<controller>
        public string Post([FromBody] Cliente Cliente)
        {
            clsCliente _cliente = new clsCliente();
            _cliente.cliente = Cliente;
            return _cliente.Insertar();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] Cliente Cliente)
        {
            clsCliente _cliente = new clsCliente();
            _cliente.cliente = Cliente;
            return _cliente.Actualizar();
        }

        // DELETE api/<controller>/5
        public string Delete(Cliente Cliente)
        {
            clsCliente _cliente = new clsCliente();
            _cliente.cliente = Cliente;
            return _cliente.Eliminar();
        }
    }
}