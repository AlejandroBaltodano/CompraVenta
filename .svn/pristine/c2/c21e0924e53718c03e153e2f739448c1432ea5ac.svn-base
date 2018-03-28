using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CompraVenta.LogicaDeNegocio.CoordinadorDeClientes
{
    public class CoordinadorDeClientes
    {


        public void AgregarUnCliente(Model.Cliente.Clientes nuevoCliente)
        {
            AccesoADatos.GestorDeClientes.GestorDeClientes gestorDeClientes = new AccesoADatos.GestorDeClientes.GestorDeClientes();

            nuevoCliente.Estado = (byte)Model.Enumerados.Estado.Activo;
            gestorDeClientes.AgregarUnCliente(nuevoCliente);

        }

        public Model.Cliente.Clientes ConsultarClientePorId(int id)
        {
            AccesoADatos.GestorDeClientes.GestorDeClientes gestorDeClientes = new AccesoADatos.GestorDeClientes.GestorDeClientes();
            return gestorDeClientes.ObtenerListaDeClientesPorId(id);
        }


        public void EditarUnCliente(Model.Cliente.Clientes elCliente)
        {
            AccesoADatos.GestorDeClientes.GestorDeClientes gestorDeClientes = new AccesoADatos.GestorDeClientes.GestorDeClientes();

            if (elCliente.Estado == (byte)Model.Enumerados.Estado.Activo)
            {
                gestorDeClientes.ActualizarUnCliente(elCliente);
            }

        }

        public void ActivarUnCliente(Model.Cliente.Clientes elCliente)
        {

            AccesoADatos.GestorDeClientes.GestorDeClientes gestorDeClientes = new AccesoADatos.GestorDeClientes.GestorDeClientes();

            if (elCliente.Estado == (byte)Model.Enumerados.Estado.Inactivo)
            {
                elCliente.Estado = (byte)Model.Enumerados.Estado.Activo;
                gestorDeClientes.ActivarUnCliente(elCliente);
            }
        }

        public void InactivarUnCliente(Model.Cliente.Clientes elCliente)
        {

            AccesoADatos.GestorDeClientes.GestorDeClientes gestorDeClientes = new AccesoADatos.GestorDeClientes.GestorDeClientes();

            if (elCliente.Estado == (byte)Model.Enumerados.Estado.Activo)
            {
                elCliente.Estado = (byte)Model.Enumerados.Estado.Inactivo;
                gestorDeClientes.InactivarUnCliente(elCliente);
            }
        }


        public List<Model.Cliente.Clientes> ObtenerListaDeClientesPorEstado(byte estado)
        {
            AccesoADatos.GestorDeClientes.GestorDeClientes gestorDeClientes = new AccesoADatos.GestorDeClientes.GestorDeClientes();
            return gestorDeClientes.ObtenerListaDeClientesPorEstado(estado);

        }
        public List<Model.Cliente.Clientes> ObtenerListaDeClientesPorCedula(string cedula)
        {
            AccesoADatos.GestorDeClientes.GestorDeClientes gestorDeClientes = new AccesoADatos.GestorDeClientes.GestorDeClientes();
            return gestorDeClientes.ObtenerListaDeClientesPorCedula(cedula);

        }
        public List<Model.Cliente.Clientes> ObtenerListaDeTodosLosClientes()
        {
            AccesoADatos.GestorDeClientes.GestorDeClientes gestorDeClientes = new AccesoADatos.GestorDeClientes.GestorDeClientes();

            return gestorDeClientes.ObtenerListaDeTodosLosClientes();

        }


        public void EnviarCorreoDeNuevoCliente(string Destino, Model.Cliente.Clientes cliente)
        {
            string Asunto = "Cliente creado.";
            string Cuerpo = "Se ha creado un registro de cliente con los siguientes datos:" + "\nCedula: " + cliente.Cedula + "\nNombre Completo: " +
                            cliente.NombreCompleto + "\nDireccion: " + cliente.Direccion +
                            "\nTelefono: " + cliente.Telefono1 + "\nSegundo Telefono:" + cliente.Telefono2 + "\nCorreo electronico:" + cliente.Email;


            System.Net.Mail.MailMessage enviarCorreoElectronico = new System.Net.Mail.MailMessage();

            enviarCorreoElectronico.From = new MailAddress("proyectoprogramado@gmail.com");

            enviarCorreoElectronico.To.Add(Destino);
            enviarCorreoElectronico.Subject = Asunto;
            enviarCorreoElectronico.Body = Cuerpo;

            SmtpClient servidorSMTP = new SmtpClient();

            servidorSMTP.Host = "smtp.gmail.com";
            servidorSMTP.Port = 25; //465; //587
            servidorSMTP.Credentials = new NetworkCredential("proyectoprogramado@gmail.com", "Josue123");
            servidorSMTP.EnableSsl = true;
            try
            {
                servidorSMTP.Send(enviarCorreoElectronico);
            }
            catch (Exception ex)
            {
                throw new Exception("No se ha podido enviar el email", ex.InnerException);
            }
            finally
            {
                servidorSMTP.Dispose();
            }

        }
        public void EnviarCorreoDeEdicionDeCliente(string Destino, Model.Cliente.Clientes cliente)
        {
            string Asunto = "Cliente Actualizado.";
            string Cuerpo = "Se ha actualizado los datos del cliente: " + "\nCedula: " + cliente.Cedula + "\nNombre Completo: " +
                            cliente.NombreCompleto + "\nDireccion: " + cliente.Direccion +
                            "\nTelefono: " + cliente.Telefono1 + "\nSegundo Telefono: " + cliente.Telefono2 + "\nCorreo electronico: " + cliente.Email;

        
            System.Net.Mail.MailMessage enviarCorreoElectronico = new System.Net.Mail.MailMessage();

            enviarCorreoElectronico.From = new MailAddress("proyectoprogramado@gmail.com");

            enviarCorreoElectronico.To.Add(Destino);
            enviarCorreoElectronico.Subject = Asunto;
            enviarCorreoElectronico.Body = Cuerpo;
         
            SmtpClient servidorSMTP = new SmtpClient();

            servidorSMTP.Host = "smtp.gmail.com";
            servidorSMTP.Port = 25; //465; //587
            servidorSMTP.Credentials = new NetworkCredential("proyectoprogramado@gmail.com", "Josue123");
            servidorSMTP.EnableSsl = true;
            try
            {
                servidorSMTP.Send(enviarCorreoElectronico);
            }
            catch (Exception ex)
            {
                throw new Exception("No se ha podido enviar el email", ex.InnerException);
            }
            finally
            {
                servidorSMTP.Dispose();
            }

        }

    }
}
