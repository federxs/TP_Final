using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;
using System.Configuration;

namespace DAOs
{
    public static class DAO_Pedido
    {
        public static List<TblPedido> ObtenerTodos(string fechaDesde, string fechaHasta, float total, string estado)
        {
            try
            {
                List<TblPedido> pedidos = new List<TblPedido>();
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = DAOs.StringConexion.StringBD;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @"SELECT C.apellido, C.nombre, P.idPedido, E.nombre AS 'nombreEstado', P.fechaEntrega, P.total FROM ProyectoWeb.dbo.Pedido P 
                                        JOIN ProyectoWeb.dbo.Cliente C ON P.idCliente = C.idCliente 
                                        JOIN ProyectoWeb.dbo.Estado E ON P.idEstado = E.idEstado
                                        WHERE 1=1";
                //Ponemos parametros
                if (!string.IsNullOrEmpty(fechaDesde))
                {
                    comando.CommandText += " AND P.fechaEntrega >= @fechaDesde";
                    comando.Parameters.AddWithValue("@fechaDesde",fechaDesde);
                }
                if (!string.IsNullOrEmpty(fechaHasta))
                {
                    comando.CommandText += " AND P.fechaEntrega <= @fechaHasta";
                    comando.Parameters.AddWithValue("@fechaHasta", fechaHasta);
                }
                if(total != 0F)
                {
                    comando.CommandText += " AND P.total = @total";
                    comando.Parameters.AddWithValue("@total",total);
                }
                if(estado != "Seleccionar")
                {
                    comando.CommandText += " AND E.nombre = @estado";
                    comando.Parameters.AddWithValue("@estado",estado);
                }
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    TblPedido pedido = new TblPedido()
                    {
                        Nombre = reader["nombre"].ToString(),
                        Apellido = reader["apellido"].ToString(),
                        IdPedido = int.Parse(reader["idPedido"].ToString()),
                        Estado = reader["nombreEstado"].ToString(),
                        FechaEntrega = DateTime.Parse(reader["fechaEntrega"].ToString()),
                        Total = float.Parse(reader["total"].ToString())
                    };
                    pedidos.Add(pedido);
                }
                reader.Close();
                conexion.Close();
                return pedidos;
            }
            catch (SqlException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
        }

        public static List<Estado> ObtenerEstados()
        {
            try
            {
                List<Estado> estados = new List<Estado>();
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = DAOs.StringConexion.StringBD;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @"SELECT E.idEstado, E.nombre FROM ProyectoWeb.dbo.Estado E";
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Estado estado = new Estado()
                    {
                        IdEstado = int.Parse(reader["idEstado"].ToString()),
                        Nombre = reader["nombre"].ToString()
                    };
                    estados.Add(estado);
                }
                reader.Close();
                conexion.Close();
                return estados;
            }
            catch (SqlException ex) { throw ex; }
            catch (SystemException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
        }
    }
}
