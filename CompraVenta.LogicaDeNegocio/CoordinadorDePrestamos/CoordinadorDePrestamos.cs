using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraVenta.LogicaDeNegocio.CoordinadorDePrestamos
{
  public  class CoordinadorDePrestamos
    {
        public const int DiasPlazoPrestamo30 = 30;
        public const int DiasPlazoPrestamo60 = 60;
        public const int DiasPlazoPrestamo90 = 90;

        public void AgregarUnPrestamo(Model.Prestamos.Prestamos nuevoPrestamo)
        {
            AccesoADatos.GestorDePrestamos.GestorDePrestamos gestorDePrestamos = new AccesoADatos.GestorDePrestamos.GestorDePrestamos();

            nuevoPrestamo.Estado = (int)Model.Enumerados.EstadoPrestamo.Registrado;
            nuevoPrestamo.Fecha = DateTime.Now;
            gestorDePrestamos.AgregarUnPrestamo(nuevoPrestamo);

        }

        public Model.Prestamos.Prestamos ConsultarPrestamoPorId(int id)
        {
            AccesoADatos.GestorDePrestamos.GestorDePrestamos gestorDePrestamos = new AccesoADatos.GestorDePrestamos.GestorDePrestamos();
            return gestorDePrestamos.ObtenerPrestamoPorId(id);
        }
        public List<Model.Prestamos.Prestamos> ObtenerListaDePrestamoPorId(int id)
        {
            AccesoADatos.GestorDePrestamos.GestorDePrestamos gestorDePrestamos = new AccesoADatos.GestorDePrestamos.GestorDePrestamos();
            return gestorDePrestamos.ObtenerListaDePrestamoPorId(id);
        }

        public void PonerPrestamoEnVencido(Model.Prestamos.Prestamos elPrestamo)
        {

            AccesoADatos.GestorDePrestamos.GestorDePrestamos gestorDePrestamos = new AccesoADatos.GestorDePrestamos.GestorDePrestamos();

            if (elPrestamo.Estado ==(int)Model.Enumerados.EstadoPrestamo.Registrado)
            {
                elPrestamo.Estado = (int)Model.Enumerados.EstadoPrestamo.Vencido;
                gestorDePrestamos.PrestamoVencido(elPrestamo);
            }
        }

        public void EditarUnPrestamo(Model.Prestamos.Prestamos elPrestamo)
        {
            AccesoADatos.GestorDePrestamos.GestorDePrestamos gestorDePrestamos = new AccesoADatos.GestorDePrestamos.GestorDePrestamos();
            DateTime fechaLimite= elPrestamo.Fecha;
           

            if (fechaLimite.ToString("dd/MM/yyyy")== DateTime.Now.ToString("dd/MM/yyyy"))
            {
                gestorDePrestamos.ActualizarUnPrestamo(elPrestamo);
            }

        }
        public List<Model.Prestamos.Prestamos> ObtenerListaDePrestamosPorEstado(int estado)
        {
            AccesoADatos.GestorDePrestamos.GestorDePrestamos gestorDePrestamos = new AccesoADatos.GestorDePrestamos.GestorDePrestamos();
            return gestorDePrestamos.ObtenerListaDePrestamoPorEstado(estado);

        }
        public List<Model.Prestamos.Prestamos> ObtenerListaDePrestamosPorIdCedula(int idCliente)
        {
            AccesoADatos.GestorDePrestamos.GestorDePrestamos gestorDePrestamos = new AccesoADatos.GestorDePrestamos.GestorDePrestamos();
            return gestorDePrestamos.ObtenerListaDePrestamosPorCliente(idCliente);

        }
        public List<Model.Prestamos.Prestamos> ObtenerListaDePrestamosPorFecha(DateTime fecha)
        {
            AccesoADatos.GestorDePrestamos.GestorDePrestamos gestorDePrestamos = new AccesoADatos.GestorDePrestamos.GestorDePrestamos();

            return gestorDePrestamos.ObtenerListaDePrestamosPorFecha(fecha);

        }

        public List<Model.Prestamos.Prestamos> ObtenerListaDePrestamosParaEstado(DateTime fecha)
        {
            AccesoADatos.GestorDePrestamos.GestorDePrestamos gestorDePrestamos = new AccesoADatos.GestorDePrestamos.GestorDePrestamos();

            return gestorDePrestamos.ObtenerListaDePrestamosParaEstado(fecha);

        }
        public List<Model.Prestamos.Prestamos> ObtenerListaDeTodosLosPrestamos()
        {
            AccesoADatos.GestorDePrestamos.GestorDePrestamos gestorDePrestamos = new AccesoADatos.GestorDePrestamos.GestorDePrestamos();

            return gestorDePrestamos.ObtenerListaDeTodosLosPrestamos();

        }

        public List<Model.PrestamoDiasPrestamo> ObtenerPlazoDiasPrestamo()
        {

            List<Model.PrestamoDiasPrestamo> laListaDeLosPlazosDiasPrestamo = new List<Model.PrestamoDiasPrestamo>();

            laListaDeLosPlazosDiasPrestamo.Add(new Model.PrestamoDiasPrestamo() { Id = DiasPlazoPrestamo30, Nombre = "30" });
            laListaDeLosPlazosDiasPrestamo.Add(new Model.PrestamoDiasPrestamo() { Id = DiasPlazoPrestamo60, Nombre = "60" });
            laListaDeLosPlazosDiasPrestamo.Add(new Model.PrestamoDiasPrestamo() { Id = DiasPlazoPrestamo90, Nombre = "90" });

            return laListaDeLosPlazosDiasPrestamo;
        }


    }
}
