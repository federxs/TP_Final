using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pedido
    {
        public int IdPedido{set; get;}
        public DateTime FechaGeneracion { set; get; }
        public DateTime FechaEntrega { set; get; }
        public int IdCliente { set; get; }
        public int IdEstado { set; get; }
        public float Total { set; get; }
    }
}
