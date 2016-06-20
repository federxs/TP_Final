using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoDoc
    {
        public int IdTipoDoc { get; set; }
        public string Nombre { get; set; }

        public TipoDoc() { }
        public TipoDoc(int idTipoDoc, string nombre)
        {
            IdTipoDoc = idTipoDoc;
            Nombre = nombre;
        }
    }
}
