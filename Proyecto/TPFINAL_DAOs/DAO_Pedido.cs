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
        public static void Insertar(Pedido pedido, List<DetallePedido> detalles)
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = StringConexion.StringBD;
            conexion.Open();
            SqlTransaction transaccion = conexion.BeginTransaction();
            try
            {
                //Insertamos pedido
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @"INSERT INTO [ProyectoWeb].[dbo].Pedido(fechaGeneracion,fechaEntrega,idEstado,idCliente,total)
                                    VALUES(@fechaGeneracion,@fechaEntrega,@idEstado,@idCliente,@total);
                                    SELECT Scope_Identity() as ID";
                comando.Parameters.AddWithValue("@fechaGeneracion", pedido.FechaGeneracion.ToString());
                comando.Parameters.AddWithValue("@fechaEntrega", pedido.FechaEntrega.ToString());
                comando.Parameters.AddWithValue("@idEstado", pedido.IdEstado.ToString());
                comando.Parameters.AddWithValue("@idCliente", pedido.IdCliente.ToString());
                comando.Parameters.AddWithValue("@total", pedido.Total.ToString());
                comando.Transaction = transaccion;
                int idPedidoInsertado = Convert.ToInt32(comando.ExecuteScalar());
                //Insertamos detalles
                foreach (DetallePedido detalle in detalles)

                {
                    SqlCommand comandoDetalle = new SqlCommand();
                    comandoDetalle.Connection = conexion;
                    comandoDetalle.CommandText = @"INSERT INTO [ProyectoWeb].[dbo].DetallePedido(idDetalle,idPedido,idProducto,cantidad)
                                        VALUES(@idDetalle,@idPedido,@idProducto,@cantidad)";
                    comandoDetalle.Parameters.AddWithValue("@idDetalle", detalle.IdDetalle.ToString());
                    comandoDetalle.Parameters.AddWithValue("@idPedido", idPedidoInsertado.ToString());
                    comandoDetalle.Parameters.AddWithValue("@idProducto", detalle.IdProducto.ToString());
                    comandoDetalle.Parameters.AddWithValue("@cantidad", detalle.Cantidad.ToString());
                    comandoDetalle.Transaction = transaccion;
                    comandoDetalle.ExecuteNonQuery();
                }
                //Descontamos saldo a cliente
                Cliente cliente = DAO_Cliente.ObtenerPorID(pedido.IdCliente);
                cliente.Saldo -= pedido.Total;
                DAO_Cliente.Actualizar(cliente);
                transaccion.Commit();
            }
            catch (SqlException) { transaccion.Rollback(); throw; }
            catch (ApplicationException) { transaccion.Rollback(); throw; }
            catch (SystemException) { transaccion.Rollback(); throw; }
            finally { conexion.Close(); }
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
