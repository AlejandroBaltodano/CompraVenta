using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompraVenta.LogicaDeNegocio.Pruebas
{
    /// <summary>
    /// Descripción resumida de PruebasDeCoordinadorDeAbonos
    /// </summary>
    [TestClass]
    public class PruebasDeCoordinadorDeAbonos
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
        public void DebeDeAgregarUnAbono()
        {
            LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos coordinador = new CoordinadorDeAbonos.CoordinadorDeAbonos();
            Model.Abono.Abono abonoNuevo = new Model.Abono.Abono();
            abonoNuevo.IdPrestamo = 8;
            abonoNuevo.Monto = 10000;
            abonoNuevo.Id_AspNetUser = Usuario.Id;
            coordinador.AgregarUnAbono(abonoNuevo);
        }

        [TestMethod]
        public void DebeDeConsultarAbonoPorId()
        {
            LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos coordinador = new CoordinadorDeAbonos.CoordinadorDeAbonos();
            coordinador.ConsultarAbonoPorId(1);
        }

        [TestMethod]
        public void DebeDeAnularUnAbono()
        {
            LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos coordinador = new CoordinadorDeAbonos.CoordinadorDeAbonos();
            Model.Abono.Abono abono = new Model.Abono.Abono();
            abono = coordinador.ConsultarAbonoPorId(1);
            coordinador.AnularUnAbono(abono);
        }

        [TestMethod]
        public void DebeDeObtenerListaDeAbonosPorIdPrestamo()
        {
            LogicaDeNegocio.CoordinadorDeAbonos.CoordinadorDeAbonos coordinador = new CoordinadorDeAbonos.CoordinadorDeAbonos();
            coordinador.ObtenerListaDeAbonosPorIdPrestamo(8);
        }
    }
}
