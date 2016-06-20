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
        public int idCliente { set; get; }
        public int idEstado { set; get; }
        public float total { set; get; }
        public int IdPedido{set; get;}
        public DateTime FechaGeneracion { set; get; }
        public DateTime FechaEntrega { set; get; }
        public int IdCliente { set; get; }
        public int IdEstado { set; get; }
        public float Total { set; get; }

    }
}
