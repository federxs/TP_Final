using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class FormaPago
    {
        public int idFormaPago { set; get; }
        public String descripcion { set; get; }

        public FormaPago(int id, string des)
        {
            idFormaPago = id;
            descripcion = des;
        }
    }
}
