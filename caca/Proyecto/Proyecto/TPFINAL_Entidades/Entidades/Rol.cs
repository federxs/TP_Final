using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Rol
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Rol() { }
        public Rol(int idRol, string nombre, string descripcion) 
        {
            IdRol = idRol;
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}
