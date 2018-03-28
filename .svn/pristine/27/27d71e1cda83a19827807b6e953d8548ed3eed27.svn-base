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
using CompraVenta.UI;

namespace CompraVenta.ServicioDeMonitoreoDePrestamos
{
    public partial class Service1 : ServiceBase
    {
        public Timer timer;
        
         
        public Service1()
        {
            InitializeComponent();
            timer = new Timer(10000);
            timer.Elapsed += new ElapsedEventHandler(elapsed);
            timer.Enabled = true;
        }

        void elapsed(object sender, ElapsedEventArgs args)
        {
            this.timer.Stop();
            CompraVenta.UI.Convertidores.PrestamoConvertidor prs = new UI.Convertidores.PrestamoConvertidor();
            prs.ObtenerListaDePrestamosProximosASuVencimiento();
            prs.ObtenerListaDePrestamosVencidos();
            this.timer.Interval = 86400000;
            this.timer.Start();
        }
        
        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
