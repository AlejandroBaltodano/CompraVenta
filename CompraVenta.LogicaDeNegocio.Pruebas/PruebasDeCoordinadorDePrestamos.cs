using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompraVenta.LogicaDeNegocio.Pruebas
{
    [TestClass]
    public class PruebasDeCoordinadorDePrestamos
    {
        Model.Usuario.AspNetUsers Usuario;

        [TestInitialize]
        public void CrearUnUsuario()
        {

            CoordinadorDeUsuarios.CoordinadorDeUsuarios coordiandorDeUsuarios = new CoordinadorDeUsuarios.CoordinadorDeUsuarios();

            Usuario = new Model.Usuario.AspNetUsers();
            Guid Id = new Guid();

            Usuario.Id = Id.ToString();
            Usuario.Email = "proyectoProgramda@gmail.com";
            Usuario.EmailConfirmed = false;
            Usuario.PhoneNumberConfirmed = false;
            Usuario.TwoFactorEnabled = false;
            Usuario.LockoutEnabled = false;
            Usuario.AccessFailedCount = 0;
            Usuario.UserName = "Prueba";

            coordiandorDeUsuarios.AgregarUnUsuario(Usuario);

        }

        [TestMethod]
        public void DebeDeAgregarUnPrestamo()
        {
            LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos Coordinador = new LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos();
            Model.Prestamos.Prestamos Prestamos = new Model.Prestamos.Prestamos();
            Prestamos.Id_AspNetUser = "f01aacd5-dd8c-4c4b-8280-84bacf00adb7";
            Prestamos.IdCliente = 1;
            Prestamos.CantidadPrestada = 10000;
            Prestamos.PlazoDiasPrestamo = 30;
            Prestamos.DescripcionPrenda = "TV";
            Prestamos.PorcentajeIntereses = 30;
            Coordinador.AgregarUnPrestamo(Prestamos);
        }

        [TestMethod]
        public void DebeDeConsultarPrestamoPorId()
        {
            LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos Coordinador = new LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos();
            Coordinador.ConsultarPrestamoPorId(1);
        }

        [TestMethod]
        public void DebeDeEditarUnPrestamo()
        {
            LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos Coordinador = new LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos();
            Model.Prestamos.Prestamos Prestamos = new Model.Prestamos.Prestamos();
            Prestamos = Coordinador.ConsultarPrestamoPorId(8);
            Prestamos.PlazoDiasPrestamo = 30;
            Prestamos.CantidadPrestada = 12000;
            Prestamos.DescripcionPrenda = "Laptop";

            Coordinador.EditarUnPrestamo(Prestamos);
        }

        [TestMethod]
        public void DebeDeObtenerListaDePrestamosPorEstado()
        {
            LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos Coordinador = new LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos();
            Model.Prestamos.Prestamos Prestamos = new Model.Prestamos.Prestamos();
            Coordinador.ObtenerListaDePrestamosPorEstado((int)Model.Enumerados.EstadoPrestamo.Registrado);
        }

        [TestMethod]
        public void DebeDeObtenerListaDeClientesPorCedula()
        {
            LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos Coordinador = new LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos();
            Coordinador.ObtenerListaDePrestamosPorIdCedula(1);
        }

        [TestMethod]
        public void DebeDeObtenerListaDePrestamosPorFecha()
        {
            LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos Coordinador = new LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos();
            DateTime fecha = Convert.ToDateTime("09-06-2016");
            Coordinador.ObtenerListaDePrestamosPorFecha(fecha);
        }

        [TestMethod]
        public void DebeDeObtenerListaDeTodosLosPrestamos()
        {
            LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos Coordinador = new LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos();
            Coordinador.ObtenerListaDeTodosLosPrestamos();
        }

        [TestMethod]
        public void DebeDeObtenerLaListaDelPlazoDiasPrestamo()
        {
            LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos Coordinador = new LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos();
            Coordinador.ObtenerPlazoDiasPrestamo();
        }

    }
}
