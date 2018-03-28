using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CompraVenta.LogicaDeNegocio.Pruebas
{
    [TestClass]
    public class PruebasDeCoordinadorDeClientes
    {
        Model.Usuario.AspNetUsers Usuario;

          [TestInitialize]
        public void CrearUnUsuario() {

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
        public void DebeDeAgregarUnCliente()
        {
            Model.Cliente.Clientes nuevoCliente = new Model.Cliente.Clientes();
            nuevoCliente.Id_AspNetUser = Usuario.Id;
            nuevoCliente.Cedula = "1";
            nuevoCliente.NombreCompleto = "Josue Barrantes";
            nuevoCliente.Direccion = "Peloncito";
            nuevoCliente.Telefono1 = "88880011";
            nuevoCliente.Telefono2 = "88339911";
            nuevoCliente.Email = "josueBS12@gmail.com";
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorCliente;
            coordinadorCliente = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
            coordinadorCliente.AgregarUnCliente(nuevoCliente);
        }

        [TestMethod]
        public void DebeDeConsultarClientePorId()
        {
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorCliente;
            coordinadorCliente = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
            coordinadorCliente.ConsultarClientePorId(5);
        }

        [TestMethod]
        public void DebeDeEditarUnCliente()
        {
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorCliente;
            coordinadorCliente = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
            Model.Cliente.Clientes ClienteEditado = new Model.Cliente.Clientes();
            ClienteEditado = coordinadorCliente.ConsultarClientePorId(4);
            ClienteEditado.Id_AspNetUser = Usuario.Id;
            ClienteEditado.Cedula = "1";
            ClienteEditado.NombreCompleto = "Josue Barrantes Suarez";
            ClienteEditado.Direccion = "Peloncito";
            ClienteEditado.Telefono1 = "88785643";
            ClienteEditado.Telefono2 = "88339911";
            ClienteEditado.Email = "josueBarrantesS12@gmail.com";
            coordinadorCliente.EditarUnCliente(ClienteEditado);
        }

        [TestMethod]
        public void DebeDeActivarUnCliente()
        {
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorCliente;
            coordinadorCliente = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
            Model.Cliente.Clientes ClienteEditado = new Model.Cliente.Clientes();
            ClienteEditado = coordinadorCliente.ConsultarClientePorId(4);
            coordinadorCliente.ActivarUnCliente(ClienteEditado);
        }

        [TestMethod]
        public void DebeDeInactivarUnCliente()
        {
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorCliente;
            coordinadorCliente = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
            Model.Cliente.Clientes ClienteEditado = new Model.Cliente.Clientes();
            ClienteEditado = coordinadorCliente.ConsultarClientePorId(4);
            coordinadorCliente.InactivarUnCliente(ClienteEditado);
        }

        [TestMethod]
        public void DebeDeObtenerListaDeClientesPorEstado()
        {
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorCliente;
            coordinadorCliente = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
            coordinadorCliente.ObtenerListaDeClientesPorEstado((byte)Model.Enumerados.Estado.Activo);

        }

        [TestMethod]
        public void DebeDeObtenerListaDeClientesPorCedula()
        {
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorCliente;
            coordinadorCliente = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
            coordinadorCliente.ObtenerListaDeClientesPorCedula("1");
        }

        [TestMethod]
        public void DebeDeObtenerListaDeTodosLosClientes()
        {
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorCliente;
            coordinadorCliente = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
            coordinadorCliente.ObtenerListaDeTodosLosClientes();
        }

        [TestMethod]
        public void DebeDeEnviarCorreoDeNuevoCliente()
        {
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorCliente;
            coordinadorCliente = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
            Model.Cliente.Clientes elCliente = coordinadorCliente.ConsultarClientePorId(4);
            coordinadorCliente.EnviarCorreoDeNuevoCliente("jant.gomez14@gmail.com", elCliente);
        }

        [TestMethod]
        public void DebeDeEnviarCorreoDeEdicionDeCliente()
        {
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorCliente;
            coordinadorCliente = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
            Model.Cliente.Clientes elCliente = coordinadorCliente.ConsultarClientePorId(4);
            coordinadorCliente.EnviarCorreoDeEdicionDeCliente("jant.gomez14@gmail.com", elCliente);
        }

        [TestMethod]
        public void DebeDeEnviarCorreoElectronico()
        {
            LogicaDeNegocio.CoordinadorDeUsuarios.CoordinadorDeUsuarios coordinadorUsuarios;
            coordinadorUsuarios = new CoordinadorDeUsuarios.CoordinadorDeUsuarios();
            coordinadorUsuarios.EnviarCorreoElectronico("jant.gomez14@gmail.com", "Prueba", "Pruebas del metodo enviar correo d la clase de coordinador de usuario");
        }


    }
}
