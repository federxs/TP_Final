using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TblPedido
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdPedido { get; set; }
        public string Estado { get; set; }
        public DateTime FechaEntrega { get; set; }
        public float Total { get; set; }

        public TblPedido() { }
        public TblPedido(string nombre, string apellido, int idPedido, DateTime fechaEntrega, float total)
        {
            Nombre = nombre;
            Apellido = apellido;
            IdPedido = IdPedido;
            FechaEntrega = fechaEntrega;
            Total = total;
        }
    }
}
