using ServicioAlquilerAutos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ServicioAlquilerAutos.Clases
{
    public class clsReserva
    {

        public Reserva reserva { get; set; }
        private AlquilerVehiculosEntities dbAlquiler = new AlquilerVehiculosEntities();


        public List<Reserva> ListaReservas()
        {
            return dbAlquiler.Reservas.ToList();
        }


        public string Insertar()
        {
            try
            {
                CalcularCosto();
                dbAlquiler.Reservas.Add(reserva);
                //Para garantizar que se inserte la información en la base de datos, se da la instrucción de SaveChanges()
                dbAlquiler.SaveChanges();
                return reserva.CostoTotal.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Reserva Consultar(int ID)
        {
            return dbAlquiler.Reservas.FirstOrDefault(s => s.ReservaID == ID);
        }
        public string Actualizar()
        {
            try
            {
                Reserva _reserva = Consultar(reserva.ReservaID);
                if (_reserva == null)
                {
                    return "La reserva con: " + reserva.ReservaID + ", no existe en la base de datos.";
                }
                CalcularCosto();
                dbAlquiler.Reservas.AddOrUpdate(reserva);
                dbAlquiler.SaveChanges();
                return "Se actualizó la reserva: " + reserva.ReservaID;
            }
            catch (Exception ex)
            {
                //Se captura el mensaje de la excepción y se retorna como respuesta
                return ex.Message;
            }
        }
        public string Eliminar()
        {
            try
            {
                Reserva _reserva = Consultar(reserva.ReservaID);
                if (_reserva == null)
                {
                    return "La reserva con: " + reserva.ReservaID + ", no existe en la base de datos.";
                }
                dbAlquiler.Reservas.Remove(_reserva);
                //Se graban los cambios
                dbAlquiler.SaveChanges();
                //Se retorna la respuesta
                return "Se elimino la reserva: " + reserva.ReservaID;
            }
            catch (Exception ex)
            {
                //Se captura el mensaje de la excepción y se retorna como respuesta
                return ex.Message;
            }
        }
        private void CalcularCosto()
        {

            // Calcular la diferencia en días de la reserva
            TimeSpan diferencia = (TimeSpan)(reserva.FechaFinalizacion - reserva.FechaInicio);
            // Tomar el valor absoluto de la diferencia en días
            int diasalquiler = Math.Abs(diferencia.Days);
            // Consulta LINQ para obtener la TarifaPorDia del vehículo específico
            decimal? tarifaPorDia = dbAlquiler.Vehiculos
                .Where(vehiculo => vehiculo.Placa == reserva.PlacaVeh)
                .Select(vehiculo => vehiculo.TarifaPorDia)
                .FirstOrDefault();

            decimal? costoTotalVehiculo = diasalquiler * tarifaPorDia;

            // Consulta LINQ para obtener el PrecioAdicional del seguro específico
            decimal? precioAdicional = dbAlquiler.Seguros
                .Where(seguro => seguro.SeguroID == reserva.SeguroID)
                .Select(seguro => seguro.PrecioAdicional)
                .FirstOrDefault();
            reserva.CostoTotal = costoTotalVehiculo + precioAdicional;
        }

    }
}