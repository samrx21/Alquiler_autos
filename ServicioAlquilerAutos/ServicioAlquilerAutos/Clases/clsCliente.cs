using ServicioAlquilerAutos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ServicioAlquilerAutos.Clases
{
    public class clsCliente
    {
        public Cliente cliente { get; set; }
        private AlquilerVehiculosEntities dbAlquiler = new AlquilerVehiculosEntities();
        public string Insertar()
        {
            try
            {
                Cliente _cliente = Consultar(cliente.Cedula);
                if(_cliente != null)
                {
                    return "";
                }
                dbAlquiler.Clientes.Add(cliente);
                dbAlquiler.SaveChanges();
                return "Se ingresó el cliente con documento: " + cliente.Cedula;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string Actualizar()
        {
            try
            {
                Cliente _cliente = Consultar(cliente.Cedula);
                if (_cliente == null)
                {
                    return "El cliente con documento: " + cliente.Cedula + " no existe en la base de datos.";
                }
                dbAlquiler.Clientes.AddOrUpdate(cliente);
                dbAlquiler.SaveChanges();
                return "Se actualizaron los datos del cliente con documento: " + cliente.Cedula;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public Cliente Consultar(int documento)
        {
            return dbAlquiler.Clientes.FirstOrDefault(c => c.Cedula == documento);
        }
        public string Eliminar()
        {
            Cliente _cliente = Consultar(cliente.Cedula);
            if (_cliente == null)
            {
                return "El cliente con documento: " + cliente.Cedula + " no existe en la base de datos.";
            }
            try
            {
                dbAlquiler.Clientes.Remove(_cliente);
                dbAlquiler.SaveChanges();
                return "Se eliminó el cliente con documento: " + cliente.Cedula;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}