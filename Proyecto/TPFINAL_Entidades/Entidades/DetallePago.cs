using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetallePago : ICloneable
    {
        public int idDetallePago { set; get; }
        public int idPago { set; get; }
        public int idFormaPago { set; get; }
        public float cantidad { set; get; }
        public DetallePago() { }
        public DetallePago(int idDetalle, int idPa, int idForma, float cant)
        {
            idDetallePago = idDetalle;
            idPa = idPago;
            idFormaPago = idForma;
            cantidad = cant;
        }

        public object Clone()
        {
            return new DetallePago()
            {
                idDetallePago = this.idDetallePago,
                idPago = this.idPago,
                idFormaPago = this.idFormaPago,
                cantidad = this.cantidad
            };
        }
    }
}
