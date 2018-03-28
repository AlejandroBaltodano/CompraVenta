using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraVenta.AccesoADatos.GestorDePrestamos
{
   public class GestorDePrestamos
    {

        public void AgregarUnPrestamo(Model.Prestamos.Prestamos elNuevoPrestamo)
        {

            var db = new Context();
            db.Prestamos.Add(elNuevoPrestamo);
            db.Entry(elNuevoPrestamo).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
        }

        public void ActualizarUnPrestamo(Model.Prestamos.Prestamos elPrestamo)
        {

            var db = new Context();
            var valorBd = ObtenerPrestamoPorId(elPrestamo.Id);
            valorBd.Id_AspNetUser = elPrestamo.Id_AspNetUser;
            valorBd.CantidadPrestada = elPrestamo.CantidadPrestada;
            valorBd.DescripcionPrenda = elPrestamo.DescripcionPrenda;
            valorBd.Estado = elPrestamo.Estado;
            valorBd.Fecha = elPrestamo.Fecha;
            valorBd.Id = elPrestamo.Id;
            valorBd.IdCliente = elPrestamo.IdCliente;
            valorBd.PlazoDiasPrestamo = elPrestamo.PlazoDiasPrestamo;
            valorBd.PorcentajeIntereses = elPrestamo.PorcentajeIntereses;


            db.Entry(valorBd).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Model.Prestamos.Prestamos ObtenerPrestamoPorId(int Id)
        {
            var db = new Context();
            var resultado = db.Prestamos.Find(Id);

            return resultado;
        }

        public List<Model.Prestamos.Prestamos> ObtenerListaDePrestamoPorEstado(int estado)
        {

            var db = new Context();
            var resultado = from busqueda in db.Prestamos
                            where busqueda.Estado.Equals(estado)
                            select busqueda;
            return resultado.ToList();

        }
        public List<Model.Prestamos.Prestamos> ObtenerListaDePrestamoPorId(int id)
        {

            var db = new Context();
            var resultado = from busqueda in db.Prestamos
                            where busqueda.Id.Equals(id)
                            select busqueda;
            return resultado.ToList();

        }
        public List<Model.Prestamos.Prestamos> ObtenerListaDePrestamosPorCliente(int idCliente)
        {
            var db = new Context();
            var resultado = from busqueda in db.Prestamos
                            where busqueda.IdCliente.Equals(idCliente)
                            select busqueda;
            return resultado.ToList();

        }

        public List<Model.Prestamos.Prestamos> ObtenerListaDePrestamosPorFecha(DateTime fecha)
        {
            var db = new Context();
            var resultado = from busqueda in db.Prestamos
                            where busqueda.Fecha >= fecha.Date
                            select busqueda;
            return resultado.ToList();

        }
        public List<Model.Prestamos.Prestamos> ObtenerListaDePrestamosParaEstado(DateTime fecha)
        {
            var db = new Context();
            var resultado = from busqueda in db.Prestamos
                            where busqueda.Fecha <= fecha.Date
                            select busqueda;
            return resultado.ToList();

        }

        public List<Model.Prestamos.Prestamos> ObtenerListaDeTodosLosPrestamos()
        {
            var db = new Context();
            var resultado = db.Prestamos.ToList();
            return resultado;

        }

        public void PrestamoVencido(Model.Prestamos.Prestamos elPrestamo)
        {
            var db = new Context();
            var valorBd = ObtenerPrestamoPorId(elPrestamo.Id);

            valorBd = elPrestamo;

            db.Entry(valorBd).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

    }
}





