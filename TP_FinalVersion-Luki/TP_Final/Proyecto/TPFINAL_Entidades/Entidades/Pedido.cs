using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pedido
    {
        public int idPedido{set; get;}
        public DateTime fechaGeneracion { set; get; }
        public DateTime fechaEntrega { set; get; }
        public Cliente cliente { set; get; }
        public Estado estado { set; get; }
        public float total { set; get; }
    }
}
