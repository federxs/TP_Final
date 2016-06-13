using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;


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
            comando.Parameters.AddWithValue("@idLocalidad", cliente.Localidad.IdLocalidad);
            comando.Parameters.AddWithValue("@numeroDoc", cliente.NumeroDoc);
            comando.Parameters.AddWithValue("@idTipoDoc", cliente.TipoDoc.IdTipoDoc);
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
                comando.Parameters.AddWithValue("@idLocalidad", cliente.Localidad.IdLocalidad);
                comando.Parameters.AddWithValue("@numeroDoc", cliente.NumeroDoc);
                comando.Parameters.AddWithValue("@idTipoDoc", cliente.TipoDoc.IdTipoDoc);
                comando.Parameters.AddWithValue("@fechaAlta", cliente.FechaAlta);
                comando.Parameters.AddWithValue("@saldo", cliente.Saldo);
                if (cliente.Borrado)
                    comando.Parameters.AddWithValue("@borrado", 1);
                else
                    comando.Parameters.AddWithValue("@borrado", 0);
                //if (cliente.Sexo.ToString() == "Masculino")
                //    comando.Parameters.AddWithValue("@sexo", true);
                //else
                //    comando.Parameters.AddWithValue("@sexo", false);
                comando.ExecuteNonQuery();

                conexion.Close();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public static List<Cliente> ObtenerClientesQueDeben()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = DAOs.StringConexion.StringLucasBD;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @"SELECT top 1000 C.[idCliente],C.[nombre],C.[apellido],C.[razonSocial], L.[idProvincia],
                C.[telefono],C.[email],C.[cuit],C.[sexo],C.[direccion],L.[nombre] as nombreLocalidad, C.[idLocalidad],
                C.[numeroDoc],TD.[nombre] as nombreTipoDocumento,C.[fechaAlta],C.[saldo],C.[borrado], C.[idTipoDoc] 
                FROM [ProyectoWeb].[dbo].Cliente C JOIN 
                [ProyectoWeb].[dbo].TipoDoc TD ON C.idTipoDoc = TD.idTipoDoc JOIN [ProyectoWeb].[dbo].Localidad L ON C.idLocalidad = L.idLocalidad 
                where C.[borrado]= 'false' and C.[saldo]<0";
                SqlDataReader dataReader = comando.ExecuteReader();
                while (dataReader.Read())
                {
                    Localidad localidad = new Localidad();
                    localidad.IdLocalidad = int.Parse(dataReader["idLocalidad"].ToString());
                    localidad.Nombre = dataReader["nombreLocalidad"].ToString();
                    localidad.Provincia = int.Parse(dataReader["idProvincia"].ToString());
                    TipoDoc tipoDoc = new TipoDoc();
                    tipoDoc.IdTipoDoc = int.Parse(dataReader["idTipoDoc"].ToString());
                    tipoDoc.Nombre = dataReader["nombreTipoDocumento"].ToString();
                    Cliente cliente = new Cliente()
                    {
                        IdCliente = int.Parse(dataReader["idCliente"].ToString()),
                        Telefono = long.Parse(dataReader["telefono"].ToString()),
                        Email = dataReader["email"].ToString(),
                        Cuit = int.Parse(dataReader["cuit"].ToString()),
                        Direccion = dataReader["direccion"].ToString(),
                        Localidad = localidad,
                        NumeroDoc = int.Parse(dataReader["numeroDoc"].ToString()),
                        TipoDoc = tipoDoc,
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
                comando.CommandText = @"SELECT top 1000 C.[idCliente],C.[nombre],C.[apellido],C.[razonSocial], L.[idProvincia],
                C.[telefono],C.[email],C.[cuit],C.[sexo],C.[direccion],L.[nombre] as nombreLocalidad, C.[idLocalidad],
                C.[numeroDoc],TD.[nombre] as nombreTipoDocumento,C.[fechaAlta],C.[saldo],C.[borrado], C.[idTipoDoc] FROM [ProyectoWeb].[dbo].Cliente C JOIN 
                [ProyectoWeb].[dbo].TipoDoc TD ON C.idTipoDoc = TD.idTipoDoc JOIN [ProyectoWeb].[dbo].Localidad L ON C.idLocalidad = L.idLocalidad";
                SqlDataReader dataReader = comando.ExecuteReader();
                while (dataReader.Read())
                {
                    Localidad localidad = new Localidad();
                    localidad.IdLocalidad = int.Parse(dataReader["idLocalidad"].ToString());
                    localidad.Nombre = dataReader["nombreLocalidad"].ToString();
                    localidad.Provincia = int.Parse(dataReader["idProvincia"].ToString());
                    TipoDoc tipoDoc = new TipoDoc();
                    tipoDoc.IdTipoDoc = int.Parse(dataReader["idTipoDoc"].ToString());
                    tipoDoc.Nombre = dataReader["nombreTipoDocumento"].ToString();
                    Cliente cliente = new Cliente()
                    {
                        IdCliente = int.Parse(dataReader["idCliente"].ToString()),
                        Telefono = long.Parse(dataReader["telefono"].ToString()),
                        Email = dataReader["email"].ToString(),
                        Cuit = int.Parse(dataReader["cuit"].ToString()),
                        Direccion = dataReader["direccion"].ToString(),
                        Localidad = localidad,
                        NumeroDoc = int.Parse(dataReader["numeroDoc"].ToString()),
                        TipoDoc = tipoDoc,
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
                comando.CommandText = @"SELECT C.[idCliente],C.[nombre],C.[apellido],C.[razonSocial], L.[idProvincia]
                C.[telefono],C.[email],C.[cuit],C.[sexo],C.[direccion],L.[nombre] as nombreLocalidad, C.[idLocalidad],
                C.[numeroDoc],TD.[nombre] as nombreTipoDocumento,C.[fechaAlta],C.[saldo],C.[borrado], C.[idTipoDoc], FROM Clientes C JOIN 
                TipoDoc TD ON C.idTipoDoc = TD.idTipoDoc JOIN Localidad L ON C.idLocalidad = L.idLocalidad
                WHERE C.idCliente = @idCliente";
                comando.Parameters.AddWithValue("@idCliente", idCliente);
                SqlDataReader dataReader = comando.ExecuteReader();
                if (dataReader.Read())
                {
                    Localidad localidad = new Localidad();
                    localidad.IdLocalidad = int.Parse(dataReader["idLocalidad"].ToString());
                    localidad.Nombre = dataReader["nombreLocalidad"].ToString();
                    localidad.Provincia = int.Parse(dataReader["idProvincia"].ToString());
                    TipoDoc tipoDoc = new TipoDoc();
                    tipoDoc.IdTipoDoc = int.Parse(dataReader["idTipoDoc"].ToString());
                    tipoDoc.Nombre = dataReader["nombreTipoDocumento"].ToString();
                    cliente = new Cliente()
                    {
                        IdCliente = int.Parse(dataReader["idCliente"].ToString()),
                        Telefono = long.Parse(dataReader["telefono"].ToString()),
                        Email = dataReader["email"].ToString(),
                        Cuit = int.Parse(dataReader["cuit"].ToString()),
                        Direccion = dataReader["direccion"].ToString(),
                        Localidad = localidad,
                        NumeroDoc = int.Parse(dataReader["numeroDoc"].ToString()),
                        TipoDoc = tipoDoc,
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
