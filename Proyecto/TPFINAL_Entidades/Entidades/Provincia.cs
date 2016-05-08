using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Provincia
    {
        public int IdProvincia { get; set; }
        public string Nombre { get; set; }
        public int Pais { get; set; }

        public Provincia() { }
        public Provincia(int idProvincia, string nombre, int pais)
        {
            IdProvincia = idProvincia;
            Nombre = nombre;
            Pais = pais;
        }

    }
}
