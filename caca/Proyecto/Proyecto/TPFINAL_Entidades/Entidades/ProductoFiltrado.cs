using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ProductoFiltrado : Producto
    {
        public String descripcionTipoProducto { set; get; }
        public int idPedido { set; get; }
        public DateTime fechaGeneracionPedido { set; get; }
    }
}
