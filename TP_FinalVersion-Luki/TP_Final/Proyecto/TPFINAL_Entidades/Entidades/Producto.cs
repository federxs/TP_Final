using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto : ICloneable
    {
        public String nombre { set; get; }
        public float precio { set; get; }
        public DateTime fechaAlta { set; get; }
        public int idProducto { set; get; }
        public int idTipoProducto { set; get; }
        public String imagen { set; get; }

        public Producto(String nom, float pre, DateTime fecha, int idTipo, String im)
        {
            nombre = nom;
            precio = pre;
            fechaAlta = fecha;
            idTipoProducto = idTipo;
            imagen = im;
        }
        public Producto() { }


        public object Clone()
        {
            return new Producto()
            {
                nombre = this.nombre,
                precio = this.precio,
                fechaAlta = this.fechaAlta,
                idTipoProducto = this.idTipoProducto,
                imagen = this.imagen
            };
        }
    }
}
