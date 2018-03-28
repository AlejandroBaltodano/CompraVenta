using CompraVenta.UI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompraVenta.UI.Controllers

{
    [Authorize]
    public class PrestamosController : Controller
    {
      
        public const int ListaVacia = 0;
        // GET: Prestamos
        [Authorize]
        public ActionResult Index()
        {
            LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos coordinadorDePrestamos;
            coordinadorDePrestamos = new LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos();
            LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos coordinadorDeAbonos;
            coordinadorDeAbonos = new LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos();
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes;
            coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
            Convertidores.PrestamoConvertidor convertidorPrestamos = new Convertidores.PrestamoConvertidor();

            List<Model.Prestamos.Prestamos> laListaDeTodosLosPrestamos = coordinadorDePrestamos.ObtenerListaDeTodosLosPrestamos();

            List<Models.PrestamosModels> laListaDeModelsPrestamos = convertidorPrestamos.ObtenerListaConvertidaDePrestamos(laListaDeTodosLosPrestamos, coordinadorDePrestamos, coordinadorDeAbonos, coordinadorDeClientes);

            return View(laListaDeModelsPrestamos);
        }

        // GET: Prestamos/Details/5
        public ActionResult Details(int id)
        {
            LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos coordinadorDeAbonos;
            coordinadorDeAbonos = new LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos();
            LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos coordinadorDePrestamos;
            coordinadorDePrestamos = new LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos();
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes;
            coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
            Model.Prestamos.Prestamos prestamo = new Model.Prestamos.Prestamos();
            prestamo = coordinadorDePrestamos.ConsultarPrestamoPorId(id);

            Convertidores.PrestamoConvertidor convertidorDePrestamos = new Convertidores.PrestamoConvertidor();

            Models.PrestamosModels modelsPrestamo = convertidorDePrestamos.ObtenerConvertidorDetallePrestamoEspecifico(prestamo, coordinadorDePrestamos, coordinadorDeAbonos, coordinadorDeClientes);

            return View(modelsPrestamo);
        }

        public ActionResult ListarAbonos(List<Model.Abono.Abono> listaDeAbonos) {


            return View(listaDeAbonos);
        }

        // GET: Prestamos/Create
        public ActionResult Create()
        {
            Models.PrestamosModels PrestamoModels = new Models.PrestamosModels();
            LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos coordinadorDePrestamos;
            coordinadorDePrestamos = new LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos();
            PrestamoModels.laListaDePlazoDiasPrestamo = coordinadorDePrestamos.ObtenerPlazoDiasPrestamo();

            return View(PrestamoModels);
        }

        // POST: Prestamos/Create
        [HttpPost]
        public ActionResult Create(Models.PrestamosModels elPrestamo)
        {
            try
            {
                
                Convertidores.PrestamoConvertidor convertidorPrestamos = new Convertidores.PrestamoConvertidor();
                LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos coordinadorDePrestamos;
                coordinadorDePrestamos = new LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos();
                LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes;
                coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
              
                Model.Prestamos.Prestamos elNuevoPrestamo = new Model.Prestamos.Prestamos();
                var laListaDeClientesPorCedula = coordinadorDeClientes.ObtenerListaDeClientesPorCedula(elPrestamo.CedulaCliente);

                if (laListaDeClientesPorCedula.Count!=ListaVacia)
                {
                    elNuevoPrestamo = convertidorPrestamos.ObtenerConvertidorPrestamosPorPrestamoModelsCrear(elPrestamo, coordinadorDeClientes);
                   
                    string idUser = User.Identity.GetUserId();

                    elNuevoPrestamo.Id_AspNetUser = idUser;
                    coordinadorDePrestamos.AgregarUnPrestamo(elNuevoPrestamo);

                  

                        return RedirectToAction("Index");
                }
                else
                {
                    Models.PrestamosModels elPrestamoModels = new Models.PrestamosModels();
                    elPrestamoModels.laListaDePlazoDiasPrestamo = coordinadorDePrestamos.ObtenerPlazoDiasPrestamo();
                    ViewBag.Name = "Identificación del cliente no válida.";
                    return View(elPrestamoModels);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Prestamos/Edit/5
        public ActionResult Edit(int id)
        {
            LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos coordinadorDePrestamos;
            coordinadorDePrestamos = new LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos();
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes;
            coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
            

            Model.Prestamos.Prestamos elPrestamo = new Model.Prestamos.Prestamos();
            elPrestamo = coordinadorDePrestamos.ConsultarPrestamoPorId(id);
            Model.Cliente.Clientes clienteDelPrestamo = coordinadorDeClientes.ConsultarClientePorId(elPrestamo.IdCliente);

            Convertidores.PrestamoConvertidor convertidorPrestamos = new Convertidores.PrestamoConvertidor();
            Models.PrestamosModels elPrestamoModels = convertidorPrestamos.ObtenerConvertidorPrestamoPorId(elPrestamo, coordinadorDePrestamos, clienteDelPrestamo);
            
            return View(elPrestamoModels);
        }

        // POST: Prestamos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Models.PrestamosModels elPrestamo)
        {
            try
            {
                
                Convertidores.PrestamoConvertidor convertidorPrestamos = new Convertidores.PrestamoConvertidor();

                LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos coordinadorDePrestamos;
                coordinadorDePrestamos = new LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos();

                LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes;
                coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
              

                Model.Prestamos.Prestamos elNuevoPrestamo = new Model.Prestamos.Prestamos();
                elNuevoPrestamo = coordinadorDePrestamos.ConsultarPrestamoPorId(id);
                var listaDeClientesPorCedula = coordinadorDeClientes.ObtenerListaDeClientesPorCedula(elPrestamo.CedulaCliente);



                var laListaDeClientesPorCedula = coordinadorDeClientes.ObtenerListaDeClientesPorCedula(elPrestamo.CedulaCliente);

                if (laListaDeClientesPorCedula.Count != ListaVacia)
                {
                    elNuevoPrestamo = convertidorPrestamos.ObtenerConvertidorPrestamosPorPrestamoModelsEditar(id,elPrestamo, listaDeClientesPorCedula, coordinadorDePrestamos);

                    coordinadorDePrestamos.EditarUnPrestamo(elNuevoPrestamo);

                    return RedirectToAction("Index");
                }
                else
                {
                    Models.PrestamosModels elPrestamoModels = new Models.PrestamosModels();
                    elPrestamoModels.laListaDePlazoDiasPrestamo = coordinadorDePrestamos.ObtenerPlazoDiasPrestamo();
                    ViewBag.Name = "Identificación del cliente no válida.";
                    return View(elPrestamoModels);
                }

            }
            catch
            {
                return View();
            }
        }

     
        public ActionResult ListaDePréstamosDelClientePorCedula(string cedulaABuscar)
        {
            List<Models.PrestamosModels> laListaDeModelsPrestamoPorCedula = new List<PrestamosModels>();
            string cedula = cedulaABuscar;

            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes;
            coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
            LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos coordinadorDePrestamos;
            coordinadorDePrestamos = new LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos();
          
            List<Model.Cliente.Clientes> laListaDeLosClientesPorCedula = new List<Model.Cliente.Clientes>();

            LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos coordinadorDeAbonos = new LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos();
         
            List<Model.Prestamos.Prestamos> laListaDeTodosLosPrestamos = new List<Model.Prestamos.Prestamos>();

            List<Models.PrestamosModels> laListaDeModelsPrestamos = new List<Models.PrestamosModels>();


            laListaDeLosClientesPorCedula = coordinadorDeClientes.ObtenerListaDeClientesPorCedula(cedula);
            try
            {
                if (!string.IsNullOrEmpty(cedulaABuscar))
                {
                    Convertidores.PrestamoConvertidor convertidorPrestamos = new Convertidores.PrestamoConvertidor();
                    laListaDeModelsPrestamoPorCedula = convertidorPrestamos.ObtenerListaConvertidaDePrestamosPorCedulaCliente(cedulaABuscar, laListaDeLosClientesPorCedula, coordinadorDePrestamos, coordinadorDeAbonos,coordinadorDeClientes);
                    return View(laListaDeModelsPrestamoPorCedula);
                }

                ModelState.AddModelError("", "Campo Cédula Invalido, Ingrese una cédula válida.");

                return View(laListaDeModelsPrestamoPorCedula);
            }
            catch
            {
                return View(laListaDeModelsPrestamoPorCedula);
            }

        }

      
        public ActionResult ListaDeAbonosDelPrestamoDelCliente(int id)
        {
            Convertidores.AbonoConvertidor convertidorAbonos = new Convertidores.AbonoConvertidor();
            LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos coordinadorDeAbonos;
            coordinadorDeAbonos = new LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos();

            List<Model.Abono.Abono> laListaDeTodosLosAbonosDelPrestamo = coordinadorDeAbonos.ObtenerListaDeAbonosPorIdPrestamo(id);
            List<Models.AbonoModels> listaDeModelsAbonos = convertidorAbonos.ObtenerListaConvertidaDeAbonosPorIdPrestamo(laListaDeTodosLosAbonosDelPrestamo);

            return View(listaDeModelsAbonos);
        }

        
        public ActionResult AbonarAlPrestamo(int id)
        {
            LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos coordinadorDeAbonos;
            coordinadorDeAbonos = new LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos();
            Models.AbonoModels elAbono = new Models.AbonoModels();
            elAbono.IdPrestamo = id;

            return View(elAbono);
        }

       
        [HttpPost]
        public ActionResult AbonarAlPrestamo(int id, Model.Abono.Abono nuevoAbono)
        {
            try
            {
                

                LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos coordinadorDeAbonos;
                coordinadorDeAbonos = new LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos();
                LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos coordinadorDePrestamos;
                coordinadorDePrestamos = new LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos();
                LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes;
                coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
                Model.Prestamos.Prestamos prestamo = new Model.Prestamos.Prestamos();
                prestamo = coordinadorDePrestamos.ConsultarPrestamoPorId(id);

                Convertidores.PrestamoConvertidor convertidorDePrestamos = new Convertidores.PrestamoConvertidor();

                Models.PrestamosModels elPrestamo = convertidorDePrestamos.ObtenerConvertidorDetallePrestamoEspecifico(prestamo, coordinadorDePrestamos, coordinadorDeAbonos,coordinadorDeClientes);

                if (Convert.ToDouble(nuevoAbono.Monto) <= elPrestamo.MontoPendienteDePago)
                {
                    string idUser = User.Identity.GetUserId();
                    nuevoAbono.Id_AspNetUser = idUser;
                    nuevoAbono.IdPrestamo = elPrestamo.Id;

                    coordinadorDeAbonos.AgregarUnAbono(nuevoAbono);

                    return RedirectToAction("Index");
                }

                ViewBag.Name = "Se ha producido un error al agregar el abono, el Monto Abonar al Préstamo supera el Monto Pendiente de Pago.";
                return View();
            }
            catch
            {
                return View();
            }
        }


        public ActionResult AnularAbono(int id)
        {
            LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos coordinadorDeAbonos;
            coordinadorDeAbonos = new LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos();

            Model.Abono.Abono elAbono;
            elAbono = coordinadorDeAbonos.ConsultarAbonoPorId(id);


            return View(elAbono);
        }

        // POST: Abono/Anular
        [HttpPost]
        public ActionResult AnularAbono(int id, Model.Abono.Abono abono)
        {
            try
            {
                LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos coordinadorDeAbonos;
                coordinadorDeAbonos = new LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos();

                Model.Abono.Abono elAbono = coordinadorDeAbonos.ConsultarAbonoPorId(id);

                coordinadorDeAbonos.AnularUnAbono(elAbono);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }




     
        public ActionResult DetalleAbonos(int id)

        {
            try
            {
                Convertidores.AbonoConvertidor convertidorAbono = new Convertidores.AbonoConvertidor();
                LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos coordinadorDePrestamos;
                coordinadorDePrestamos = new LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos();
                LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos coordinadorDeAbonos;
                coordinadorDeAbonos = new LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos();
                LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes;
                coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();

                Model.Abono.Abono elAbono = coordinadorDeAbonos.ConsultarAbonoPorId(id);
                Models.AbonoModels elAbonoModels = convertidorAbono.ObtenerConvertidorAbonoEspecifico(elAbono, coordinadorDePrestamos, coordinadorDeAbonos, coordinadorDeClientes);

                return View(elAbonoModels);
            }
            catch
            {
                return View();
            }

        }


        public ActionResult PrestamosPorCriterioCombinados()
        {
            LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos coordinadorDePrestamos;
            coordinadorDePrestamos = new LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos();
            LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos coordinadorDeAbonos;
            coordinadorDeAbonos = new LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos();
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes;
            coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
            Convertidores.PrestamoConvertidor convertidorPrestamos = new Convertidores.PrestamoConvertidor();

            List<Model.Prestamos.Prestamos> laListaDeTodosLosPrestamos = coordinadorDePrestamos.ObtenerListaDeTodosLosPrestamos();

            List<Models.PrestamosModels> laListaDeModelsPrestamos = convertidorPrestamos.ObtenerListaConvertidaDePrestamos(laListaDeTodosLosPrestamos, coordinadorDePrestamos, coordinadorDeAbonos, coordinadorDeClientes);
            return View(laListaDeModelsPrestamos);
        
            }
      [HttpPost]  
    public ActionResult PrestamosPorCriterioCombinados(string cedula, DateTime? fechaInicio, DateTime? fechaHasta, string estado)
    {
        try
        {
                    Filtros.PrestamosFiltros filtroDePrestamos = new Filtros.PrestamosFiltros();
                    List<Models.PrestamosModels> laListaFiltrada = filtroDePrestamos.ObternerListaFiltradaDePrestamosPorCombinaciones(cedula, fechaInicio, fechaHasta, estado);


                    return View(laListaFiltrada);
             
        }
        catch
        {
            return View();
        }

    }

    
        public ActionResult BuscarPrestamoCedulaCliente()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult BuscarPrestamoCedulaCliente(Models.PrestamosModels elPrestamo)
        {
            try
            {
                LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
                var laListaDeClientesPorCedula = coordinadorDeClientes.ObtenerListaDeClientesPorCedula(elPrestamo.CedulaCliente);
                if (laListaDeClientesPorCedula.Count != 0)
                {
                   

                    if (!string.IsNullOrEmpty(elPrestamo.CedulaCliente))
                    {

                        return RedirectToAction("ListaDePréstamosDelClientePorCedula", new { buscar = elPrestamo.CedulaCliente });
                    }
                    ViewBag.Name = "Ingrese una cédula.";
                    return View();
                }
                ViewBag.Name = "Campo Cédula Inválido, Ingrese una cédula válida.";
                return View();
            }
            catch
            {
                return View();
            }
        }




    }
}

