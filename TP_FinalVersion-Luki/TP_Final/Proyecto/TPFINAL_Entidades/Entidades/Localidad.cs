using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Localidad
    {
        public int IdLocalidad { get; set; }
        public string Nombre { get; set; }
        public int Provincia { get; set; }

        public Localidad() { }
        public Localidad(int idLocalidad, string nombre, int provincia)
        {
            IdLocalidad = idLocalidad;
            Nombre = nombre;
            Provincia = provincia;
        }
    }
}
