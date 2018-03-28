using CompraVenta.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompraVenta.UI.Convertidores
{
    public class AbonoConvertidor
    {

        public List<AbonoModels> ObtenerListaConvertidaDeAbonosPorIdPrestamo(List<Model.Abono.Abono> laListaDeTodosLosAbonosDelPrestamo) {

            List<Models.AbonoModels> listaDeModelsAbonos = new List<Models.AbonoModels>();

            foreach (var abono in laListaDeTodosLosAbonosDelPrestamo)
            {
                Models.AbonoModels elAbono = new Models.AbonoModels();

                elAbono.Id = abono.Id;
                elAbono.IdPrestamo = abono.IdPrestamo;
                elAbono.Monto = abono.Monto;
                elAbono.Estado = abono.Estado;
                elAbono.Fecha = abono.Fecha;
                elAbono.Id_AspNetUser = abono.Id_AspNetUser;

                listaDeModelsAbonos.Add(elAbono);
            }

            return listaDeModelsAbonos;

        }


        public AbonoModels ObtenerConvertidorAbonoEspecifico(Model.Abono.Abono elAbono, LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos coordinadorDePrestamos,
             LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos coordinadorDeAbonos, LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes) {

            AbonoModels modelsAbono = new AbonoModels();

            Convertidores.PrestamoConvertidor convertidorDePrestamos = new Convertidores.PrestamoConvertidor();
           
            Model.Prestamos.Prestamos elPrestamo = coordinadorDePrestamos.ConsultarPrestamoPorId(elAbono.IdPrestamo);
            Models.PrestamosModels modelsPrestamo = convertidorDePrestamos.ObtenerConvertidorDetallePrestamoEspecifico(elPrestamo, coordinadorDePrestamos,coordinadorDeAbonos, coordinadorDeClientes);

       
            modelsAbono.Id = elAbono.Id;
            modelsAbono.IdPrestamo = elAbono.IdPrestamo;
            modelsAbono.Monto = elAbono.Monto;
            modelsAbono.Estado = elAbono.Estado;
            modelsAbono.Fecha = elAbono.Fecha;
            modelsAbono.Id_AspNetUser = elAbono.Id_AspNetUser;
            modelsAbono.NombreClientes = modelsPrestamo.NombreClientes;
            modelsAbono.FechaPrestamo = modelsPrestamo.Fecha;
            modelsAbono.FechaVencimiento = modelsPrestamo.FechaVencimiento;
            modelsAbono.CantidadDias = modelsPrestamo.PlazoDiasPrestamo;
            modelsAbono.PorcentajeInteres = modelsPrestamo.PorcentajeIntereses;
            modelsAbono.MontoPendientePago = modelsPrestamo.MontoPendienteDePago;
            var context = new ApplicationDbContext();
            var usuario = context.Users.SingleOrDefault(u => u.Id == elAbono.Id_AspNetUser);
            modelsAbono.NombreUsuario = usuario.UserName;
            modelsAbono.CantidadPrestada = modelsPrestamo.CantidadPrestada;

            return modelsAbono;



        }













    }
}