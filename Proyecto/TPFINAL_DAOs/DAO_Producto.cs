using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;

namespace DAOs
{
    public class DAO_Producto
    {
        public static void actualizar(Producto p)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = DAOs.StringConexion.StringBD;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @"Update Producto set [nombre] = @nombre, [precio] = @precio,
                [idTipoProducto] = @idTipoProducto,[fechaAlta] = @fechaAlta,[imagen] = @imagen where idProducto = @idProducto";
                comando.Parameters.AddWithValue("@nombre", p.nombre);
                comando.Parameters.AddWithValue("@precio", p.precio);
                comando.Parameters.AddWithValue("@idTipoProducto", p.idTipoProducto);
                comando.Parameters.AddWithValue("@fechaAlta", p.fechaAlta);
                comando.Parameters.AddWithValue("@imagen", p.imagen);
                comando.Parameters.AddWithValue("@idProducto", p.idProducto);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void eliminar(int id)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = DAOs.StringConexion.StringBD;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @"Update Producto set [borrado] = 1 where idProducto = @idProducto";
                comando.Parameters.AddWithValue("@idProducto", id);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public static void insertar(Producto p)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = DAOs.StringConexion.StringBD;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @"INSERT INTO Producto([nombre],[precio],
                [idTipoProducto],[fechaAlta],[imagen],[borrado]) VALUES(@nombre,@precio,@idTipoProducto,
                @fechaAlta,@imagen,@borrado); Select Scope_Identity() as idProducto";
                comando.Parameters.AddWithValue("@nombre", p.nombre);
                comando.Parameters.AddWithValue("@precio", p.precio);
                comando.Parameters.AddWithValue("@idTipoProducto", p.idTipoProducto);
                comando.Parameters.AddWithValue("@fechaAlta", p.fechaAlta);
                comando.Parameters.AddWithValue("@imagen", p.imagen);
                comando.Parameters.AddWithValue("@borrado", 0);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<Producto> obtenerTodos()
        {
            List<Producto> listProductos = new List<Producto>();
            //1. Abrir la conexion
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = DAOs.StringConexion.StringBD;
            cn.Open();
            //2. Crear el objeto command para ejecutar el insert
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"Select top 1000
                               [idProducto]
                              ,[nombre]
                              ,[precio]
                              ,[idTipoProducto]
                              ,[imagen], [fechaAlta] from Producto where borrado = 0";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                String nombre = dr["nombre"].ToString();
                DateTime fechaAlta = (DateTime)dr["fechaAlta"];
                float precio = float.Parse(dr["precio"].ToString());
                int idTipoProducto = int.Parse(dr["idTipoProducto"].ToString());
                String imagen = dr["imagen"].ToString();
                Producto p = new Producto(nombre, precio, fechaAlta, idTipoProducto, imagen);
                p.idProducto = int.Parse(dr["idProducto"].ToString());
                listProductos.Add(p);
            }
            dr.Close();
            cn.Close();
            return listProductos;
        }
        public static List<TipoProducto> obtenerTipo()
        {
            List<TipoProducto> lista = new List<TipoProducto>();

            //1. Abrir la conexion
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = DAOs.StringConexion.StringBD;
            cn.Open();
            //2. Crear el objeto command para ejecutar el insert
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"Select idTipoProducto, descripcion from TipoProducto";
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string descripcion = dr["descripcion"].ToString();
                int idTipoProducto = int.Parse(dr["idTipoProducto"].ToString());
                TipoProducto tp = new TipoProducto(idTipoProducto, descripcion);
                lista.Add(tp);

            }
            dr.Close();
            cn.Close();
            return lista;
        }

        public static Producto obtenerPorID(int id)
        {

            Producto p = null;
            //1. Abrir la conexion
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = cn.ConnectionString = DAOs.StringConexion.StringBD;
            cn.Open();
            //2. Crear el objeto command para ejecutar el insert
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"Select [idProducto]
                              ,[nombre]
                              ,[precio]
                              ,[idTipoProducto]
                              ,[imagen]
                              ,[fechaAlta] from Producto where idProducto = @id";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string nombre = dr["nombre"].ToString();
                float precio = float.Parse(dr["precio"].ToString());
                int idTipoProducto = int.Parse(dr["idTipoProducto"].ToString());
                String imagen = dr["imagen"].ToString();
                DateTime fechaAlta = DateTime.Parse(dr["fechaAlta"].ToString());
                p = new Producto(nombre, precio, fechaAlta, idTipoProducto, imagen);
                p.idProducto = int.Parse(dr["idProducto"].ToString());
            }
            dr.Close();
            cn.Close();
            return p;
        }

        public static List<Producto> obtenerTodos(string nombreBusqueda)
        {
            List<Producto> listProductos = new List<Producto>();
            //1. Abrir la conexion
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = DAOs.StringConexion.StringBD;
            cn.Open();
            //2. Crear el objeto command para ejecutar el insert
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = @"Select top 1000
                               [idProducto]
                              ,[nombre]
                              ,[precio]
                              ,[idTipoProducto]
                              ,[imagen], [fechaAlta] from Producto where borrado = 0";
            if (!string.IsNullOrEmpty(nombreBusqueda))
            {
                cmd.CommandText += " and nombre Like @nombreBusqueda";
                cmd.Parameters.AddWithValue("@nombreBusqueda", nombreBusqueda + "%");
            }
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                String nombre = dr["nombre"].ToString();
                DateTime fechaAlta = (DateTime)dr["fechaAlta"];
                float precio = float.Parse(dr["precio"].ToString());
                int idTipoProducto = int.Parse(dr["idTipoProducto"].ToString());
                String imagen = dr["imagen"].ToString();
                Producto p = new Producto(nombre, precio, fechaAlta, idTipoProducto, imagen);
                p.idProducto = int.Parse(dr["idProducto"].ToString());
                listProductos.Add(p);
            }
            dr.Close();
            cn.Close();
            return listProductos;
        }

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
    }
}
