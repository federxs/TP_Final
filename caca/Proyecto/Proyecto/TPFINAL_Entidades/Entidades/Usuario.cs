using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public Usuario() { }
        public Usuario(int idUsuario, string nombre, string contraseña, int idRol)
        {
            IdUsuario = IdUsuario;
            Nombre = nombre;
            Contraseña = contraseña;
        }
    }
}
