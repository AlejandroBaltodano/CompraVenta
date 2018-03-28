using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraVenta.LogicaDeNegocio.CoordinadorDeAbonos
{
    public class CoordinadorDeAbonos
    {
        public void AgregarUnAbono(Model.Abono.Abono nuevoAbono)
        {
            AccesoADatos.GestorDeAbono.GestorDeAbono gestorDeAbonos = new AccesoADatos.GestorDeAbono.GestorDeAbono();

            nuevoAbono.Estado = (int)Model.Enumerados.EstadoAbono.Registrado;
            nuevoAbono.Fecha = DateTime.Now;
            gestorDeAbonos.AgregarUnAbono(nuevoAbono);

        }

        public Model.Abono.Abono ConsultarAbonoPorId(int id)
        {
            AccesoADatos.GestorDeAbono.GestorDeAbono gestorDeAbonos = new AccesoADatos.GestorDeAbono.GestorDeAbono();
            return gestorDeAbonos.ObtenerAbonoPorId(id);
        }

        public void AnularUnAbono(Model.Abono.Abono elAbono)
        {
            AccesoADatos.GestorDeAbono.GestorDeAbono gestorDeAbonos = new AccesoADatos.GestorDeAbono.GestorDeAbono();

            elAbono.Estado = (int)Model.Enumerados.EstadoAbono.Anulado;

            gestorDeAbonos.ActualizarUnAbono(elAbono);
        }

        public List<Model.Abono.Abono> ObtenerListaDeAbonosPorIdPrestamo(int idPrestamo)
        {
            AccesoADatos.GestorDeAbono.GestorDeAbono gestorDeAbonos = new AccesoADatos.GestorDeAbono.GestorDeAbono();
            return gestorDeAbonos.ObtenerListaDeAbonosPorIdPrestamo(idPrestamo);

        }

    }
}
