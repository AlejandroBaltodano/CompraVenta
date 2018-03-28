﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompraVenta.AccesoADatos.GestorDeUsuarios
{
   public class GestorDeUsuarios
    {
        public void AgregarUnUsuario(Model.Usuario.AspNetUsers elNuevoUsuario)
        {

            var db = new Context();
            db.AspNetUsers.Add(elNuevoUsuario);
            db.Entry(elNuevoUsuario).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            
        }

        public Model.Usuario.AspNetUsers ObtenerUsuarioPorId(int Id)
        {
            var db = new Context();
            var resultado = db.AspNetUsers.Find(Id);

            return resultado;
        }
    }
}
