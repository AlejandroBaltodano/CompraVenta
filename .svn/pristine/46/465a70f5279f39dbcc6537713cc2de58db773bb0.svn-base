using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
namespace CompraVenta.UI.Convertidores
{
    public class ClienteConvertidor
    {
      



        public List<Models.ClienteModels> ObtenerListaConvertidaDeTodosLosClientes(List<Model.Cliente.Clientes> laListaDeTodosLosClientes) {
            
            List<Models.ClienteModels> laListaConvertidaClienteModels = new List<Models.ClienteModels>();

            for (int i = 0; i < laListaDeTodosLosClientes.Count; i++)
            {
                Models.ClienteModels modelsClientes = new Models.ClienteModels();

                modelsClientes.Id = laListaDeTodosLosClientes[i].Id;
                modelsClientes.Cedula = laListaDeTodosLosClientes[i].Cedula;
                modelsClientes.NombreCompleto = laListaDeTodosLosClientes[i].NombreCompleto;
                modelsClientes.Direccion = laListaDeTodosLosClientes[i].Direccion;
                modelsClientes.Telefono1 = laListaDeTodosLosClientes[i].Telefono1;
                modelsClientes.Telefono2 = laListaDeTodosLosClientes[i].Telefono2;
                modelsClientes.Email = laListaDeTodosLosClientes[i].Email;
                modelsClientes.Estado = laListaDeTodosLosClientes[i].Estado;
                modelsClientes.Id_AspNetUser = laListaDeTodosLosClientes[i].Id_AspNetUser;

                laListaConvertidaClienteModels.Add(modelsClientes);

            }

            return laListaConvertidaClienteModels;

        }



        public List<Models.ClienteModels> ObtenerListaConvertidaDeClientePorCedula(List<Model.Cliente.Clientes> laListaDeLosClientesPorCedula) {

            List<Models.ClienteModels> laListaDeModelsClientesPorCedula = new List<Models.ClienteModels>();

            

            Models.ClienteModels modelsCliente = new Models.ClienteModels();

            foreach (Model.Cliente.Clientes cliente in laListaDeLosClientesPorCedula)
            {
                   
                    modelsCliente.Id = cliente.Id;
                    modelsCliente.Cedula = cliente.Cedula;
                    modelsCliente.NombreCompleto = cliente.NombreCompleto;
                    modelsCliente.Direccion = cliente.Direccion;
                    modelsCliente.Telefono1 = cliente.Telefono1;
                    modelsCliente.Telefono2 = cliente.Telefono2;
                    modelsCliente.Email = cliente.Email;
                    modelsCliente.Estado = cliente.Estado;
                    modelsCliente.Id_AspNetUser = cliente.Id_AspNetUser;

                    laListaDeModelsClientesPorCedula.Add(modelsCliente);

                }


            return laListaDeModelsClientesPorCedula;
          

        }


        public List<Models.ClienteModels> ObtenerListaConvertidaDeClientePorEstado(List<Model.Cliente.Clientes> laListaDeLosClientesPorEstado) {


            List<Models.ClienteModels> laListaDeModelsClientesPorEstado = new List<Models.ClienteModels>();
           

            Models.ClienteModels modelsClientesPorEstado = new Models.ClienteModels();
            for (int i = 0; i < laListaDeLosClientesPorEstado.Count; i++)
            {
                
                modelsClientesPorEstado.Id = laListaDeLosClientesPorEstado[i].Id;
                modelsClientesPorEstado.Cedula = laListaDeLosClientesPorEstado[i].Cedula;
                modelsClientesPorEstado.NombreCompleto = laListaDeLosClientesPorEstado[i].NombreCompleto;
                modelsClientesPorEstado.Direccion = laListaDeLosClientesPorEstado[i].Direccion;
                modelsClientesPorEstado.Telefono1 = laListaDeLosClientesPorEstado[i].Telefono1;
                modelsClientesPorEstado.Telefono2 = laListaDeLosClientesPorEstado[i].Telefono2;
                modelsClientesPorEstado.Email = laListaDeLosClientesPorEstado[i].Email;
                modelsClientesPorEstado.Estado = laListaDeLosClientesPorEstado[i].Estado;
                modelsClientesPorEstado.Id_AspNetUser = laListaDeLosClientesPorEstado[i].Id_AspNetUser;


                laListaDeModelsClientesPorEstado.Add(modelsClientesPorEstado);

            }

            return laListaDeModelsClientesPorEstado;

        }

        public Models.ClienteModels ObtenerClienteConvertidoPorId(Model.Cliente.Clientes cliente)
        {
            
            Models.ClienteModels clientesModels = new Models.ClienteModels();

            clientesModels.Cedula = cliente.Cedula;
            clientesModels.Direccion = cliente.Direccion;
            clientesModels.Email = cliente.Email;
            clientesModels.Estado = cliente.Estado;
            clientesModels.Id = cliente.Id;
            clientesModels.Id_AspNetUser = cliente.Id_AspNetUser;
            clientesModels.NombreCompleto = cliente.NombreCompleto;
            clientesModels.Telefono1 = cliente.Telefono1;
            clientesModels.Telefono2 = cliente.Telefono2;

            return clientesModels;
        }










    }
}