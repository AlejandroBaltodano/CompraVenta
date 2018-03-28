using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;
using System.Net.Mail;
using System.Net;


namespace CompraVenta.ServicioMonitoreoDePrestamos
{
    public partial class ServicioMonitoreoDePrestamos : ServiceBase
    {
        Timer ControlDeMonitoreo;
        public ServicioMonitoreoDePrestamos()
        {
            
            InitializeComponent();
            ControlDeMonitoreo = new Timer(10000);
            ControlDeMonitoreo.Elapsed += new ElapsedEventHandler(ControlDeMonitoreo_Elapsed);
     

        }

        private void ControlDeMonitoreo_Elapsed(object sender, ElapsedEventArgs e)
        {
            controlMonitoreoPrestamos();
         
        }

        protected override void OnStart(string[] args)
        {

            ControlDeMonitoreo.Start();
        }

        protected override void OnStop()
        {
            ControlDeMonitoreo.Stop();
        }

        public void controlMonitoreoPrestamos() {
            ObtenerListaDePrestamosProximosASuVencimiento();
            ObtenerListaDePrestamosVencidos();
            
        }


        public void ObtenerListaDePrestamosVencidos()
        {

            LogicaDeNegocio.CoordinadorDeUsuarios.CoordinadorDeUsuarios coordinadorDeUsuarios = new LogicaDeNegocio.CoordinadorDeUsuarios.CoordinadorDeUsuarios();
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
            LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos coordinadorDePrestamos = new LogicaDeNegocio.CoordinadorDePrestamos.CoordinadorDePrestamos();
            List<Model.Prestamos.Prestamos> laListaDePrestamo = new List<Model.Prestamos.Prestamos>();
            CompraVenta.UI.Convertidores.PrestamoConvertidor convertidorPrestamos = new UI.Convertidores.PrestamoConvertidor();
            List<CompraVenta.UI.Models.PrestamosModels> laListaConvertida = convertidorPrestamos.ObtenerListaConvertidaDePrestamos();

            foreach (var prestamo in laListaConvertida)
            {
                if (prestamo.FechaVencimiento.Date != DateTime.Now.Date)
                {
                    DateTime tiempoVencido = new DateTime();
                    tiempoVencido = prestamo.FechaVencimiento;
                    if (tiempoVencido.Date >= DateTime.Now.Date)
                    {
                        laListaDePrestamo = coordinadorDePrestamos.ObtenerListaDePrestamoPorId(prestamo.Id);
                        foreach  (Model.Prestamos.Prestamos elPrestamo in laListaDePrestamo)
                        {
                            coordinadorDePrestamos.PonerPrestamoEnVencido(elPrestamo);
                        }
                        Model.Cliente.Clientes cliente = coordinadorDeClientes.ConsultarClientePorId(prestamo.IdCliente);

                        string Asunto = "Su préstamo ["+prestamo.Id+"] se venció.";
                        string Cuerpo = "Estimado ["+prestamo.NombreClientes+"],\n"+
                       "su préstamo["+prestamo.Id+"], por el monto de["+prestamo.CantidadPrestada+"],\n"+
                       "con un monto pendiente de["+prestamo.MontoPendienteDePago+"], se venció, por lo tanto los bienes prendados pasaran a ser parte de los activos de la empresa.";

                        coordinadorDeUsuarios.EnviarCorreoElectronico(cliente.Email, Asunto, Cuerpo);
                    }


                }
            }

        }






        public void ObtenerListaDePrestamosProximosASuVencimiento() {

            LogicaDeNegocio.CoordinadorDeUsuarios.CoordinadorDeUsuarios coordinadorDeUsuarios = new LogicaDeNegocio.CoordinadorDeUsuarios.CoordinadorDeUsuarios();
            LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes coordinadorDeClientes = new LogicaDeNegocio.CoordinadorDeClientes.CoordinadorDeClientes();
            List<CompraVenta.UI.Models.PrestamosModels> laListaDePrestamosVencidos = new List<UI.Models.PrestamosModels>();

            CompraVenta.UI.Convertidores.PrestamoConvertidor convertidorPrestamos = new UI.Convertidores.PrestamoConvertidor();
            List<CompraVenta.UI.Models.PrestamosModels> laListaConvertida = convertidorPrestamos.ObtenerListaConvertidaDePrestamos();

            foreach (var prestamo in laListaConvertida)
            {
                if (prestamo.FechaVencimiento.Date != DateTime.Now.Date)
                {
                    TimeSpan tiempoParaVencer = new TimeSpan();
                    tiempoParaVencer = prestamo.FechaVencimiento - prestamo.Fecha;
                    if (tiempoParaVencer.Days<=10)
                    {
                        Model.Cliente.Clientes cliente = coordinadorDeClientes.ConsultarClientePorId(prestamo.IdCliente);

                        string Asunto = "Su préstamo está a [ "+tiempoParaVencer.Days+" ] días por vencer.";
                        string Cuerpo = "Estimado [" + prestamo.NombreClientes + "]," + "\nsu préstamo [" + prestamo.Id + "] " + " por el monto de [" + prestamo.CantidadPrestada + "], con un monto pendiente de [" + prestamo.MontoPendienteDePago + "]," +
                           "está a [Cantidad de días a vencer], por favor programar su pago lo más próximo posible.";

                        coordinadorDeUsuarios.EnviarCorreoElectronico(cliente.Email, Asunto, Cuerpo);
                    }
                   

                }
            }

        }



    }
}
