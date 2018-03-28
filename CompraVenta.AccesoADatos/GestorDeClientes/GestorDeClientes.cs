using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraVenta.AccesoADatos.GestorDeClientes
{
    public class GestorDeClientes
    {
        public void AgregarUnCliente(Model.Cliente.Clientes elNuevoCliente)
        {

            var db = new Context();
            db.Clientes.Add(elNuevoCliente);
            db.Entry(elNuevoCliente).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
        }

        public void ActualizarUnCliente(Model.Cliente.Clientes elCliente)
        {

            var db = new Context();
            var valorBd = ObtenerListaDeClientesPorId(elCliente.Id);
            valorBd.Id_AspNetUser = elCliente.Id_AspNetUser;
            valorBd.Cedula = elCliente.Cedula;
            valorBd.NombreCompleto = elCliente.NombreCompleto;
            valorBd.Direccion = elCliente.Direccion;
            valorBd.Telefono1 = elCliente.Telefono1;
            valorBd.Telefono2 = elCliente.Telefono2;
            valorBd.Email = elCliente.Email;
            valorBd.Estado = elCliente.Estado;


            db.Entry(valorBd).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Model.Cliente.Clientes ObtenerListaDeClientesPorId(int Id)
        {
            var db = new Context();
            var resultado = db.Clientes.Find(Id);

            return resultado;
        }

        public List<Model.Cliente.Clientes> ObtenerListaDeClientesPorEstado(byte estado)
        {

            var db = new Context();
            var resultado = from busqueda in db.Clientes
                            where busqueda.Estado.Equals(estado)
                            select busqueda;
            return resultado.ToList();

        }
        public List<Model.Cliente.Clientes> ObtenerListaDeClientesPorCedula(string cedula)
        {

            var db = new Context();
            var resultado = from busqueda in db.Clientes
                            where busqueda.Cedula.Equals(cedula)
                            select busqueda;
            return resultado.ToList();

        }
        public List<Model.Cliente.Clientes> ObtenerListaDeTodosLosClientes()
        {
            var db = new Context();
            var resultado = db.Clientes.ToList();
            return resultado;

        }
        public void ActivarUnCliente(Model.Cliente.Clientes elCliente)
        {
            var db = new Context();
            var valorBd = ObtenerListaDeClientesPorId(elCliente.Id);

            valorBd = elCliente;

            db.Entry(valorBd).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void InactivarUnCliente(Model.Cliente.Clientes elCliente)
        {
            var db = new Context();
            var valorBd = ObtenerListaDeClientesPorId(elCliente.Id);

            valorBd = elCliente;

            db.Entry(valorBd).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

    }
}
