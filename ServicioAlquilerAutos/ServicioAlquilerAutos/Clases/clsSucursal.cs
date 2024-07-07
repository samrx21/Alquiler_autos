using ServicioAlquilerAutos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAlquilerAutos.Clases
{
    public class clsSucursal
    {
        public Sucursale sucursal { get; set; }
        private AlquilerVehiculosEntities dbAlquiler = new AlquilerVehiculosEntities();

        public IQueryable ListaSucursales()
        {
            return from S in dbAlquiler.Set<Sucursale>()
                   orderby (S.Nombre)
                   select new
                   {
                       id = S.SucursalID,
                       Nombre = S.Nombre,
                       Direccion = S.Direccion,
                       Telefono = S.Telefono
                   };
        }
    }
}