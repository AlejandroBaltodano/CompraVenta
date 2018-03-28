using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CompraVenta.LogicaDeNegocio.CoordinadorDeUsuarios
{
    public class CoordinadorDeUsuarios
    {

        public void AgregarUnUsuario(Model.Usuario.AspNetUsers nuevoUsuario)
        {
            AccesoADatos.GestorDeUsuarios.GestorDeUsuarios gestorDeUsuario = new AccesoADatos.GestorDeUsuarios.GestorDeUsuarios();

            gestorDeUsuario.AgregarUnUsuario(nuevoUsuario);

        }

        public Model.Usuario.AspNetUsers ConsultarUsuarioPorId(int id)
        {
            AccesoADatos.GestorDeUsuarios.GestorDeUsuarios gestorDeUsuario = new AccesoADatos.GestorDeUsuarios.GestorDeUsuarios();

            return gestorDeUsuario.ObtenerUsuarioPorId(id);
        }

        public void EnviarCorreoElectronico(string Direccion, string Asunto, string Cuerpo)
        {
            //TODO renombrar
            System.Net.Mail.MailMessage enviarCorreoElectronico = new System.Net.Mail.MailMessage();

            enviarCorreoElectronico.From = new MailAddress("proyectoprogramado@gmail.com");

            enviarCorreoElectronico.To.Add(Direccion);
            enviarCorreoElectronico.Subject = Asunto;
            enviarCorreoElectronico.Body = Cuerpo;
            //TODO renombrar
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
