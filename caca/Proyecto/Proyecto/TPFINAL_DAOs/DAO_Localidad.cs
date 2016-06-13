using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace DAOs
{
    public static class DAO_Localidad
    {
        public static List<Localidad> ObtenerPorProvincia(int idProvincia)
        {
            List<Localidad> listaLocalidad = new List<Localidad>();
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = StringConexion.StringBD;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @"SELECT top 1000 L.[idLocalidad], L.[nombre], L.[idProvincia] FROM Localidad L WHERE L.idProvincia = @idProvincia";
                comando.Parameters.AddWithValue("@idProvincia",idProvincia);
                SqlDataReader dataReader = comando.ExecuteReader();
                while (dataReader.Read())
                {
                    Localidad localidad = new Localidad()
                    {
                        IdLocalidad = int.Parse(dataReader["idLocalidad"].ToString()),
                        Nombre = dataReader["nombre"].ToString(),
                        Provincia = int.Parse(dataReader["idProvincia"].ToString())
                    };
                    listaLocalidad.Add(localidad);
                }
                dataReader.Close();
                conexion.Close();
                return listaLocalidad;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static Localidad ObtenerPorID(int idLocalidad)
        {
            Localidad localidad = null;
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = StringConexion.StringBD;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @"SELECT L.[idLocalidad], L.[nombre], L.[idProvincia] FROM Localidad L WHERE L.[idLocalidad] = @idLocalidad";
                comando.Parameters.AddWithValue("@idLocalidad", idLocalidad);
                SqlDataReader dataReader = comando.ExecuteReader();
                if (dataReader.Read())
                {
                    localidad = new Localidad()
                    {
                        IdLocalidad = int.Parse(dataReader["idLocalidad"].ToString()),
                        Nombre = dataReader["nombre"].ToString(),
                        Provincia = int.Parse(dataReader["idProvincia"].ToString())
                    };
                }
                dataReader.Close();
                conexion.Close();
                return localidad;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
