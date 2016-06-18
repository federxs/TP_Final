using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace DAOs
{
    public static class DAO_Pedido
    {
        public static List<ProductoFiltrado> obtenerProductosPorFiltro(int? idTipoProducto, String nombre, float? precio, DateTime? fechaDesde, DateTime? fechaHasta)
        {
            List<ProductoFiltrado> lista = new List<ProductoFiltrado>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cn.ConnectionString = DAOs.StringConexion.StringBD;
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"Select p.idProducto, p.nombre, p.precio, 
		                        tp.descripcion, p.fechaAlta, pe.idPedido,
		                        pe.fechaGeneracion 
		                        from Producto p JOIN DetallePedido dpe on p.idProducto = dpe.idProducto 
                                JOIN Pedido pe on pe.idPedido = dpe.idPedido JOIN TipoProducto tp on tp.idTipoProducto = p.idTipoProducto 
		                        where 1=1 and p.borrado= 0";
            if (!string.IsNullOrEmpty(nombre))
            {
                cmd.CommandText += " and p.nombre Like @nombre";
                cmd.Parameters.AddWithValue("@nombre", nombre + "%");
            }
            if (idTipoProducto != null)
            {
                cmd.CommandText += " and p.idTipoProducto = @idTipoProducto";
                cmd.Parameters.AddWithValue("@idTipoProducto", idTipoProducto);
            }
            if ((fechaDesde != null) && (fechaHasta != null))
            {
                cmd.CommandText += " and pe.fechaGeneracion Between @fechaDesde and @fechaHasta";
                cmd.Parameters.AddWithValue("@fechaDesde", fechaDesde);
                cmd.Parameters.AddWithValue("@fechaHasta", fechaHasta);
            }
            if ((fechaDesde != null) && (fechaHasta == null))
            {
                cmd.CommandText += " and pe.fechaGeneracion > @fechaDesde";
                cmd.Parameters.AddWithValue("@fechaDesde", fechaDesde);
            }
            if ((fechaHasta != null) && (fechaDesde == null))
            {
                cmd.CommandText += " and pe.fechaGeneracion < @fechaHasta";
                cmd.Parameters.AddWithValue("@fechaHasta", fechaHasta);
            }

            if (precio != null)
            {
                cmd.CommandText += " and p.precio > @precio";
                cmd.Parameters.AddWithValue("@precio", precio);
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ProductoFiltrado p = new ProductoFiltrado();
                //int? idProd = null;
                if (dr["idProducto"] != DBNull.Value)
                    p.idProducto = int.Parse(dr["idProducto"].ToString());

                //String nom = null;
                if (dr["nombre"] != DBNull.Value)
                    p.nombre = dr["nombre"].ToString();

                //float? pre = null;
                if (dr["precio"] != DBNull.Value)
                {
                    p.precio = float.Parse(dr["precio"].ToString());
                }

                //String descripcionTipoProducto = null;
                if (dr["descripcion"] != DBNull.Value)
                {
                    p.descripcionTipoProducto = dr["descripcion"].ToString();
                }

                //DateTime? fechaAlta = null;
                if (dr["fechaAlta"] != DBNull.Value)
                {
                    p.fechaAlta = (DateTime)(dr["fechaAlta"]);
                }

                //int? idPedido = null;
                if (dr["idPedido"] != DBNull.Value)
                {
                    p.idPedido = int.Parse(dr["idPedido"].ToString());
                }

                //DateTime? fechaGeneracionPedido = null;
                if (dr["fechaGeneracion"] != DBNull.Value)
                {
                    p.fechaGeneracionPedido = (DateTime)(dr["fechaGeneracion"]);
                }
                p.imagen = "";
                lista.Add(p);
            }
            dr.Close();
            cn.Close();
            return lista;
        }

        public static List<Pedido> obtenerPedidoPorCliente(int idCli)
        {
            List<Pedido> lista = new List<Pedido>();
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = DAOs.StringConexion.StringBD;
                cn.Open();
                //2. Crear el objeto command para ejecutar el insert
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"Select idPedido, fechaGeneracion, fechaEntrega, idEstado, idCliente, total
                                    From Pedido  
                                    where idCliente = @idCliente and (idEstado = 1 or idEstado = 3)";
                cmd.Parameters.AddWithValue("@idCliente", idCli);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Pedido p = new Pedido();
                    int idPedido = int.Parse(dr["idPedido"].ToString());
                    DateTime fechaGeneracion = (DateTime)dr["fechaGeneracion"];
                    DateTime fechaEntrega = (DateTime)dr["fechaEntrega"];
                    fechaGeneracion.ToString("dd/mm/yyyy");
                    fechaEntrega.ToString("dd/mm/yyyy");
                    int idEstado = int.Parse(dr["idEstado"].ToString());
                    int idCliente = int.Parse(dr["idCliente"].ToString());
                    float total = float.Parse(dr["total"].ToString());
                    p.total = total;
                    p.idCliente = idCliente;
                    p.idEstado = idEstado;
                    p.fechaEntrega = fechaEntrega;
                    p.fechaGeneracion = fechaGeneracion;
                    p.idPedido = idPedido;
                    lista.Add(p);
                }

            }
            catch (SqlException exSql) { throw exSql; }
            return lista;
        }

        public static float obtenerMontoPorPedido(int idPedido)
        {
            float monto = 0;
            try {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = cn.ConnectionString = DAOs.StringConexion.StringBD;
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"Select total
                                from Pedido 
                                where idPedido=@id";
                cmd.Parameters.AddWithValue("@id", idPedido);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    monto = float.Parse(dr["total"].ToString());
                }
            }
            catch (SqlException exSql) { throw exSql; }
            return monto;
        }
    }
}
