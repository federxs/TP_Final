using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
namespace DAOs
{
    public class DAO_RegistrarPago
    {

        public static Boolean registrarPago(List<DetallePagoGrillaEntidad> pagos, int idPedido, int idCliente, float saldo)
        {
            Boolean respuesta = false;
            //1. Abrir la conexion
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = DAOs.StringConexion.StringBD;
            cn.Open();
            // Creamos un objeto para la transaccion
            SqlTransaction tran = cn.BeginTransaction();
            try
            {
                //2. Crear el objeto command para ejecutar el insert
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"Insert into Pago (idPedido, fechaPago) values (
                                    @idPedido, @fechaPago);select Scope_Identity() as idPago";
                cmd.Parameters.AddWithValue("@idPedido", idPedido);
                DateTime myDateTime = DateTime.Now;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                cmd.Parameters.AddWithValue("@fechaPago", sqlFormattedDate);
                cmd.Transaction = tran;
                int idPago = Convert.ToInt32(cmd.ExecuteScalar());
                foreach (DetallePagoGrillaEntidad p in pagos)
                {
                    //Realizo el insert de los telefonos
                    SqlCommand cmdTe = new SqlCommand();
                    cmdTe.Connection = cn;
                    cmdTe.CommandText = @"Insert into DetallePago (idPago, idFormaPago, cantidad)
                                          values (@idPago, @idFormaPago, @cantidad)
                                          ;select Scope_Identity() as ID";
                    cmdTe.Parameters.AddWithValue("@idPago", idPago);
                    cmdTe.Parameters.AddWithValue("@idFormaPago", p.idFormaPago);
                    cmdTe.Parameters.AddWithValue("@cantidad", p.cantidad);
                    cmdTe.Transaction = tran;
                    cmdTe.ExecuteNonQuery();
                }
                SqlCommand cmdPe = new SqlCommand();
                cmdPe.Connection = cn;
                cmdPe.CommandText = @"Update Pedido set idEstado = 2 where idPedido= @idPedido";
                cmdPe.Parameters.AddWithValue("@idPedido", idPedido);
                cmdPe.Transaction = tran;
                cmdPe.ExecuteNonQuery();

                SqlCommand cmdSaldo = new SqlCommand();
                cmdSaldo.Connection = cn;
                cmdSaldo.CommandText = @"Select saldo from Cliente where idCliente = @idCliente";
                cmdSaldo.Parameters.AddWithValue("@idCliente",idCliente);
                cmdSaldo.Transaction = tran;
                SqlDataReader dr = cmdSaldo.ExecuteReader();
                float saldoCliente = 0;
                if (dr.Read())
                {
                    saldoCliente = float.Parse(dr["saldo"].ToString());
                }
                dr.Close();

                SqlCommand cmdCli = new SqlCommand();
                cmdCli.Connection = cn;
                cmdCli.CommandText = @"Update Cliente set saldo = @sal where idCliente= @idCliente";
                cmdCli.Parameters.AddWithValue("@sal", (saldoCliente - saldo));
                cmdCli.Parameters.AddWithValue("@idCliente", idCliente);
                cmdCli.Transaction = tran;
                cmdCli.ExecuteNonQuery();
                tran.Commit();
                respuesta = true;
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                //Cerrar siempre la conexion
                cn.Close();
            }

            return respuesta;
        }
    }
}
