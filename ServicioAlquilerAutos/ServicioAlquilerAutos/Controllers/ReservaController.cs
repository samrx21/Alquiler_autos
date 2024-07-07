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
    public class ReservaController : ApiController
    {

        public List<Reserva> Get()
        {
            clsReserva reserva = new clsReserva();
            return reserva.ListaReservas();
        }
        // GET api/<controller>/5
        public Reserva Get(int id)
        {
            clsReserva _reserva = new clsReserva();
            return _reserva.Consultar(id);
        }

        // POST api/<controller>
        public string Post([FromBody] Reserva reserva)
        {
            clsReserva _reserva = new clsReserva();
            _reserva.reserva = reserva;
            return _reserva.Insertar();
        }

        // PUT api/<controller>/5
        public string Put([FromBody] Reserva reserva)
        {
            clsReserva _reserva = new clsReserva();
            _reserva.reserva = reserva;
            return _reserva.Actualizar();
        }

        // DELETE api/<controller>/5
        public string Delete(Reserva reserva)
        {
            clsReserva _reserva = new clsReserva();
            _reserva.reserva = reserva;
            return _reserva.Eliminar();
        }
    }
}