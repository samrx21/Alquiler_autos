using ServicioAlquilerAutos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ServicioAlquilerAutos.Clases
{
    public class clsAccesorios
    {
        public Accesorio accesorio { get; set; }
        private AlquilerVehiculosEntities dbAlquiler = new AlquilerVehiculosEntities();

        public List<Accesorio> ListaAccesorios()
        {
            return dbAlquiler.Accesorios.ToList();
        }
        public string Insertar()
        {
            try
            {
                dbAlquiler.Accesorios.Add(accesorio);
                //Para garantizar que se inserte la información en la base de datos, se da la instrucción de SaveChanges()
                dbAlquiler.SaveChanges();
                return "Se a Ingresado el accesorio : " + accesorio.AccesorioID;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Accesorio Consultar(int id)
        {
            return dbAlquiler.Accesorios.FirstOrDefault(s => s.AccesorioID == id);
        }
        public string Actualizar()
        {
            try
            {
                Accesorio _accesorio = Consultar(accesorio.AccesorioID);
                if (_accesorio == null)
                {
                    return "El accesorio con id  " + accesorio.AccesorioID + ", no existe en la base de datos.";
                }
                dbAlquiler.Accesorios.AddOrUpdate(accesorio);
                dbAlquiler.SaveChanges();
                return "Se actualizó el accesorio con id: " + accesorio.AccesorioID;
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
                Accesorio _accesorio = Consultar(accesorio.AccesorioID);
                if (_accesorio == null)
                {
                    return "El accesorio con id  " + accesorio.AccesorioID + ", no existe en la base de datos.";
                }
                dbAlquiler.Accesorios.Remove(_accesorio);
                dbAlquiler.SaveChanges();
                return "Se actualizó el accesorio con id: " + accesorio.AccesorioID;
            }

            catch (Exception ex)
            {
                //Se captura el mensaje de la excepción y se retorna como respuesta
                return ex.Message;
            }
        }
    }
}