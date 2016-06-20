using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TipoProducto
    {
        public int idTipoProducto { set; get; }
        public String descripcion { set; get; }
        public TipoProducto(int id, String nom)
        {
            idTipoProducto = id;
            descripcion = nom;
        }
    }
}
