using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompraVenta.UI.Filtros
{
    public class PrestamosFiltros
    {
        public List<Models.PrestamosModels> ObternerListaFiltradaDePrestamosPorCombinaciones(string cedula, DateTime? fechaInicio, DateTime? fechaHasta, string estado) {

            Convertidores.PrestamoConvertidor convertidorDePrestamos = new Convertidores.PrestamoConvertidor();
            List<Models.PrestamosModels> laListaPrestamoAFiltrar = new List<Models.PrestamosModels>();
            List<Models.PrestamosModels> laListaPrestamoFiltrada = new List<Models.PrestamosModels>();
          

            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes;
            coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
            LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos coordinadorDePrestamos;
            coordinadorDePrestamos = new LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos();

            List<Model.Cliente.Clientes> laListaDeLosClientesPorCedula = new List<Model.Cliente.Clientes>();

            LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos coordinadorDeAbonos = new LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos();

            laListaDeLosClientesPorCedula = coordinadorDeClientes.ObtenerListaDeClientesPorCedula(cedula);



            if (!string.IsNullOrEmpty(cedula) && fechaInicio != null && fechaHasta != null && estado != "--")
            {
                laListaPrestamoAFiltrar = convertidorDePrestamos.ObtenerListaConvertidaDePrestamosPorCedulaCliente(cedula,laListaDeLosClientesPorCedula,coordinadorDePrestamos,coordinadorDeAbonos,coordinadorDeClientes);
                if (estado == "Vencido")
                {
                    foreach (var prestamo in laListaPrestamoAFiltrar)
                    {
                        DateTime fechaLimite = prestamo.FechaVencimiento;
                        if ((prestamo.CedulaCliente == cedula) && (prestamo.Fecha.Date >= fechaInicio) && (prestamo.Fecha.Date <= fechaHasta) && (fechaLimite.Date < DateTime.Now.Date))
                        {
                            laListaPrestamoFiltrada.Add(prestamo);
                        }
                    }
                }
                else if (estado == "NoVencido")
                {
                    foreach (var prestamo in laListaPrestamoAFiltrar)
                    {
                        DateTime fechaLimite = prestamo.FechaVencimiento;
                        if ((prestamo.CedulaCliente == cedula) && (prestamo.Fecha.Date >= fechaInicio) && (prestamo.Fecha.Date <= fechaHasta) && (fechaLimite.Date > DateTime.Now.Date))
                        {
                            laListaPrestamoFiltrada.Add(prestamo);
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(cedula) && fechaInicio != null && fechaHasta != null && estado == "--")
            {

                laListaPrestamoAFiltrar = convertidorDePrestamos.ObtenerListaConvertidaDePrestamosPorCedulaCliente(cedula, laListaDeLosClientesPorCedula, coordinadorDePrestamos, coordinadorDeAbonos, coordinadorDeClientes);
                foreach (var prestamo in laListaPrestamoAFiltrar)
                {
                    if ((prestamo.CedulaCliente == cedula) && (prestamo.Fecha.Date >= fechaInicio) && (prestamo.Fecha.Date <= fechaHasta))
                    {
                        laListaPrestamoFiltrada.Add(prestamo);
                    }
                }
            }

            if (!string.IsNullOrEmpty(cedula) && fechaInicio == null && fechaHasta == null && estado != "--")
            {
                laListaPrestamoAFiltrar = convertidorDePrestamos.ObtenerListaConvertidaDePrestamosPorCedulaCliente(cedula, laListaDeLosClientesPorCedula, coordinadorDePrestamos, coordinadorDeAbonos, coordinadorDeClientes);
                if (estado == "Vencido")
                {
                    foreach (var prestamo in laListaPrestamoAFiltrar)
                    {
                        DateTime fechaLimite = prestamo.FechaVencimiento;
                        if ((prestamo.CedulaCliente == cedula) && (fechaLimite.Date < DateTime.Now.Date))
                        {
                            laListaPrestamoFiltrada.Add(prestamo);
                        }
                    }
                }
                else if (estado == "NoVencido")
                {
                    foreach (var prestamo in laListaPrestamoAFiltrar)
                    {
                        DateTime fechaLimite = prestamo.FechaVencimiento;
                        if ((prestamo.CedulaCliente == cedula) && (fechaLimite.Date > DateTime.Now.Date))
                        {
                            laListaPrestamoFiltrada.Add(prestamo);
                        }
                    }
                }
            }


            if (!string.IsNullOrEmpty(cedula) && fechaInicio == null && fechaHasta == null && estado == "--")
            {
                laListaPrestamoAFiltrar = convertidorDePrestamos.ObtenerListaConvertidaDePrestamosPorCedulaCliente(cedula, laListaDeLosClientesPorCedula, coordinadorDePrestamos, coordinadorDeAbonos, coordinadorDeClientes);
                foreach (var prestamo in laListaPrestamoAFiltrar)
                {

                    if (prestamo.CedulaCliente == cedula)
                    {
                        laListaPrestamoFiltrada.Add(prestamo);
                    }
                }

            }

            if (string.IsNullOrEmpty(cedula) && fechaInicio != null && fechaHasta != null && estado != "--")
            {
                laListaPrestamoAFiltrar = convertidorDePrestamos.ObtenerListaConvertidaDePrestamosPorFecha(fechaInicio.Value.Date, coordinadorDeClientes, coordinadorDePrestamos, coordinadorDeAbonos);
                if (estado == "Vencido")
                {
                    foreach (var prestamo in laListaPrestamoAFiltrar)
                    {
                        DateTime fechaLimite = prestamo.FechaVencimiento;
                        if ((prestamo.Fecha.Date >= fechaInicio) && (prestamo.Fecha.Date <= fechaHasta) && (fechaLimite.Date < DateTime.Now.Date))
                        {
                            laListaPrestamoFiltrada.Add(prestamo);
                        }
                    }
                }
                else if (estado == "NoVencido")
                {
                    foreach (var prestamo in laListaPrestamoAFiltrar)
                    {
                        DateTime fechaLimite = prestamo.FechaVencimiento;
                        if ((prestamo.Fecha.Date >= fechaInicio) && (prestamo.Fecha.Date <= fechaHasta) && (fechaLimite.Date > DateTime.Now.Date))
                        {
                            laListaPrestamoFiltrada.Add(prestamo);
                        }
                    }
                }
            }


            if (string.IsNullOrEmpty(cedula) && fechaInicio != null && fechaHasta != null && estado == "--")
            {
                laListaPrestamoAFiltrar = convertidorDePrestamos.ObtenerListaConvertidaDePrestamosPorFecha(fechaInicio.Value.Date,coordinadorDeClientes,coordinadorDePrestamos,coordinadorDeAbonos);
                foreach (var prestamo in laListaPrestamoAFiltrar)
                {

                    if ((prestamo.Fecha.Date >= fechaInicio) && (prestamo.Fecha.Date <= fechaHasta))
                    {
                        laListaPrestamoFiltrada.Add(prestamo);
                    }
                }
            }

            if (string.IsNullOrEmpty(cedula) && fechaInicio == null && fechaHasta == null && estado != "--")
            {
                laListaPrestamoAFiltrar = convertidorDePrestamos.ObtenerListaConvertidaDePrestamosParaEstado(DateTime.Now, coordinadorDeClientes,coordinadorDePrestamos,coordinadorDeAbonos);

                if (estado == "Vencido")
                {
                    foreach (var prestamo in laListaPrestamoAFiltrar)
                    {
                        DateTime fechaLimite = prestamo.FechaVencimiento;
                        if (fechaLimite.Date < DateTime.Now.Date)
                        {
                            laListaPrestamoFiltrada.Add(prestamo);
                        }
                    }
                }
                else if (estado == "NoVencido")
                {
                    foreach (var prestamo in laListaPrestamoAFiltrar)
                    {
                        DateTime fechaLimite = prestamo.FechaVencimiento;
                        if (fechaLimite.Date > DateTime.Now.Date)
                        {
                            laListaPrestamoFiltrada.Add(prestamo);
                        }
                    }
                }
            }

            return laListaPrestamoFiltrada;


        }






    }
}