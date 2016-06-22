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
            comando.CommandText = @"DELETE FROM Cliente WHERE idCliente = @idCliente";
            comando.Parameters.AddWithValue("@idCliente", id);
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public static void Actualizar(Cliente cliente)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = DAOs.StringConexion.StringBD;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @"UPDATE [ProyectoWeb].[dbo].Cliente SET [nombre] = @nombre, [apellido] = @apellido, [telefono] = @telefono, [email] = @email
                                    ,[cuit] = @cuit, [sexo] = @sexo, [direccion] = @direccion, [idLocalidad] = @idLocalidad, [numeroDoc] = @numeroDoc
                                    ,[idTipoDoc] = @idTipoDoc, [fechaAlta] = @fechaAlta, [saldo] = @saldo, [borrado] = 0 
                                    WHERE idCliente = @idCliente";
                comando.Parameters.AddWithValue("@idCliente", cliente.IdCliente);
                comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@apellido", cliente.Apellido);
                comando.Parameters.AddWithValue("@telefono", cliente.Telefono);
                comando.Parameters.AddWithValue("@email", cliente.Email);
                comando.Parameters.AddWithValue("@cuit", cliente.Cuit);
                comando.Parameters.AddWithValue("@direccion", cliente.Direccion);
                comando.Parameters.AddWithValue("@idLocalidad", cliente.Localidad);
                comando.Parameters.AddWithValue("@numeroDoc", cliente.NumeroDoc);
                comando.Parameters.AddWithValue("@idTipoDoc", cliente.TipoDoc);
                comando.Parameters.AddWithValue("@fechaAlta", cliente.FechaAlta);
                comando.Parameters.AddWithValue("@saldo", cliente.Saldo);
                if (cliente.Sexo.ToString() == "Masculino")
                    comando.Parameters.AddWithValue("@sexo", 1);
                else
                    comando.Parameters.AddWithValue("@sexo", 0);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (SqlException exSql) { throw exSql; }
            catch (SystemException ex) { throw ex; }
            catch (ApplicationException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
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
                comando.CommandText = @"INSERT INTO [ProyectoWeb].[dbo].Cliente([nombre],[apellido],
                [telefono],[email],[cuit],[sexo],[direccion],[idLocalidad],
                [numeroDoc],[idTipoDoc],[fechaAlta],[saldo],[borrado]) VALUES(@nombre,@apellido,@razonSocial,
                @telefono,@email,@cuit,@sexo,@direccion,@idLocalidad,
                @numeroDoc,@idTipoDoc,@fechaAlta,@saldo,@borrado)";
                comando.Parameters.AddWithValue("@nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@apellido", cliente.Apellido);
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
                    comando.Parameters.AddWithValue("@sexo", 1);
                else
                    comando.Parameters.AddWithValue("@sexo", 0);
                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (SqlException exSql) { throw exSql; }
            catch (SystemException ex) { throw ex; }
            catch (ApplicationException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
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
                comando.CommandText = @"SELECT top 1000 C.[idCliente],C.[nombre],C.[apellido], C.[idLocalidad],
                C.[telefono],C.[email],C.[cuit],C.[sexo],C.[direccion], C.[saldo], C.[borrado], C.[idTipoDoc],
                C.[numeroDoc],C.[idTipoDoc], C.[fechaAlta] FROM [ProyectoWeb].[dbo].Cliente C WHERE borrado = 0";
                SqlDataReader dataReader = comando.ExecuteReader();
                while (dataReader.Read())
                {
                    Cliente cliente = new Cliente()
                    {
                        IdCliente = int.Parse(dataReader["idCliente"].ToString()),
                        Telefono = long.Parse(dataReader["telefono"].ToString()),
                        Email = dataReader["email"].ToString(),
                        Cuit = dataReader["cuit"].ToString(),
                        Direccion = dataReader["direccion"].ToString(),
                        Localidad = int.Parse(dataReader["idLocalidad"].ToString()),
                        NumeroDoc = int.Parse(dataReader["numeroDoc"].ToString()),
                        TipoDoc = int.Parse(dataReader["idTipoDoc"].ToString()),
                        FechaAlta = (DateTime)dataReader["fechaAlta"],
                        Saldo = float.Parse(dataReader["saldo"].ToString()),
                        Borrado = Convert.ToBoolean(dataReader["borrado"].ToString()),
                        Apellido = dataReader["apellido"].ToString(),
                        Nombre = dataReader["nombre"].ToString()
                    };
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
            catch (SqlException exSql) { throw exSql; }
            catch (SystemException ex) { throw ex; }
            catch (ApplicationException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
        }

        public static List<Cliente> ObtenerTodos(string apellidoBusqueda)
        {
            List<Cliente> listaClientes = new List<Cliente>();
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = DAOs.StringConexion.StringBD;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @"SELECT top 1000 C.[idCliente],C.[nombre],C.[apellido], C.[idLocalidad],
                C.[telefono],C.[email],C.[cuit],C.[sexo],C.[direccion], C.[saldo], C.[borrado], C.[idTipoDoc],
                C.[numeroDoc],C.[idTipoDoc], C.[fechaAlta] FROM [ProyectoWeb].[dbo].Cliente C WHERE borrado = 0";
                if (!string.IsNullOrEmpty(apellidoBusqueda))
                {
                    comando.CommandText += " AND C.[apellido] LIKE @apellido";
                    comando.Parameters.AddWithValue("@apellido", "%" + apellidoBusqueda.ToLower() + "%");
                }
                SqlDataReader dataReader = comando.ExecuteReader();
                while (dataReader.Read())
                {
                    Cliente cliente = new Cliente()
                    {
                        IdCliente = int.Parse(dataReader["idCliente"].ToString()),
                        Telefono = long.Parse(dataReader["telefono"].ToString()),
                        Email = dataReader["email"].ToString(),
                        Cuit = dataReader["cuit"].ToString(),
                        Direccion = dataReader["direccion"].ToString(),
                        Localidad = int.Parse(dataReader["idLocalidad"].ToString()),
                        NumeroDoc = int.Parse(dataReader["numeroDoc"].ToString()),
                        TipoDoc = int.Parse(dataReader["idTipoDoc"].ToString()),
                        FechaAlta = (DateTime)dataReader["fechaAlta"],
                        Saldo = float.Parse(dataReader["saldo"].ToString()),
                        Borrado = Convert.ToBoolean(dataReader["borrado"].ToString()),
                        Apellido = dataReader["apellido"].ToString(),
                        Nombre = dataReader["nombre"].ToString()
                    };
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
            catch (SqlException exSql) { throw exSql; }
            catch (SystemException ex) { throw ex; }
            catch (ApplicationException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
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
                comando.CommandText = @"SELECT  C.[idCliente],C.[nombre],C.[apellido],C.[idLocalidad],
                C.[telefono],C.[email],C.[cuit],C.[sexo],C.[direccion], C.[saldo], C.[borrado], C.[idTipoDoc],
                C.[numeroDoc], C.[fechaAlta] FROM [ProyectoWeb].[dbo].Cliente C WHERE C.idCliente = @idCliente";
                comando.Parameters.AddWithValue("@idCliente", idCliente);
                SqlDataReader dataReader = comando.ExecuteReader();
                if (dataReader.Read())
                {
                    cliente = new Cliente()
                    {
                        IdCliente = int.Parse(dataReader["idCliente"].ToString()),
                        Telefono = long.Parse(dataReader["telefono"].ToString()),
                        Email = dataReader["email"].ToString(),
                        Cuit = dataReader["cuit"].ToString(),
                        Direccion = dataReader["direccion"].ToString(),
                        Localidad = int.Parse(dataReader["idLocalidad"].ToString()),
                        NumeroDoc = int.Parse(dataReader["numeroDoc"].ToString()),
                        TipoDoc = int.Parse(dataReader["idTipoDoc"].ToString()),
                        FechaAlta = (DateTime)dataReader["fechaAlta"],
                        Saldo = float.Parse(dataReader["saldo"].ToString()),
                        Borrado = Convert.ToBoolean(dataReader["borrado"].ToString()),
                        Apellido = dataReader["apellido"].ToString(),
                        Nombre = dataReader["nombre"].ToString()
                    };
                    if (Convert.ToBoolean(dataReader["sexo"].ToString()))
                        cliente.Sexo = "Masculino";
                    else
                        cliente.Sexo = "Femenino";
                }
                dataReader.Close();
                conexion.Close();
                return cliente;
            }
            catch (SqlException exSql) { throw exSql; }
            catch (SystemException ex) { throw ex; }
            catch (ApplicationException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
        }

        public static Cliente obtenerPorDocumento(int numero, int tipo) 
        {
            Cliente cliente = null;
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = DAOs.StringConexion.StringBD;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @"SELECT  C.[idCliente],C.[nombre],C.[apellido],C.[idLocalidad],
                C.[telefono],C.[email],C.[cuit],C.[sexo],C.[direccion], C.[saldo], C.[borrado], C.[idTipoDoc],
                C.[numeroDoc], C.[fechaAlta] FROM [ProyectoWeb].[dbo].Cliente C WHERE C.numeroDoc = @numero AND C.idTipoDoc = @tipo";
                comando.Parameters.AddWithValue("@numero", numero);
                comando.Parameters.AddWithValue("@tipo", tipo);
                SqlDataReader dataReader = comando.ExecuteReader();
                if (dataReader.Read())
                {
                    cliente = new Cliente()
                    {
                        IdCliente = int.Parse(dataReader["idCliente"].ToString()),
                        Telefono = long.Parse(dataReader["telefono"].ToString()),
                        Email = dataReader["email"].ToString(),
                        Cuit = dataReader["cuit"].ToString(),
                        Direccion = dataReader["direccion"].ToString(),
                        Localidad = int.Parse(dataReader["idLocalidad"].ToString()),
                        NumeroDoc = int.Parse(dataReader["numeroDoc"].ToString()),
                        TipoDoc = int.Parse(dataReader["idTipoDoc"].ToString()),
                        FechaAlta = (DateTime)dataReader["fechaAlta"],
                        Saldo = float.Parse(dataReader["saldo"].ToString()),
                        Borrado = Convert.ToBoolean(dataReader["borrado"].ToString()),
                        Apellido = dataReader["apellido"].ToString(),
                        Nombre = dataReader["nombre"].ToString()
                    };
                    if (Convert.ToBoolean(dataReader["sexo"].ToString()))
                        cliente.Sexo = "Masculino";
                    else
                        cliente.Sexo = "Femenino";
                }
                dataReader.Close();
                conexion.Close();
                return cliente;
            }
            catch (SqlException exSql) { throw exSql; }
            catch (SystemException ex) { throw ex; }
            catch (ApplicationException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
        }

        public static List<Cliente> obtenerClientesTransaccion()
        {
            List<Cliente> lista = new List<Cliente>();
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = DAOs.StringConexion.StringBD;
                cn.Open();
                //2. Crear el objeto command para ejecutar el insert
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"Select distinct c.nombre, c.apellido, c.idCliente 
                                From Pedido p Join Cliente c on p.idCliente = c.idCliente 
                                where p.idEstado = 1 or p.idEstado = 3 
                                order by c.idCliente";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cliente c = new Cliente();
                    int idCliente = int.Parse(dr["idCliente"].ToString());
                    String nombre = dr["nombre"].ToString();
                    String apellido = dr["apellido"].ToString();
                    c.Apellido = apellido;
                    c.Nombre = nombre;
                    c.IdCliente = idCliente;
                    lista.Add(c);
                }
                dr.Close();
                cn.Close();
            }
            catch (SqlException exSql) { throw exSql; }
            return lista;
        }
    }
}
