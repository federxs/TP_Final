using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace DAOs
{
    public class DAO_Cliente
    {

        public static void Eliminar(int id)
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = DAOs.StringConexion.StringBD;
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = @"UPDATE Cliente SET borrado = 1 WHERE idCliente = @idCliente";
            comando.Parameters.AddWithValue("@idCliente", id);
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public static void Actualizar(Cliente cliente)
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = DAOs.StringConexion.StringBD;
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = @"UPDATE Cliente SET [nombre] = @nombre, [apellido] = @apellido, [razonSocial] = @razonSocial, [telefono] = @telefono, [email] = @email
                                    ,[cuit] = @cuit, [sexo] = @sexo, [direccion] = @direccion, [idLocalidad] = @idLocalidad, [numeroDoc] = @numeroDoc
                                    ,[idTipoDoc] = @idTipoDoc, [fechaAlta] = @fechaAlta, [saldo] = @saldo, [borrado] = @borrado 
                                    WHERE idCliente = @idCliente";
            comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
            comando.Parameters.AddWithValue("@apellido", cliente.Apellido);
            comando.Parameters.AddWithValue("@razonSocial", cliente.RazonSocial);
            comando.Parameters.AddWithValue("@telefono", cliente.Telefono);
            comando.Parameters.AddWithValue("@email", cliente.Email);
            comando.Parameters.AddWithValue("@cuit", cliente.Cuit);
            comando.Parameters.AddWithValue("@direccion", cliente.Direccion);
            comando.Parameters.AddWithValue("@idLocalidad", cliente.Localidad);
            comando.Parameters.AddWithValue("@numeroDoc", cliente.NumeroDoc);
            comando.Parameters.AddWithValue("@idTipoDoc", cliente.TipoDoc);
            comando.Parameters.AddWithValue("@fechaAlta", cliente.FechaAlta);
            comando.Parameters.AddWithValue("@saldo", cliente.Saldo);
            if (cliente.Borrado)
                comando.Parameters.AddWithValue("@borrado", 1);
            else
                comando.Parameters.AddWithValue("@borrado", 0);
            if (cliente.Sexo.ToString() == "Masculino")
                comando.Parameters.AddWithValue("@sexo", true);
            else
                comando.Parameters.AddWithValue("@sexo", false);
        }

        public static void Insertar(Cliente cliente)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = DAOs.StringConexion.StringBD;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @"INSERT INTO Cliente([nombre],[apellido],[razonSocial],
                [telefono],[email],[cuit],[sexo],[direccion],[idLocalidad],
                [numeroDoc],[idTipoDoc],[fechaAlta],[saldo],[borrado]) VALUES(@nombre,@apellido,@razonSocial,
                @telefono,@email,@cuit,@sexo,@direccion,@idLocalidad,
                @numeroDoc,@idTipoDoc,@fechaAlta,@saldo,@borrado)";
                comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@apellido", cliente.Apellido);
                comando.Parameters.AddWithValue("@razonSocial", cliente.RazonSocial);
                comando.Parameters.AddWithValue("@telefono", cliente.Telefono);
                comando.Parameters.AddWithValue("@email", cliente.Email);
                comando.Parameters.AddWithValue("@cuit", cliente.Cuit);
                if (cliente.Sexo == "Masculino")
                    comando.Parameters.AddWithValue("@sexo", 1);
                else
                    comando.Parameters.AddWithValue("@sexo", 0);
                comando.Parameters.AddWithValue("@direccion", cliente.Direccion);
                comando.Parameters.AddWithValue("@idLocalidad", cliente.Localidad);
                comando.Parameters.AddWithValue("@numeroDoc", cliente.NumeroDoc);
                comando.Parameters.AddWithValue("@idTipoDoc", cliente.TipoDoc);
                comando.Parameters.AddWithValue("@fechaAlta", cliente.FechaAlta);
                comando.Parameters.AddWithValue("@saldo", cliente.Saldo);
                if (cliente.Borrado)
                    comando.Parameters.AddWithValue("@borrado", 1);
                else
                    comando.Parameters.AddWithValue("@borrado", 0);
                if (cliente.Sexo.ToString() == "Masculino")
                    comando.Parameters.AddWithValue("@sexo", true);
                else
                    comando.Parameters.AddWithValue("@sexo", false);
                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static List<Cliente> ObtenerTodos()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = DAOs.StringConexion.StringBD;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @"SELECT top 1000 C.[idCliente],C.[nombre],C.[apellido],C.[razonSocial], C.[idLocalidad],
                C.[telefono],C.[email],C.[cuit],C.[sexo],C.[direccion], C.[saldo], C.[borrado], C.[idTipoDoc],
                C.[numeroDoc],C.[idTipoDoc], C.[fechaAlta] FROM [ProyectoWeb].[dbo].Cliente C";
                SqlDataReader dataReader = comando.ExecuteReader();
                while (dataReader.Read())
                {
                    Cliente cliente = new Cliente()
                    {
                        IdCliente = int.Parse(dataReader["idCliente"].ToString()),
                        Telefono = long.Parse(dataReader["telefono"].ToString()),
                        Email = dataReader["email"].ToString(),
                        Cuit = int.Parse(dataReader["cuit"].ToString()),
                        Direccion = dataReader["direccion"].ToString(),
                        Localidad = int.Parse(dataReader["idLocalidad"].ToString()),
                        NumeroDoc = int.Parse(dataReader["numeroDoc"].ToString()),
                        TipoDoc = int.Parse(dataReader["idTipoDoc"].ToString()),
                        FechaAlta = (DateTime)dataReader["fechaAlta"],
                        Saldo = float.Parse(dataReader["saldo"].ToString()),
                        Borrado = Convert.ToBoolean(dataReader["borrado"].ToString())
                    };
                    if (dataReader["apellido"] != DBNull.Value)
                        cliente.Apellido = dataReader["apellido"].ToString();
                    if (dataReader["nombre"] != DBNull.Value)
                        cliente.Nombre = dataReader["nombre"].ToString();
                    if (dataReader["razonSocial"] != DBNull.Value)
                        cliente.RazonSocial = dataReader["razonSocial"].ToString();
                    if (Convert.ToBoolean(dataReader["sexo"].ToString()))
                        cliente.Sexo = "Masculino";
                    else
                        cliente.Sexo = "Femenino";
                    listaClientes.Add(cliente);
                }
                dataReader.Close();
                conexion.Close();
                return listaClientes;
            }
            catch (ApplicationException e)
            {

                throw e;
            }
        }

        public static Cliente ObtenerPorID(int idCliente)
        {
            Cliente cliente = null;
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = DAOs.StringConexion.StringBD;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @"SELECT  C.[idCliente],C.[nombre],C.[apellido],C.[razonSocial], C.[idLocalidad],
                C.[telefono],C.[email],C.[cuit],C.[sexo],C.[direccion], C.[saldo], C.[borrado], C.[idTipoDoc],
                C.[numeroDoc],C.[idTipoDoc], C.[fechaAlta] FROM [ProyectoWeb].[dbo].Cliente C WHERE C.idCliente = @idCliente";
                comando.Parameters.AddWithValue("@idCliente", idCliente);
                SqlDataReader dataReader = comando.ExecuteReader();
                if (dataReader.Read())
                {
                    cliente = new Cliente()
                     {
                         IdCliente = int.Parse(dataReader["idCliente"].ToString()),
                         Telefono = long.Parse(dataReader["telefono"].ToString()),
                         Email = dataReader["email"].ToString(),
                         Cuit = int.Parse(dataReader["cuit"].ToString()),
                         Direccion = dataReader["direccion"].ToString(),
                         Localidad = int.Parse(dataReader["idLocalidad"].ToString()),
                         NumeroDoc = int.Parse(dataReader["numeroDoc"].ToString()),
                         TipoDoc = int.Parse(dataReader["idTipoDoc"].ToString()),
                         FechaAlta = (DateTime)dataReader["fechaAlta"],
                         Saldo = float.Parse(dataReader["saldo"].ToString()),
                         Borrado = Convert.ToBoolean(dataReader["borrado"].ToString())
                     };
                    if (dataReader["apellido"] != DBNull.Value)
                        cliente.Apellido = dataReader["apellido"].ToString();
                    if (dataReader["nombre"] != DBNull.Value)
                        cliente.Nombre = dataReader["nombre"].ToString();
                    if (dataReader["razonSocial"] != DBNull.Value)
                        cliente.RazonSocial = dataReader["razonSocial"].ToString();
                    if (Convert.ToBoolean(dataReader["sexo"].ToString()))
                        cliente.Sexo = "Masculino";
                    else
                        cliente.Sexo = "Femenino";
                }
                dataReader.Close();
                conexion.Close();
                return cliente;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
