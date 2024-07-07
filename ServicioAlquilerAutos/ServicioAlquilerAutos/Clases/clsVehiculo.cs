using Microsoft.Ajax.Utilities;
using ServicioAlquilerAutos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ServicioAlquilerAutos.Clases
{
    public class clsVehiculo
    {
        public Vehiculo vehiculo { get; set; }
        private AlquilerVehiculosEntities dbAlquiler = new AlquilerVehiculosEntities();

        public IQueryable ListaVehiculosCategoria(int categoria)
        {
            return from V in dbAlquiler.Set<Vehiculo>()
                   join Cat in dbAlquiler.Set<CategoriasVehiculo>()
                   on V.CategoriaID equals Cat.CategoriaID
                   orderby (V.Modelo)
                   where (Cat.CategoriaID == categoria)
                   select new
                   {
                       placa = V.Placa,
                       Marca = V.Marca,
                       Modelo = V.Modelo,
                       Anio = V.Anio,
                       TarifaPorDia = V.TarifaPorDia,
                       Categoria= Cat.NombreCategoria
                   };
        }
        public IQueryable ListaVehiculos()
        {
            return from V in dbAlquiler.Set<Vehiculo>()
                   
                   orderby (V.Modelo)
                   select new
                   {
                       placa = V.Placa,
                       Marca = V.Marca,
                       Modelo = V.Modelo,
                       Anio = V.Anio,
                       TarifaPorDia = V.TarifaPorDia,
                       Categoria = V.CategoriaID
                   };
        }
        public string Insertar()
        {
            try
            {
                dbAlquiler.Vehiculos.Add(vehiculo);
                //Para garantizar que se inserte la información en la base de datos, se da la instrucción de SaveChanges()
                dbAlquiler.SaveChanges();
                return "Se a Ingresado el vehiculo : " + vehiculo.Placa;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Vehiculo Consultar(string placa)
        {
            return dbAlquiler.Vehiculos.FirstOrDefault(s => s.Placa == placa);
        }
        public string Actualizar()
        {
            try
            {
                Vehiculo _vehiculo = Consultar(vehiculo.Placa);
                if (_vehiculo == null)
                {
                    return "El vehiuclo con: " + vehiculo.Placa + ", no existe en la base de datos.";
                }
                dbAlquiler.Vehiculos.AddOrUpdate(vehiculo);
                dbAlquiler.SaveChanges();
                return "Se actualizó el vehiculo: " + vehiculo.Placa;
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
                Vehiculo _vehiculo = Consultar(vehiculo.Placa);
                if (_vehiculo == null)
                {
                    return "El vehiuclo con codigo: " + vehiculo.Placa + ", no existe en la base de datos.";
                }
                dbAlquiler.Vehiculos.Remove(_vehiculo);
                dbAlquiler.SaveChanges();
                return "Se elimino el vehiuclo: " + _vehiculo.Placa;
            }
            catch (Exception ex)
            {
                //Se captura el mensaje de la excepción y se retorna como respuesta
                return ex.Message;
            }
        }
    }
}