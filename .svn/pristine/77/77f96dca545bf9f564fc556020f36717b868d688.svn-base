using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;

namespace CompraVenta.UI.Controllers

{
    [Authorize]
    public class ClientesController : Controller
    {
        public const byte ClienteActivo = (byte)Model.Enumerados.Estado.Activo;
        public const byte ClienteInactivo = (byte)Model.Enumerados.Estado.Inactivo;
        public const string ClienteConEstadoActivo = "activo";
        public const string ClientesConEstadoInactivo = "inactivo";
        // GET: Clientes


        public ActionResult ListaDeLosClientes()

        {
            Convertidores.ClienteConvertidor convertidorDeClientes = new Convertidores.ClienteConvertidor();
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes;
            coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();

            List<Model.Cliente.Clientes> laListaDeTodosLosClientes = new List<Model.Cliente.Clientes>();
            laListaDeTodosLosClientes = coordinadorDeClientes.ObtenerListaDeTodosLosClientes();
            List<Models.ClienteModels> laListaDeModelsClientes = convertidorDeClientes.ObtenerListaConvertidaDeTodosLosClientes(laListaDeTodosLosClientes);
            return View(laListaDeModelsClientes);
        }

        // GET: ClientesPorCedula
        [Authorize]
        public ActionResult ListaDeLosClientesPorCedula()

        {
            Convertidores.ClienteConvertidor convertidorDeClientes = new Convertidores.ClienteConvertidor();
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes;
            coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();

            List<Model.Cliente.Clientes> laListaDeTodosLosClientes = new List<Model.Cliente.Clientes>();
            laListaDeTodosLosClientes = coordinadorDeClientes.ObtenerListaDeTodosLosClientes();
            List<Models.ClienteModels> laListaDeModelsClientes = convertidorDeClientes.ObtenerListaConvertidaDeTodosLosClientes(laListaDeTodosLosClientes);
            return View(laListaDeModelsClientes);
        }


        // Post: ClientesPorCedula
        [HttpPost]
        public ActionResult ListaDeLosClientesPorCedula(string cedulaABuscar)

        {
            Convertidores.ClienteConvertidor convertidorDeClientes = new Convertidores.ClienteConvertidor();
            List<Models.ClienteModels> laListaDeModelsClientesPorCedula = new List<Models.ClienteModels>();
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes;
            coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
            List<Model.Cliente.Clientes> laListaDeLosClientesPorCedula = new List<Model.Cliente.Clientes>();

            laListaDeLosClientesPorCedula = coordinadorDeClientes.ObtenerListaDeClientesPorCedula(cedulaABuscar);

            try
            {
                string cedula = cedulaABuscar;

                if (!string.IsNullOrEmpty(cedula))
                {
                    laListaDeModelsClientesPorCedula = convertidorDeClientes.ObtenerListaConvertidaDeClientePorCedula(laListaDeLosClientesPorCedula);
                  

                    return View(laListaDeModelsClientesPorCedula);
                }
                ModelState.AddModelError("", "Campo Cedula Invalido, Ingrese una cedula valida.");

                return View(laListaDeModelsClientesPorCedula);
            }
            catch
            {
                return View(laListaDeModelsClientesPorCedula);
            }

        }


        // GET: ClientesPorEstado

        public ActionResult ListaDeLosClientesPorEstado()

        {
            Convertidores.ClienteConvertidor convertidorDeClientes = new Convertidores.ClienteConvertidor();
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes;
            coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();

            List<Model.Cliente.Clientes> laListaDeTodosLosClientes = new List<Model.Cliente.Clientes>();
            laListaDeTodosLosClientes = coordinadorDeClientes.ObtenerListaDeTodosLosClientes();
            List<Models.ClienteModels> laListaDeModelsClientes = convertidorDeClientes.ObtenerListaConvertidaDeTodosLosClientes(laListaDeTodosLosClientes);

            return View(laListaDeModelsClientes);
        }


        // Post: ClientesPorEstado
        [HttpPost]
        public ActionResult ListaDeLosClientesPorEstado(string estado)

        {
            Convertidores.ClienteConvertidor convertidorDeClientes = new Convertidores.ClienteConvertidor();
            List<Models.ClienteModels> laListaDeModelsClientesPorEstado = new List<Models.ClienteModels>();

            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes;
            coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
            List<Model.Cliente.Clientes> laListaDeLosClientesPorEstado = new List<Model.Cliente.Clientes>();


            if (estado == ClienteConEstadoActivo)
            {
                laListaDeLosClientesPorEstado = coordinadorDeClientes.ObtenerListaDeClientesPorEstado(ClienteActivo);
            }
            else if (estado == ClientesConEstadoInactivo)
            {
                laListaDeLosClientesPorEstado = coordinadorDeClientes.ObtenerListaDeClientesPorEstado(ClienteInactivo);
            }
            try
            {
               
                if (!string.IsNullOrEmpty(estado))
                {
                    laListaDeModelsClientesPorEstado = convertidorDeClientes.ObtenerListaConvertidaDeClientePorEstado(laListaDeLosClientesPorEstado);
                   
                    return View(laListaDeModelsClientesPorEstado);
                }////////

                return RedirectToAction("ListaDeLosClientesPorEstado");
            }
            catch
            {
                return View();
            }

        }


        // GET: Clientes/Create

        public ActionResult Create()
        {


            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(Model.Cliente.Clientes nuevoCliente)
        {
            try
            {

                LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes;
                coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();

                string elIdDelUsario = User.Identity.GetUserId();
                nuevoCliente.Id_AspNetUser = elIdDelUsario;
     
                coordinadorDeClientes.AgregarUnCliente(nuevoCliente);
                coordinadorDeClientes.EnviarCorreoDeNuevoCliente(nuevoCliente.Email, nuevoCliente);

                return RedirectToAction("ListaDeLosClientes");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Edit/5

        public ActionResult Edit(int id)
        {
            Convertidores.ClienteConvertidor convertidorDeClientes = new Convertidores.ClienteConvertidor();
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes;
            coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
            Model.Cliente.Clientes cliente = coordinadorDeClientes.ConsultarClientePorId(id);

            var model = convertidorDeClientes.ObtenerClienteConvertidoPorId(cliente);
          
            return View(model);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Model.Cliente.Clientes cliente)
        {
            try
            {
                LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes;
                coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();

                Model.Cliente.Clientes elCliente = coordinadorDeClientes.ConsultarClientePorId(id);
                elCliente.Cedula = cliente.Cedula;
                elCliente.Direccion = cliente.Direccion;
                elCliente.NombreCompleto = cliente.NombreCompleto;
                elCliente.Telefono1 = cliente.Telefono1;
                elCliente.Telefono2 = cliente.Telefono2;
                elCliente.Email = cliente.Email;

                coordinadorDeClientes.EditarUnCliente(elCliente);
                coordinadorDeClientes.EnviarCorreoDeEdicionDeCliente(elCliente.Email, elCliente);



                return RedirectToAction("ListaDeLosClientes");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Activar

        public ActionResult ActivarCliente(int id)
        {
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes;
            coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();

            Model.Cliente.Clientes elCliente;
            elCliente = coordinadorDeClientes.ConsultarClientePorId(id);


            return View(elCliente);
        }

        // POST: Clientes/Activar
        [HttpPost]
        public ActionResult ActivarCliente(int id, Model.Cliente.Clientes cliente)
        {
            try
            {
                LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes;
                coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
                Model.Cliente.Clientes elCliente = coordinadorDeClientes.ConsultarClientePorId(id);


                coordinadorDeClientes.ActivarUnCliente(elCliente);

                return RedirectToAction("ListaDeLosClientes");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Inactivar

        public ActionResult InactivarCliente(int id)
        {
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes;
            coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();

            Model.Cliente.Clientes elCliente;
            elCliente = coordinadorDeClientes.ConsultarClientePorId(id);


            return View(elCliente);
        }

        // POST: Clientes/Inactivar
        [HttpPost]
        public ActionResult InactivarCliente(int id, Model.Cliente.Clientes cliente)
        {
            try
            {
                LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes;
                coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
                Model.Cliente.Clientes elCliente = coordinadorDeClientes.ConsultarClientePorId(id);



                coordinadorDeClientes.InactivarUnCliente(elCliente);

                return RedirectToAction("ListaDeLosClientes");
            }
            catch
            {
                return View();
            }
        }
    }
}
