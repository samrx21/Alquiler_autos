using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using ServicioAlquilerAutos.Models;

namespace ServicioAlquilerAutos.Clases
{
    public class clsSeguro
    {
        public Seguro seguro { get; set; }
        private AlquilerVehiculosEntities dbAlquiler = new AlquilerVehiculosEntities();

        public List<Seguro> ListaSeguros()
        {
            return dbAlquiler.Seguros.ToList();
        }

        public string Insertar()
        {
            try
            {
                dbAlquiler.Seguros.Add(seguro);
                //Para garantizar que se inserte la información en la base de datos, se da la instrucción de SaveChanges()
                dbAlquiler.SaveChanges();
                return "Se a ingresado un nuevo seguro";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Seguro Consultar(int ID)
        {
            return dbAlquiler.Seguros.FirstOrDefault(s => s.SeguroID == ID);
        }
        public string Actualizar()
        {
            try
            {
                Seguro _seguro = Consultar(seguro.SeguroID);
                if (_seguro == null)
                {
                    return "El seguro con codigo: " + seguro.SeguroID + ", no existe en la base de datos.";
                }
                dbAlquiler.Seguros.AddOrUpdate(seguro);
                dbAlquiler.SaveChanges();
                return "Se actualizó el seguro: " + seguro.NombreSeguro;
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
                Seguro _seguro = Consultar(seguro.SeguroID);
                if (_seguro == null)
                {
                    return "El seguro con codigo: " + seguro.SeguroID + ", no existe en la base de datos.";
                }
                dbAlquiler.Seguros.Remove(_seguro);
                //Se graban los cambios
                dbAlquiler.SaveChanges();
                //Se retorna la respuesta
                return "Se elimino el seguro: " + _seguro.NombreSeguro;
            }
            catch (Exception ex)
            {
                //Se captura el mensaje de la excepción y se retorna como respuesta
                return ex.Message;
            }
        }

    }
}