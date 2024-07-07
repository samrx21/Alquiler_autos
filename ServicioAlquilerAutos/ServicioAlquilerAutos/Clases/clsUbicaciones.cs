using ServicioAlquilerAutos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ServicioAlquilerAutos.Clases
{
    public class clsUbicaciones
    {
        public Ubicacione ubicacion { get; set; }
        private AlquilerVehiculosEntities dbAlquiler = new AlquilerVehiculosEntities();

        public List<Ubicacione> ListaUbicaciones()
        {
            return dbAlquiler.Ubicaciones.ToList();
        }
        public string Insertar()
        {
            try
            {
                dbAlquiler.Ubicaciones.Add(ubicacion);
                //Para garantizar que se inserte la información en la base de datos, se da la instrucción de SaveChanges()
                dbAlquiler.SaveChanges();
                return "Se a Ingresado la Ubicacion : " + ubicacion.NombreUbicacion;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Ubicacione Consultar(int ID)
        {
            return dbAlquiler.Ubicaciones.FirstOrDefault(s => s.Ubicaciones == ID);
        }
        public string Actualizar()
        {
            try
            {
                Ubicacione _ubicacion = Consultar(ubicacion.Ubicaciones);
                if (_ubicacion == null)
                {
                    return "La reserva con: " + ubicacion.Ubicaciones + ", no existe en la base de datos.";
                }
                dbAlquiler.Ubicaciones.AddOrUpdate(ubicacion);
                dbAlquiler.SaveChanges();
                return "Se actualizó la reserva: " + ubicacion.Ubicaciones;
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
                Ubicacione _ubicacion = Consultar(ubicacion.Ubicaciones);
                if (_ubicacion == null)
                {
                    return "La Ubicacion con codigo: " + ubicacion.Ubicaciones + ", no existe en la base de datos.";
                }
                dbAlquiler.Ubicaciones.Remove(_ubicacion);
                dbAlquiler.SaveChanges();
                return "Se elimino la Ubicacion: " + ubicacion.NombreUbicacion;
            }
            catch (Exception ex)
            {
                //Se captura el mensaje de la excepción y se retorna como respuesta
                return ex.Message;
            }
        }
    }
}