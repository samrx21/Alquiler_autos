using Microsoft.Ajax.Utilities;
using ServicioAlquilerAutos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ServicioAlquilerAutos.Clases
{
    public class clsMantenimiento
    {

        public Mantenimiento mantenimiento { get; set; }
        private AlquilerVehiculosEntities dbAlquiler = new AlquilerVehiculosEntities();

        public IQueryable ListaMantenimientos()
        {
            return from M in dbAlquiler.Set<Mantenimiento>()
                   orderby (M.FechaMantenimiento)
                   select new
                   {
                       mantenimiento = M.MantenimientoID,
                       Placa = M.Placa,
                       FechaMantenimiento = M.FechaMantenimiento,
                       Descripcion = M.Descripcion,
                       Costo = M.Costo
                   };
        }
        public string Insertar()
        {
            try
            {
                dbAlquiler.Mantenimientoes.Add(mantenimiento);
                //Para garantizar que se inserte la información en la base de datos, se da la instrucción de SaveChanges()
                dbAlquiler.SaveChanges();
                return "Se a Ingresado el mantenimiento : " + mantenimiento.MantenimientoID;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Mantenimiento Consultar(int id)
        {
            return dbAlquiler.Mantenimientoes.FirstOrDefault(s => s.MantenimientoID == id);
        }
        public string Actualizar()
        {
            try
            {
                Mantenimiento _mantenimiento = Consultar(mantenimiento.MantenimientoID);
                if (_mantenimiento == null)
                {
                    return "El mantenimiento con id  " + mantenimiento.MantenimientoID + ", no existe en la base de datos.";
                }
                dbAlquiler.Mantenimientoes.AddOrUpdate(mantenimiento);
                dbAlquiler.SaveChanges();
                return "Se actualizó el mantenimiento con id: " + mantenimiento.MantenimientoID;
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
                Mantenimiento _mantenimiento = Consultar(mantenimiento.MantenimientoID);
                if (_mantenimiento == null)
                {
                    return "El mantenimiento con id  " + mantenimiento.MantenimientoID + ", no existe en la base de datos.";
                }
                dbAlquiler.Mantenimientoes.Remove(_mantenimiento);
                dbAlquiler.SaveChanges();
                return "Se actualizó el mantenimiento con id: " + mantenimiento.MantenimientoID;
            }

            catch (Exception ex)
            {
                //Se captura el mensaje de la excepción y se retorna como respuesta
                return ex.Message;
            }
        }
    }
}