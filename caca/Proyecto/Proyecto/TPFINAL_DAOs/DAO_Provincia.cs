using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace DAOs
{
    public static class DAO_Provincia
    {
        public static List<Provincia> ObtenerTodos()
        {
            List<Provincia> listaProvincia = new List<Provincia>();
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = StringConexion.StringBD;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @"SELECT top 1000 P.[idProvincia], P.[nombre] FROM Provincia P";
                SqlDataReader dataReader = comando.ExecuteReader();
                while (dataReader.Read())
                {
                    Provincia provincia = new Provincia()
                    {
                        IdProvincia = int.Parse(dataReader["idProvincia"].ToString()),
                        Nombre = dataReader["nombre"].ToString()
                        //Pais = int.Parse(dataReader["idPais"].ToString())
                    };
                    listaProvincia.Add(provincia);
                }
                dataReader.Close();
                conexion.Close();
                return listaProvincia;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static Provincia ObtenerPorID(int idProvincia)
        {
            Provincia provincia = null;
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = StringConexion.StringBD;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @"SELECT P.[idProvincia], P.[nombre] FROM Provincia P WHERE P.[idProvincia] = @idProvincia";
                comando.Parameters.AddWithValue("@idProvincia", idProvincia);
                SqlDataReader dataReader = comando.ExecuteReader();
                if (dataReader.Read())
                {
                    provincia = new Provincia()
                    {
                        IdProvincia = int.Parse(dataReader["idProvincia"].ToString()),
                        Nombre = dataReader["nombre"].ToString()
                        //Pais = int.Parse(dataReader["idPais"].ToString())
                    };
                }
                dataReader.Close();
                conexion.Close();
                return provincia;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static int obtenerPorLocalidad(int idLocalidad)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = StringConexion.StringBD;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @"SELECT L.[idProvincia] FROM Localidad L WHERE L.[idLocalidad] = @idLocalidad";
                comando.Parameters.AddWithValue("@idLocalidad", idLocalidad);
                int idProvincia = (int) comando.ExecuteScalar();
                conexion.Close();
                return idProvincia;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
