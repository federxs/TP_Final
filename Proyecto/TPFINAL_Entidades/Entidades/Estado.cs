using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estado
    {
        public int IdEstado { get; set; }
        public string Nombre { get; set; }

        public Estado() { }
        public Estado(int idEstado, string nombre)
        {
            IdEstado = idEstado;
            Nombre = nombre;
        }
    }
}
