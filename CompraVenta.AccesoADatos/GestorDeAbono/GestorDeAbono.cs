using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraVenta.AccesoADatos.GestorDeAbono
{
  public class GestorDeAbono
    {
        public void AgregarUnAbono(Model.Abono.Abono elNuevoAbono)
        {

            var db = new Context();
            db.Abono.Add(elNuevoAbono);
            db.Entry(elNuevoAbono).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
        }

        public void ActualizarUnAbono(Model.Abono.Abono elAbono)
        {

            var db = new Context();
            var valorBd = ObtenerAbonoPorId(elAbono.Id);

            valorBd.IdPrestamo = elAbono.IdPrestamo;
            valorBd.Monto = elAbono.Monto;
            valorBd.Estado = elAbono.Estado;
            valorBd.Fecha = elAbono.Fecha;
            valorBd.Id_AspNetUser = elAbono.Id_AspNetUser;
          

            db.Entry(valorBd).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Model.Abono.Abono ObtenerAbonoPorId(int Id)
        {
            var db = new Context();
            var resultado = db.Abono.Find(Id);

            return resultado;
        }

        public List<Model.Abono.Abono> ObtenerListaDeAbonosPorIdPrestamo(int IdPrestamo)
        {

            var db = new Context();
            var resultado = from busqueda in db.Abono
                            where busqueda.IdPrestamo.Equals(IdPrestamo)
                            select busqueda;
            return resultado.ToList();

        }

    }
}
