using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompraVenta.UI.Models;
using Microsoft.AspNet.Identity;


namespace CompraVenta.UI.Convertidores
    {
        public class PrestamoConvertidor
        {
            public const int DiasPlazoPrestamo30 = 30;
            public const int DiasPlazoPrestamo60 = 60;
            public const int DiasPlazoPrestamo90 = 90;
            public const double PorcentajePlazoPrestamo30 = 0.09;
            public const double PorcentajePlazoPrestamo60 = 0.20;
            public const double PorcentajePlazoPrestamo90 = 0.35;




            public List<Models.PrestamosModels> ObtenerListaConvertidaDePrestamos(List<Model.Prestamos.Prestamos> laListaDeTodosLosPrestamos, LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos coordinadorDePrestamos,
                LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos coordinadorDeAbonos, LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes)
            {
                List<Models.PrestamosModels> laListaDeModelsPrestamos = new List<Models.PrestamosModels>();


                decimal sumaDeTodosLosAbonos = 0;
                double interesDelPrestamo = 0;



                for (int i = 0; i < laListaDeTodosLosPrestamos.Count; i++)
                {
                    Models.PrestamosModels modelsPrestamo = new Models.PrestamosModels();
                    sumaDeTodosLosAbonos = 0;
                    interesDelPrestamo = 0;

                    modelsPrestamo.Id = laListaDeTodosLosPrestamos[i].Id;
                    modelsPrestamo.IdCliente = laListaDeTodosLosPrestamos[i].IdCliente;
                    modelsPrestamo.Fecha = laListaDeTodosLosPrestamos[i].Fecha;
                    modelsPrestamo.CantidadPrestada = laListaDeTodosLosPrestamos[i].CantidadPrestada;
                    modelsPrestamo.PorcentajeIntereses = laListaDeTodosLosPrestamos[i].PorcentajeIntereses;
                    modelsPrestamo.PlazoDiasPrestamo = laListaDeTodosLosPrestamos[i].PlazoDiasPrestamo;
                    modelsPrestamo.Id_AspNetUser = laListaDeTodosLosPrestamos[i].Id_AspNetUser;
                    modelsPrestamo.DescripcionPrenda = laListaDeTodosLosPrestamos[i].DescripcionPrenda;
                    modelsPrestamo.Estado = laListaDeTodosLosPrestamos[i].Estado;


                    Model.Cliente.Clientes elCliente = coordinadorDeClientes.ConsultarClientePorId(modelsPrestamo.IdCliente);
                    modelsPrestamo.CedulaCliente = elCliente.Cedula;
                    modelsPrestamo.NombreClientes = elCliente.NombreCompleto;
                    modelsPrestamo.Email = elCliente.Email;
                    modelsPrestamo.AbonosDelPrestamo = coordinadorDeAbonos.ObtenerListaDeAbonosPorIdPrestamo(modelsPrestamo.Id);

                    foreach (var abono in modelsPrestamo.AbonosDelPrestamo)
                    {
                        if (abono.Estado == (int)Model.Enumerados.EstadoAbono.Registrado)
                        {
                            sumaDeTodosLosAbonos += abono.Monto;
                        }

                    }
                    interesDelPrestamo = Convert.ToDouble(modelsPrestamo.CantidadPrestada) * modelsPrestamo.PorcentajeIntereses;

                    modelsPrestamo.MontoPendienteDePago = (Convert.ToDouble(modelsPrestamo.CantidadPrestada) + interesDelPrestamo) - Convert.ToDouble(sumaDeTodosLosAbonos);

                    laListaDeModelsPrestamos.Add(modelsPrestamo);

                }


                return laListaDeModelsPrestamos;
            }

            public List<PrestamosModels> ObtenerListaConvertidaDePrestamosPorCedulaCliente(string buscar, List<Model.Cliente.Clientes> laListaDeLosClientesPorCedula, LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos coordinadorDePrestamos,
                LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos coordinadorDeAbonos, LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes)
            {

                List<Models.PrestamosModels> laListaDeModelsPrestamoPorCedula = new List<Models.PrestamosModels>();
                decimal sumaDeTodosLosAbonos = 0;
                double interesDelPrestamo = 0;
                string cedula = buscar;

                Model.Cliente.Clientes nuevoCliente = new Model.Cliente.Clientes();
                foreach (var cliente in laListaDeLosClientesPorCedula)
                {
                    if (cedula == cliente.Cedula)
                    {
                        nuevoCliente = cliente;
                    }
                }

                var laListaDeTodosLosPrestamos = coordinadorDePrestamos.ObtenerListaDePrestamosPorIdCedula(nuevoCliente.Id);

                foreach (Model.Prestamos.Prestamos elPrestamo in laListaDeTodosLosPrestamos)
                {
                    Models.PrestamosModels modelsPrestamo = new Models.PrestamosModels();
                    sumaDeTodosLosAbonos = 0;
                    interesDelPrestamo = 0;

                    modelsPrestamo.Id = elPrestamo.Id;
                    modelsPrestamo.IdCliente = elPrestamo.IdCliente;
                    modelsPrestamo.Fecha = elPrestamo.Fecha;
                    modelsPrestamo.CantidadPrestada = elPrestamo.CantidadPrestada;
                    modelsPrestamo.PorcentajeIntereses = elPrestamo.PorcentajeIntereses;
                    modelsPrestamo.PlazoDiasPrestamo = elPrestamo.PlazoDiasPrestamo;
                    modelsPrestamo.Id_AspNetUser = elPrestamo.Id_AspNetUser;
                    modelsPrestamo.DescripcionPrenda = elPrestamo.DescripcionPrenda;
                    modelsPrestamo.Estado = elPrestamo.Estado;


                    Model.Cliente.Clientes elCliente = coordinadorDeClientes.ConsultarClientePorId(modelsPrestamo.IdCliente);
                    modelsPrestamo.CedulaCliente = elCliente.Cedula;
                    modelsPrestamo.NombreClientes = elCliente.NombreCompleto;
                    modelsPrestamo.AbonosDelPrestamo = coordinadorDeAbonos.ObtenerListaDeAbonosPorIdPrestamo(modelsPrestamo.Id);

                    foreach (var abono in modelsPrestamo.AbonosDelPrestamo)
                    {
                        if (abono.Estado == (int)Model.Enumerados.EstadoAbono.Registrado)
                        {
                            sumaDeTodosLosAbonos += abono.Monto;
                        }
                    }
                    interesDelPrestamo = Convert.ToDouble(modelsPrestamo.CantidadPrestada) * modelsPrestamo.PorcentajeIntereses;

                    modelsPrestamo.MontoPendienteDePago = (Convert.ToDouble(modelsPrestamo.CantidadPrestada) + interesDelPrestamo) - Convert.ToDouble(sumaDeTodosLosAbonos);



                    laListaDeModelsPrestamoPorCedula.Add(modelsPrestamo);

                }


                return laListaDeModelsPrestamoPorCedula;
            }



            public List<Models.PrestamosModels> ObtenerListaConvertidaDePrestamosPorFecha(DateTime fecha, LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes,
                LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos coordinadorDePrestamos, LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos coordinadorDeAbonos)
            {

                List<Models.PrestamosModels> laListaDeModelsPrestamoPorFecha = new List<Models.PrestamosModels>();

                decimal sumaDeTodosLosAbonos = 0;
                double interesDelPrestamo = 0;

                List<Model.Prestamos.Prestamos> laListaDeTodosLosPrestamos = new List<Model.Prestamos.Prestamos>();
                laListaDeTodosLosPrestamos = coordinadorDePrestamos.ObtenerListaDePrestamosPorFecha(fecha);

                foreach (Model.Prestamos.Prestamos elPrestamo in laListaDeTodosLosPrestamos)
                {
                    Models.PrestamosModels modelsPrestamo = new Models.PrestamosModels();
                    sumaDeTodosLosAbonos = 0;
                    interesDelPrestamo = 0;

                    modelsPrestamo.Id = elPrestamo.Id;
                    modelsPrestamo.IdCliente = elPrestamo.IdCliente;
                    modelsPrestamo.Fecha = elPrestamo.Fecha;
                    modelsPrestamo.CantidadPrestada = elPrestamo.CantidadPrestada;
                    modelsPrestamo.PorcentajeIntereses = elPrestamo.PorcentajeIntereses;
                    modelsPrestamo.PlazoDiasPrestamo = elPrestamo.PlazoDiasPrestamo;
                    modelsPrestamo.Id_AspNetUser = elPrestamo.Id_AspNetUser;
                    modelsPrestamo.DescripcionPrenda = elPrestamo.DescripcionPrenda;
                    modelsPrestamo.Estado = elPrestamo.Estado;


                    Model.Cliente.Clientes elCliente = coordinadorDeClientes.ConsultarClientePorId(modelsPrestamo.IdCliente);
                    modelsPrestamo.CedulaCliente = elCliente.Cedula;
                    modelsPrestamo.NombreClientes = elCliente.NombreCompleto;
                    modelsPrestamo.AbonosDelPrestamo = coordinadorDeAbonos.ObtenerListaDeAbonosPorIdPrestamo(modelsPrestamo.Id);

                    foreach (var abono in modelsPrestamo.AbonosDelPrestamo)
                    {
                        if (abono.Estado == (int)Model.Enumerados.EstadoAbono.Registrado)
                        {
                            sumaDeTodosLosAbonos += abono.Monto;
                        }
                    }
                    interesDelPrestamo = Convert.ToDouble(modelsPrestamo.CantidadPrestada) * modelsPrestamo.PorcentajeIntereses;

                    modelsPrestamo.MontoPendienteDePago = (Convert.ToDouble(modelsPrestamo.CantidadPrestada) + interesDelPrestamo) - Convert.ToDouble(sumaDeTodosLosAbonos);



                    laListaDeModelsPrestamoPorFecha.Add(modelsPrestamo);

                }


                return laListaDeModelsPrestamoPorFecha;
            }

            public List<Models.PrestamosModels> ObtenerListaConvertidaDePrestamosParaEstado(DateTime fecha, LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes,
       LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos coordinadorDePrestamos, LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos coordinadorDeAbonos)
            {

                List<Models.PrestamosModels> laListaDeModelsPrestamoPorFecha = new List<Models.PrestamosModels>();


                decimal sumaDeTodosLosAbonos = 0;
                double interesDelPrestamo = 0;
                List<Model.Prestamos.Prestamos> laListaDeTodosLosPrestamos = new List<Model.Prestamos.Prestamos>();




                laListaDeTodosLosPrestamos = coordinadorDePrestamos.ObtenerListaDePrestamosParaEstado(fecha);

                foreach (Model.Prestamos.Prestamos elPrestamo in laListaDeTodosLosPrestamos)
                {
                    Models.PrestamosModels modelsPrestamo = new Models.PrestamosModels();
                    sumaDeTodosLosAbonos = 0;
                    interesDelPrestamo = 0;

                    modelsPrestamo.Id = elPrestamo.Id;
                    modelsPrestamo.IdCliente = elPrestamo.IdCliente;
                    modelsPrestamo.Fecha = elPrestamo.Fecha;
                    modelsPrestamo.CantidadPrestada = elPrestamo.CantidadPrestada;
                    modelsPrestamo.PorcentajeIntereses = elPrestamo.PorcentajeIntereses;
                    modelsPrestamo.PlazoDiasPrestamo = elPrestamo.PlazoDiasPrestamo;
                    modelsPrestamo.Id_AspNetUser = elPrestamo.Id_AspNetUser;
                    modelsPrestamo.DescripcionPrenda = elPrestamo.DescripcionPrenda;
                    modelsPrestamo.Estado = elPrestamo.Estado;


                    Model.Cliente.Clientes elCliente = coordinadorDeClientes.ConsultarClientePorId(modelsPrestamo.IdCliente);
                    modelsPrestamo.CedulaCliente = elCliente.Cedula;
                    modelsPrestamo.NombreClientes = elCliente.NombreCompleto;
                    modelsPrestamo.AbonosDelPrestamo = coordinadorDeAbonos.ObtenerListaDeAbonosPorIdPrestamo(modelsPrestamo.Id);

                    foreach (var abono in modelsPrestamo.AbonosDelPrestamo)
                    {
                        if (abono.Estado == (int)Model.Enumerados.EstadoAbono.Registrado)
                        {
                            sumaDeTodosLosAbonos += abono.Monto;
                        }
                    }
                    interesDelPrestamo = Convert.ToDouble(modelsPrestamo.CantidadPrestada) * modelsPrestamo.PorcentajeIntereses;

                    modelsPrestamo.MontoPendienteDePago = (Convert.ToDouble(modelsPrestamo.CantidadPrestada) + interesDelPrestamo) - Convert.ToDouble(sumaDeTodosLosAbonos);



                    laListaDeModelsPrestamoPorFecha.Add(modelsPrestamo);

                }


                return laListaDeModelsPrestamoPorFecha;
            }




            public Models.PrestamosModels ObtenerConvertidorDetallePrestamoEspecifico(Model.Prestamos.Prestamos prestamo, LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos coordinadorDePrestamos, LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos coordinadorDeAbonos, LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes)
            {
                Models.PrestamosModels modelsPrestamo = new PrestamosModels();


                decimal sumaDeTodosLosAbonos = 0;
                double interesDelPrestamo = 0;


                modelsPrestamo.Id = prestamo.Id;
                modelsPrestamo.IdCliente = prestamo.IdCliente;
                modelsPrestamo.Fecha = prestamo.Fecha;
                modelsPrestamo.CantidadPrestada = prestamo.CantidadPrestada;
                modelsPrestamo.PorcentajeIntereses = prestamo.PorcentajeIntereses;
                modelsPrestamo.PlazoDiasPrestamo = prestamo.PlazoDiasPrestamo;
                modelsPrestamo.Id_AspNetUser = prestamo.Id_AspNetUser;
                modelsPrestamo.DescripcionPrenda = prestamo.DescripcionPrenda;
                modelsPrestamo.Estado = prestamo.Estado;

                var context = new ApplicationDbContext();
                var usuario = context.Users.SingleOrDefault(u => u.Id == modelsPrestamo.Id_AspNetUser);
                modelsPrestamo.NombreUsuario = usuario.UserName;

                Model.Cliente.Clientes elCliente = coordinadorDeClientes.ConsultarClientePorId(modelsPrestamo.IdCliente);
                modelsPrestamo.CedulaCliente = elCliente.Cedula;
                modelsPrestamo.NombreClientes = elCliente.NombreCompleto;
                modelsPrestamo.AbonosDelPrestamo = coordinadorDeAbonos.ObtenerListaDeAbonosPorIdPrestamo(modelsPrestamo.Id);

                foreach (var abono in modelsPrestamo.AbonosDelPrestamo)
                {
                    if (abono.Estado == (int)Model.Enumerados.EstadoAbono.Registrado)
                    {
                        sumaDeTodosLosAbonos += abono.Monto;
                    }

                }
                interesDelPrestamo = Convert.ToDouble(modelsPrestamo.CantidadPrestada) * modelsPrestamo.PorcentajeIntereses;

                modelsPrestamo.MontoPendienteDePago = (Convert.ToDouble(modelsPrestamo.CantidadPrestada) + interesDelPrestamo) - Convert.ToDouble(sumaDeTodosLosAbonos);

                return modelsPrestamo;

            }

            public Model.Prestamos.Prestamos ObtenerConvertidorPrestamosPorPrestamoModelsCrear(Models.PrestamosModels elPrestamo, LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes)
            {
                Model.Prestamos.Prestamos elNuevoPrestamo = new Model.Prestamos.Prestamos();



                var listaDeClientesPorCedula = coordinadorDeClientes.ObtenerListaDeClientesPorCedula(elPrestamo.CedulaCliente);

                foreach (var cliente in listaDeClientesPorCedula)
                {
                    if (cliente.Cedula == elPrestamo.CedulaCliente)
                    {
                        elNuevoPrestamo.IdCliente = cliente.Id;

                    }
                }

                elNuevoPrestamo.CantidadPrestada = elPrestamo.CantidadPrestada;

                if (elPrestamo.PlazoDiasPrestamo == DiasPlazoPrestamo30)
                {
                    elNuevoPrestamo.PorcentajeIntereses = PorcentajePlazoPrestamo30;
                    elNuevoPrestamo.PlazoDiasPrestamo = elPrestamo.PlazoDiasPrestamo;
                }
                else if (elPrestamo.PlazoDiasPrestamo == DiasPlazoPrestamo60)
                {
                    elNuevoPrestamo.PorcentajeIntereses = PorcentajePlazoPrestamo60;
                    elNuevoPrestamo.PlazoDiasPrestamo = elPrestamo.PlazoDiasPrestamo;
                }
                else
                {
                    elNuevoPrestamo.PorcentajeIntereses = PorcentajePlazoPrestamo90;
                    elNuevoPrestamo.PlazoDiasPrestamo = elPrestamo.PlazoDiasPrestamo;
                }


                elNuevoPrestamo.DescripcionPrenda = elPrestamo.DescripcionPrenda;

                return elNuevoPrestamo;
            }


            public Models.PrestamosModels ObtenerConvertidorPrestamoPorId(Model.Prestamos.Prestamos elPrestamo, LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos coordinadorDePrestamos,
            Model.Cliente.Clientes clienteDelPrestamo)
            {

                Models.PrestamosModels model = new Models.PrestamosModels();


                model.Id = elPrestamo.Id;
                model.IdCliente = elPrestamo.IdCliente;
                model.Fecha = elPrestamo.Fecha;
                model.CantidadPrestada = elPrestamo.CantidadPrestada;
                model.PlazoDiasPrestamo = elPrestamo.PlazoDiasPrestamo;
                model.Id_AspNetUser = elPrestamo.Id_AspNetUser;
                model.DescripcionPrenda = elPrestamo.DescripcionPrenda;
                model.Estado = elPrestamo.Estado;

                model.CedulaCliente = clienteDelPrestamo.Cedula;
                model.laListaDePlazoDiasPrestamo = coordinadorDePrestamos.ObtenerPlazoDiasPrestamo();



                return model;
            }


            public Model.Prestamos.Prestamos ObtenerConvertidorPrestamosPorPrestamoModelsEditar(int id, Models.PrestamosModels elPrestamo, List<Model.Cliente.Clientes> listaDeClientesPorCedula, LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos coordinadorDePrestamos)
            {
               
            

                Model.Prestamos.Prestamos elNuevoPrestamo = new Model.Prestamos.Prestamos();
                elNuevoPrestamo = coordinadorDePrestamos.ConsultarPrestamoPorId(id);


                foreach (var cliente in listaDeClientesPorCedula)
                {
                    if (cliente.Cedula == elPrestamo.CedulaCliente)
                    {
                        elNuevoPrestamo.IdCliente = cliente.Id;
                    }
                }

                elNuevoPrestamo.CantidadPrestada = elPrestamo.CantidadPrestada;

                if (elPrestamo.PlazoDiasPrestamo == DiasPlazoPrestamo30)
                {
                    elNuevoPrestamo.PorcentajeIntereses = PorcentajePlazoPrestamo30;
                    elNuevoPrestamo.PlazoDiasPrestamo = elPrestamo.PlazoDiasPrestamo;
                }
                else if (elPrestamo.PlazoDiasPrestamo == DiasPlazoPrestamo60)
                {
                    elNuevoPrestamo.PorcentajeIntereses = PorcentajePlazoPrestamo60;
                    elNuevoPrestamo.PlazoDiasPrestamo = elPrestamo.PlazoDiasPrestamo;
                }
                else
                {
                    elNuevoPrestamo.PorcentajeIntereses = PorcentajePlazoPrestamo90;
                    elNuevoPrestamo.PlazoDiasPrestamo = elPrestamo.PlazoDiasPrestamo;
                }


                elNuevoPrestamo.DescripcionPrenda = elPrestamo.DescripcionPrenda;

                return elNuevoPrestamo;

            }



            public void ObtenerListaDePrestamosVencidos()
        {

            LogicaDeNegocio.CoordinadorDeUsuarios.CoordinadorDeUsuarios coordinadorDeUsuarios = new LogicaDeNegocio.CoordinadorDeUsuarios.CoordinadorDeUsuarios();
            LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos coordinadorDeAbonos = new LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos();
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
            LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos coordinadorDePrestamos = new LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos();
            List<Model.Prestamos.Prestamos> laListaDePrestamo = new List<Model.Prestamos.Prestamos>();
            CompraVenta.UI.Convertidores.PrestamoConvertidor convertidorPrestamos = new UI.Convertidores.PrestamoConvertidor();
            List<Model.Prestamos.Prestamos> laListaDeTodosLosPrestamos = coordinadorDePrestamos.ObtenerListaDeTodosLosPrestamos();
            List<CompraVenta.UI.Models.PrestamosModels> laListaConvertida = convertidorPrestamos.ObtenerListaConvertidaDePrestamos(laListaDeTodosLosPrestamos, coordinadorDePrestamos, coordinadorDeAbonos, coordinadorDeClientes);

            foreach (var prestamo in laListaConvertida)
            {
               
                DateTime tiempoVencido = new DateTime();
                tiempoVencido = prestamo.FechaVencimiento;

                if ((tiempoVencido.Date < DateTime.Now.Date) && prestamo.Estado==(int)Model.Enumerados.EstadoPrestamo.Registrado && (prestamo.MontoPendienteDePago != 0))
                {
                    laListaDePrestamo = coordinadorDePrestamos.ObtenerListaDePrestamoPorId(prestamo.Id);
                    foreach (Model.Prestamos.Prestamos elPrestamo in laListaDePrestamo)
                    {
                        coordinadorDePrestamos.PonerPrestamoEnVencido(elPrestamo);
                    }
                    Model.Cliente.Clientes cliente = coordinadorDeClientes.ConsultarClientePorId(prestamo.IdCliente);

                    string Asunto = "Su préstamo [" + prestamo.Id + "] se venció.";
                    string Cuerpo = "Estimado [" +  prestamo.NombreClientes + "],\n" +
                   "su préstamo[" + prestamo.Id + "], por el monto de[" + Convert.ToDecimal(prestamo.CantidadPrestada) + "],\n" +
                   "con un monto pendiente de[" + Convert.ToDecimal(prestamo.MontoPendienteDePago) + "], se venció, por lo tanto los bienes prendados pasaran a ser parte de los activos de la empresa.";

                    coordinadorDeUsuarios.EnviarCorreoElectronico(cliente.Email, Asunto, Cuerpo);
                }
            }

        }



        public void ObtenerListaDePrestamosProximosASuVencimiento()
        {
            const int avisoDiasDeVencimiento = 10;
            LogicaDeNegocio.CoordinadorDeUsuarios.CoordinadorDeUsuarios coordinadorDeUsuarios = new LogicaDeNegocio.CoordinadorDeUsuarios.CoordinadorDeUsuarios();
            LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos coordinadorDeAbonos = new LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos();
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
            LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos coordinadorDePrestamos = new LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos();
            List<CompraVenta.UI.Models.PrestamosModels> laListaDePrestamosVencidos = new List<UI.Models.PrestamosModels>();

            PrestamoConvertidor convertidorPrestamos = new PrestamoConvertidor();
            List<Model.Prestamos.Prestamos> laListaDeTodosLosPrestamos = coordinadorDePrestamos.ObtenerListaDeTodosLosPrestamos();
            List<CompraVenta.UI.Models.PrestamosModels> laListaConvertida = convertidorPrestamos.ObtenerListaConvertidaDePrestamos(laListaDeTodosLosPrestamos, coordinadorDePrestamos, coordinadorDeAbonos, coordinadorDeClientes);

            foreach (var prestamo in laListaConvertida)
            {
                if (prestamo.Estado == (int)Model.Enumerados.EstadoPrestamo.Registrado && prestamo.MontoPendienteDePago != 0)
                {
                    TimeSpan tiempoParaVencer = new TimeSpan();
                    tiempoParaVencer = prestamo.FechaVencimiento.Date - DateTime.Now.Date;
                    if (tiempoParaVencer.Days <= avisoDiasDeVencimiento && (tiempoParaVencer.Days > 0))
                    {
                        Model.Cliente.Clientes cliente = coordinadorDeClientes.ConsultarClientePorId(prestamo.IdCliente);

                        string Asunto = "Su préstamo está a [ " + tiempoParaVencer.Days + " ] días por vencer.";
                        string Cuerpo = "Estimado [" + prestamo.NombreClientes + "]," + "\nsu préstamo [" + prestamo.Id + "] " + " por el monto de [" + prestamo.CantidadPrestada + "], con un monto pendiente de [" + prestamo.MontoPendienteDePago + "]," +
                           "está a [ " + tiempoParaVencer.Days + " ], por favor programar su pago lo más próximo posible.";

                        coordinadorDeUsuarios.EnviarCorreoElectronico(cliente.Email, Asunto, Cuerpo);
                    }
                     

                }
            }

        }




    }
}