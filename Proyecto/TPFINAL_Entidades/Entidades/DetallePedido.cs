using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetallePedido
    {
        public int IdDetalle { get; set; }
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public string Producto { get; set; }

        public DetallePedido() { }
        public DetallePedido(int idDet, int idPed, int idProd, int cant,string prod) 
        {
            IdDetalle = idDet;
            IdPedido = idPed;
            IdProducto = idProd;
            Cantidad = cant;
            Producto = prod;
        }
    }
}
