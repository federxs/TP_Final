using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace DAOs
{
    public static class DAO_Pais
    {
        public static List<Pais> ObtenerTodos()
        {
            List<Pais> listaPais = new List<Pais>();
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = StringConexion.StringBD;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @"SELECT top 1000 P.[idPais], P[nombre] FROM Pais P";
                SqlDataReader dataReader = comando.ExecuteReader();
                while (dataReader.Read())
                {
                    Pais pais = new Pais()
                    {
                        IdPais = int.Parse(dataReader["idPais"].ToString()),
                        Nombre = dataReader["nombre"].ToString()
                    };
                    listaPais.Add(pais);
                }
                dataReader.Close();
                conexion.Close();
                return listaPais;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static Pais ObtenerPorID(int idPais)
        {
            Pais pais = null;
            try
            {
                SqlConnection conexion = new SqlConnection();
                conexion.ConnectionString = StringConexion.StringBD;
                conexion.Open();
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexion;
                comando.CommandText = @"SELECT P.[idPais], P[nombre] FROM Pais P WHERE P.[idPais] = @idPais";
                comando.Parameters.AddWithValue("@idPais", idPais);
                SqlDataReader dataReader = comando.ExecuteReader();
                if (dataReader.Read())
                {
                    pais = new Pais()
                    {
                        IdPais = int.Parse(dataReader["idPais"].ToString()),
                        Nombre = dataReader["nombre"].ToString()
                    };
                }
                dataReader.Close();
                conexion.Close();
                return pais;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
