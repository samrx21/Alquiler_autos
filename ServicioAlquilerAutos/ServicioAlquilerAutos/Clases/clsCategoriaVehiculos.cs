using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServicioAlquilerAutos.Models;

namespace ServicioAlquilerAutos.Clases
{
    public class clsCategoriaVehiculos
    {

        public CategoriasVehiculo categoriasVehiculo = new CategoriasVehiculo();
        private AlquilerVehiculosEntities dbAlquiler = new AlquilerVehiculosEntities();


        public List<CategoriasVehiculo> ListaCategorias()
        {
            return dbAlquiler.CategoriasVehiculos.ToList();
        }
    }
}