using Microsoft.Ajax.Utilities;
using ServicioAlquilerAutos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;


namespace ServicioAlquilerAutos.Clases
{
    public class clsEmpleado
    {
        public Empleado empleado { get; set; }
        private AlquilerVehiculosEntities dbAlquiler = new AlquilerVehiculosEntities();

        public IQueryable ListaEmpleados()
        {
            return from E in dbAlquiler.Set<Empleado>()
                   join S in dbAlquiler.Set<Sucursale>()
                   on E.SucursalID equals S.SucursalID
                   orderby (E.Nombre)
                   select new
                   {
                       Cedula = E.EmpleadoID,
                       Nombre = E.Nombre,
                       Apellido = E.Apellido,
                       Puesto = E.Puesto,
                       Salario = E.Salario,
                       FechaContratacion = E.FechaContratacion,
                       Sucursal = S.SucursalID
                   };
        }
        public string Insertar()
        {
            try
            {
                dbAlquiler.Empleados.Add(empleado);
                //Para garantizar que se inserte la información en la base de datos, se da la instrucción de SaveChanges()
                dbAlquiler.SaveChanges();
                return "Se a Ingresado el empleado : " + empleado.EmpleadoID;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Empleado Consultar(int cedula)
        {
            return dbAlquiler.Empleados.FirstOrDefault(s => s.EmpleadoID == cedula);
        }
        public string Actualizar()
        {
            try
            {
                Empleado _empleado = Consultar(empleado.EmpleadoID);
                if (_empleado == null)
                {
                    return "El Empleado con con cedula  " + empleado.EmpleadoID + ", no existe en la base de datos.";
                }
                dbAlquiler.Empleados.AddOrUpdate(empleado);
                dbAlquiler.SaveChanges();
                return "Se actualizó el empleado con cedula: " + empleado.EmpleadoID;
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
                Empleado _empleado = Consultar(empleado.EmpleadoID);
                if (_empleado == null)
                {
                    return "El Empleado con cedula: " + empleado.EmpleadoID + ", no existe en la base de datos.";
                }
                dbAlquiler.Empleados.Remove(_empleado);
                dbAlquiler.SaveChanges();
                return "Se actualizó el empleado con cedula : " + _empleado.EmpleadoID;
            }

            catch (Exception ex)
            {
                //Se captura el mensaje de la excepción y se retorna como respuesta
                return ex.Message;
            }
        }
    }
}