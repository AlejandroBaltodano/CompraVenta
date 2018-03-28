using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace CompraVenta.AccesoADatos
{
    public class Context : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.Cliente.Clientes>().ToTable("Clientes");
            modelBuilder.Entity<Model.Prestamos.Prestamos>().ToTable("Prestamos");
            modelBuilder.Entity<Model.Abono.Abono>().ToTable("Abono");

            modelBuilder.Entity<Model.Usuario.AspNetUsers>().ToTable("AspNetUsers");


        }

        public DbSet<Model.Cliente.Clientes> Clientes { get; set; }
        public DbSet<Model.Prestamos.Prestamos> Prestamos { get; set; }
        public DbSet<Model.Abono.Abono> Abono { get; set; }

        public DbSet<Model.Usuario.AspNetUsers> AspNetUsers { get; set; }


    }
}

