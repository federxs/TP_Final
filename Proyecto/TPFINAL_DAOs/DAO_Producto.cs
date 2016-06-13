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
                comando.Parameters.AddWithValue("@idProducto", p.idProducto );
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
                comando.Parameters.AddWithValue("@idProducto",id);
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
    }
}
